import { CommandFactory } from 'nest-commander';
import { AppModule } from './app.module';
import { LogService } from './services/log.service';

async function bootstrap() {
  await CommandFactory.run(AppModule, new LogService());
}
bootstrap();
