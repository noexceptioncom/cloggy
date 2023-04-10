// See https://aka.ms/new-console-template for more information

using Cloggy;
var logger = Logger.CreateLoggerWithDateTime();

logger.LogInformation("Log con fecha");
logger.LogError("Error Log information");
logger.LogWarning("Log warning");

var loggerWithoutDate = Logger.CreateLoggerWithoutDateTime();
loggerWithoutDate.LogInformation("Log simple");

var category = "Category1";
var loggerWithCategory = Logger.CreateLoggerWithCategory(category);
loggerWithCategory.LogInformation("Con categoría y sin fecha.");

var loggerWihtDateTimeAndcategory = Logger.CreateLoggerWithDateTimeAndCategory(category);
loggerWihtDateTimeAndcategory.LogInformation("Con fecha y con categoría");
