// See https://aka.ms/new-console-template for more information

using Cloggy;
var logger = Logger.CreateLoggerWithDateTime();

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");


var loggerWithoutDate = Logger.CreateLoggerWithoutDateTime();
loggerWithoutDate.LogInformation("Log simple");
