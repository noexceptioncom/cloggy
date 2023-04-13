// See https://aka.ms/new-console-template for more information

using Cloggy;
var category = "Category1";
var logger = LoggerFactory.CreatePlainTextLoggerToConsole(category);

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");

var jsonLogger = LoggerFactory.CreateJsonLoggerToConsole(category);
jsonLogger.LogInformation("Log info");
jsonLogger.LogError("Log error");
jsonLogger.LogWarning("Log warning");

var plainTextLoggerToFile = LoggerFactory.CreatePlainTextLoggerToFile(category, @".\plainTextLogger.txt");
plainTextLoggerToFile.LogInformation("Log Info to File");
plainTextLoggerToFile.LogInformation("Log Info to File second line");

var jsonLoggerToFile= LoggerFactory.CreateJsonLoggerToFile(category, @".\jsonLogger.json");
jsonLoggerToFile.LogInformation("Log Json Info to File");
jsonLoggerToFile.LogInformation("Log Json Info to File second line");

var plainTextLoggerToFileAndConsole = LoggerFactory.CreatePlainTextLoggerToFileAndConsole(category, @".\plainTextLogger.txt");
plainTextLoggerToFileAndConsole.LogInformation("Log Info to File and Console");
plainTextLoggerToFileAndConsole.LogInformation("Log Info to File and Console second line");

var jsonLoggerToFileAndConsole = LoggerFactory.CreateJsonLoggerToFileAndConsole(category, @".\jsonLogger.json");
jsonLoggerToFileAndConsole.LogInformation("Log Json Info to File and Console");
jsonLoggerToFileAndConsole.LogInformation("Log Json Info to File and Console second line");

var plainTextLoggerInMemory = LoggerFactory.CreateLoggerInMemory(category);
plainTextLoggerInMemory.LogInformation("Log Info in Memory");
plainTextLoggerInMemory.LogInformation("Log Info in Memory second Line");

var xmlLoggerToFile = LoggerFactory.CreateXmlLoggerToFile(category, @".\xmlLogger.xml");
xmlLoggerToFile.LogInformation("Log XML Info to File");
xmlLoggerToFile.LogInformation("Log XML Info to File second line");

var xmlLoggerToFileAndConsole = LoggerFactory.CreateXmlLoggerToFileAndConsole(category, @".\xmlLogger.xml");
xmlLoggerToFileAndConsole.LogInformation("Log XML Info to File and Console");
xmlLoggerToFileAndConsole.LogInformation("Log XML Info to File second line and Console");