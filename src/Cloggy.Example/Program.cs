// See https://aka.ms/new-console-template for more information

using Cloggy;
var logger = new Logger(new SystemConsole(), false,new SystemDateProvider());

logger.Log("Hola mundo!");