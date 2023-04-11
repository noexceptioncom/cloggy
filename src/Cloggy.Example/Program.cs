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

var plainTextLoggerToFile = Logger.CreatePlainTextLoggerToFile(category, @".\plainTextLogger.txt");
plainTextLoggerToFile.LogInformation("Log Info to File");
plainTextLoggerToFile.LogInformation("Log Info to File second line");

var jsonLoggerToFile= Logger.CreateJsonLoggerToFile(category, @".\plainTextLogger.json");
jsonLoggerToFile.LogInformation("Log Json Info to File");
jsonLoggerToFile.LogInformation("Log Json Info to File second line");