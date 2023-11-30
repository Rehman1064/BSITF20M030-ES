using System;

abstract class LogHandlerBase
{
    protected LogHandlerBase successor;

    public void SetSuccessor(LogHandlerBase successor)
    {
        this.successor = successor;
    }

    public abstract void HandleLog(LogMessage logMessage);
}

class ConsoleLogger : LogHandlerBase
{
    public override void HandleLog(LogMessage logMessage)
    {
        Console.WriteLine($"Console Logger: {logMessage.LogLevel} - {logMessage.MessageText}");

        if (successor != null)
        {
            successor.HandleLog(logMessage);
        }
    }
}

class FileLogger : LogHandlerBase
{
    public override void HandleLog(LogMessage logMessage)
    {
        if (logMessage.LogLevel == LogLevel.Error || logMessage.LogLevel == LogLevel.Warning)
        {
            Console.WriteLine($"File Logger: {logMessage.LogLevel} - {logMessage.MessageText}");
        }

        if (successor != null)
        {
            successor.HandleLog(logMessage);
        }
    }
}

class LogMessage
{
    public LogLevel LogLevel { get; }
    public string MessageText { get; }

    public LogMessage(LogLevel logLevel, string messageText)
    {
        LogLevel = logLevel;
        MessageText = messageText;
    }
}

enum LogLevel
{
    Info,
    Warning,
    Error
}

class Program
{
    static void Main()
    {
        var consoleLogger = new ConsoleLogger();
        var fileLogger = new FileLogger();
        consoleLogger.SetSuccessor(fileLogger);

        var infoMessage = new LogMessage(LogLevel.Info, "This is an informational message.");
        var warningMessage = new LogMessage(LogLevel.Warning, "This is a warning message.");
        var errorMessage = new LogMessage(LogLevel.Error, "This is an error message.");

        consoleLogger.HandleLog(infoMessage);
        Console.WriteLine();
        consoleLogger.HandleLog(warningMessage);
        Console.WriteLine();
        consoleLogger.HandleLog(errorMessage);
    }
}
