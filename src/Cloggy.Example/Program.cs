// See https://aka.ms/new-console-template for more information

using Cloggy;
var logger = new Logger(new LoggerConfig(new SystemConsole(), new SystemDateProvider(), true));

logger.Log("Hola mundo!");