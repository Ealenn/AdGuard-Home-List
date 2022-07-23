import { Module } from '@nestjs/common';
import { GenerateCommand } from './commands/generate.command';
import { LogService, FileService, AdguardRuleService } from './services';

@Module({
  imports: [],
  controllers: [],
  providers: [LogService, FileService, AdguardRuleService, GenerateCommand],
})
export class AppModule {}
