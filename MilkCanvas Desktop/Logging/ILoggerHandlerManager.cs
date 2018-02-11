namespace MilkCanvas.Logging
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public interface ILoggerHandlerManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerHandler"></param>
        /// <returns></returns>
        ILoggerHandlerManager AddHandler(ILoggerHandler loggerHandler);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerHandler"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        ILoggerHandlerManager AddHandler(ILoggerHandler loggerHandler, Predicate<LogMessage> filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="loggerHandler"></param>
        /// <returns></returns>
        bool RemoveHandler(ILoggerHandler loggerHandler);
    }
}
