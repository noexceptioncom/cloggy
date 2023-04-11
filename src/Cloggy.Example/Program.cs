// See https://aka.ms/new-console-template for more information

using Cloggy;
var category = "Category1";
var logger = Logger.CreatePlainTextLogger(category);

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");

var jsonLogger = Logger.CreateJsonLogger(category);
jsonLogger.LogInformation("Log info");
jsonLogger.LogError("Log error");
jsonLogger.LogWarning("Log warning");

var plainTextLogger = Logger.CreatePlainTextLoggerToFile(category, @".\plainTextLogger.txt");
plainTextLogger.LogInformation("Log Info to File");
