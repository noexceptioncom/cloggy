// See https://aka.ms/new-console-template for more information

using Cloggy;

var category = "Category1";
var logger = new LoggerBuilder(category).ToConsole().Build();

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");

var jsonLogger = new LoggerBuilder(category).WithJsonFormat().ToConsole().Build();
jsonLogger.LogInformation("Log info");
jsonLogger.LogError("Log error");
jsonLogger.LogWarning("Log warning");

var plainTextLoggerToFile = new LoggerBuilder(category).ToFile(@".\plainTextLogger.txt").Build();
plainTextLoggerToFile.LogInformation("Log Info to File");
plainTextLoggerToFile.LogInformation("Log Info to File second line");

var jsonLoggerToFile= new LoggerBuilder(category).WithJsonFormat().ToFile(@".\jsonLogger.json").Build();
jsonLoggerToFile.LogInformation("Log Json Info to File");
jsonLoggerToFile.LogInformation("Log Json Info to File second line");

var plainTextLoggerToFileAndConsole = new LoggerBuilder(category).ToFile(@".\plainTextLogger.txt").ToConsole().Build();
plainTextLoggerToFileAndConsole.LogInformation("Log Info to File and Console");
plainTextLoggerToFileAndConsole.LogInformation("Log Info to File and Console second line");

var jsonLoggerToFileAndConsole = new LoggerBuilder(category).WithJsonFormat().ToFile(@".\jsonLogger.json").ToConsole().Build();
jsonLoggerToFileAndConsole.LogInformation("Log Json Info to File and Console");
jsonLoggerToFileAndConsole.LogInformation("Log Json Info to File and Console second line");

var plainTextLoggerInMemory = new LoggerBuilder(category).ToMemory().Build();
plainTextLoggerInMemory.LogInformation("Log Info in Memory");
plainTextLoggerInMemory.LogInformation("Log Info in Memory second Line");

var xmlLoggerToFile = new LoggerBuilder(category).WithXmlFormat().ToFile(@".\xmlLogger.xml").Build();
xmlLoggerToFile.LogInformation("Log XML Info to File");
xmlLoggerToFile.LogInformation("Log XML Info to File second line");

var xmlLoggerToFileAndConsole = new LoggerBuilder(category).WithXmlFormat().ToFile(@".\xmlLogger.xml").ToConsole().Build();
xmlLoggerToFileAndConsole.LogInformation("Log XML Info to File and Console");
xmlLoggerToFileAndConsole.LogInformation("Log XML Info to File second line and Console");