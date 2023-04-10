// See https://aka.ms/new-console-template for more information

using Cloggy;
var logger = new Logger(new LoggerConfig(new SystemConsole(), new SystemDateProvider(), true));

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");


var loggerWithoutDate = new Logger(new LoggerConfig(new SystemConsole(), new SystemDateProvider(), false));
loggerWithoutDate.LogInformation("Log simple");
