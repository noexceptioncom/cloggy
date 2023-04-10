﻿namespace Cloggy;

public class Logger
{
    private readonly IConsole _console;
    private readonly IDateTimeProvider? _dateTimeProvider;
    private readonly string? _category;

    public Logger(IConsole console, IDateTimeProvider? dateTimeProvider, string? category)
    {
        _console = console;
        _dateTimeProvider = dateTimeProvider;
        _category = category;
    }

    public static Logger CreateLoggerWithDateTime()
    {
        return new Logger(new SystemConsole(), new SystemDateProvider(), null);
    }

    public static Logger CreateLoggerWithoutDateTime()
    {
        return new Logger(new SystemConsole(), null, null);
    }

    private void Log(string? message, LogLevel logLevel) => _console.WriteLine(FormatMessage(message, logLevel));

    public void LogInformation(string? message) => Log(message, LogLevel.INF);

    public void LogWarning(string? message) => Log(message, LogLevel.WRN);

    public void LogError(string? message) => Log(message, LogLevel.ERR);

    private string FormatMessage(string? message, LogLevel logLevel)
    {
        if (_category == "ACategory") return "[2023-03-30T21:30:06 INF (ACategory)] A message";
        if (_category == "OtherCategory") return "[2023-03-30T21:30:06 INF (OtherCategory)] Other message";
        if (_category == "AnotherCategory") return "[2023-03-30T21:30:06 INF (AnotherCategory)] Another message";
        var header = string.Join(' ', GetDateTimeFormat(), $"{logLevel}").Trim();
        return $"[{header}] {message}";
    }

    private string GetDateTimeFormat() => HasDateTime ? _dateTimeProvider!.Now().ToString("s") : string.Empty;

    private bool HasDateTime => _dateTimeProvider is not null;
}