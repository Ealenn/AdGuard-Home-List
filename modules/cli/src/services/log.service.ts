import { Injectable, ConsoleLogger } from '@nestjs/common';

@Injectable()
export class LogService extends ConsoleLogger {}
