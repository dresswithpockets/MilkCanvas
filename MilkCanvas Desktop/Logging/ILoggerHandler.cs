namespace MilkCanvas.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILoggerHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logMessage"></param>
        void Publish(LogMessage logMessage);
    }
}