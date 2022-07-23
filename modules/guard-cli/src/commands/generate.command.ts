import { Command, CommandRunner, Option } from 'nest-commander';
import { AdGuardList, Badge } from '../domain';
import { LogService, FileService, AdguardRuleService } from '../services';
import * as Path from 'path';

interface GenerateCommandOptions {
  name: string;
  external: string;
  concatExternal: string;
  custom: string;
  output: string;
  badge?: string;
  convertToAllow?: boolean;
  debug?: boolean;
}

@Command({ name: 'generate', description: 'Generate AdGuard List' })
export class GenerateCommand implements CommandRunner {
  private _list = new AdGuardList();

  constructor(
    private readonly logService: LogService,
    private readonly fileService: FileService,
    private readonly adguardRuleService: AdguardRuleService,
  ) {}

  async run(
    _passedParam: string[],
    options: GenerateCommandOptions,
  ): Promise<void> {
    /**
     * Get Rules
     */
    const customFilesPath = this.fileService.ListFiles(options.custom);
    const externalFilesPath = this.fileService.ListFiles(options.external);
    const concatExternalFilesPath = this.fileService.ListFiles(
      options.concatExternal,
    );

    /**
     * Custom
     */
    for (const customFilePath of customFilesPath) {
      this.logService.log(`Loading ${customFilePath}...`);
      const lines = this.fileService.GetFileLines(customFilePath);
      for (const line of lines) {
        const rule = this.adguardRuleService.FromAdGuard(line);
        if (rule) {
          this._list.add(rule, [customFilePath]);
        }
      }
    }

    /**
     * Concat
     */
    for (const concatExternalFilePath of concatExternalFilesPath) {
      this.logService.log(`Loading ${concatExternalFilePath}...`);
      const concatExternalFiles = this.fileService.GetFileLines(
        concatExternalFilePath,
      );
      for (const concatExternalFile of concatExternalFiles) {
        const lines = await this.fileService.GetRemoteFileLines(
          concatExternalFile,
        );
        for (const line of lines) {
          const rule = this.adguardRuleService.FromAdGuard(line);
          if (rule) {
            this._list.add(rule, [concatExternalFilePath, concatExternalFile]);
          }
        }
      }
    }

    /**
     * External
     */
    for (const externalFilePath of externalFilesPath) {
      this.logService.log(`Loading ${externalFilePath}...`);
      const externalFiles = this.fileService.GetFileLines(externalFilePath);
      for (const externalFile of externalFiles) {
        const lines = await this.fileService.GetRemoteFileLines(externalFile);
        for (const line of lines) {
          const rule = this.adguardRuleService.FromUrlOrIp(
            line,
            options.convertToAllow,
          );
          if (rule) {
            this._list.add(rule, [externalFilePath, externalFile]);
          }
        }
      }
    }

    /**
     * Generate List
     */
    this.fileService.ReplaceFile(
      Path.join(options.output, options.name),
      this.getFileData(false),
    );
    if (options.debug) {
      this.fileService.ReplaceFile(
        Path.join(options.output, 'debug.' + options.name),
        this.getFileData(true),
      );
    }

    /**
     * Generate Badge
     */
    if (options.badge) {
      const badge: Badge = {
        schemaVersion: 1,
        label: options.convertToAllow ? 'Allow' : 'Block',
        message: this._list.export().size.toString(),
        color: options.convertToAllow ? 'green' : 'red',
      };
      this.fileService.ReplaceFile(
        Path.join(options.output, options.badge),
        JSON.stringify(badge),
      );
    }
  }

  private getFileData(debug: boolean): string {
    const fileLines: string[] = [];
    for (const rule of this._list.export()) {
      let line = rule[0];
      if (debug) {
        line = `${line} #${rule[1]}`;
      }
      fileLines.push(line);
    }
    return fileLines.join('\n');
  }

  @Option({
    flags: '-n, --name [string]',
    description: 'List File Name',
    required: true,
  })
  parseName(val: string): string {
    return val;
  }

  @Option({
    flags: '-b, --badge [string]',
    description: 'Badge File Name',
    required: false,
  })
  parseBadge(val?: string): string {
    if (val && val.length > 0) {
      return val;
    }
    return null;
  }

  @Option({
    flags: '--convertToAllow',
    description: 'Convert rule to allow rule',
    required: false,
    defaultValue: false,
  })
  parseConvertToAllow(val?: boolean): boolean {
    return val;
  }

  @Option({
    flags: '--debug',
    description: 'Add comment in list',
    required: false,
    defaultValue: false,
  })
  parseDebug(val?: boolean): boolean {
    return val;
  }

  @Option({
    flags: '-e, --external [string]',
    description: 'External Path',
    required: true,
  })
  parseExternalAllowPath(val: string): string {
    return this._validatePath(val);
  }

  @Option({
    flags: '-ce, --concatExternal [string]',
    description: 'AdGuard Rules to add from external lists',
    required: true,
  })
  parseConcatExternal(val: string): string {
    return this._validatePath(val);
  }

  @Option({
    flags: '-c, --custom [string]',
    description: 'Custom Path',
    required: true,
  })
  parseCustomAllowPath(val: string): string {
    return this._validatePath(val);
  }

  @Option({
    flags: '-o, --output [string]',
    description: 'Output Path',
    required: true,
  })
  parseOutput(val: string): string {
    return this._validatePath(val);
  }

  private _validatePath(val: string): string {
    if (!this.fileService.PathExist(val)) {
      this.logService.error(`Path "${val}" must be valid.`);
      process.exit(1);
    }
    return val;
  }
}
