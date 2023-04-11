// See https://aka.ms/new-console-template for more information

using Cloggy;
var category = "Category1";
var logger = Logger.CreateLoggerWithDateTime(category);

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");

var jsonLogger = Logger.CreateJsonLoggerWithDateTime(category);
jsonLogger.LogInformation("Log info");
jsonLogger.LogError("Log error");
jsonLogger.LogWarning("Log warning");
