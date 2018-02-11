namespace MilkCanvas.Logging.Formatters
{
    public interface ILoggerFormatter
    {
        string ApplyFormat(LogMessage logMessage);
    }
}