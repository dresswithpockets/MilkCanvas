namespace MilkCanvas
{

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using MilkCanvas.Logging;
    using MilkCanvas.Logging.Handlers;
    using MilkCanvas.Logging.Module;

    /// <summary>
    /// The logger utility class. Handles advanced logging with full stack traces and proper module-based log handling.
    /// </summary>
    public static class Logger
    {
        private static readonly LogPublisher logPublisher;
        private static readonly ModuleManager moduleManager;
        private static readonly DebugLogger debugLogger;

        private static readonly object sync = new object();
        private static Level defaultLevel = Level.Info;
        private static bool isTurned = true;
        private static bool isTurnedDebug = true;

        static Logger()
        {
            lock (sync)
            {
                logPublisher = new LogPublisher();
                moduleManager = new ModuleManager();
                debugLogger = new DebugLogger();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static IEnumerable<LogMessage> Messages
        {
            get { return logPublisher.Messages; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static DebugLogger Debug
        {
            get { return debugLogger; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ModuleManager Modules
        {
            get { return moduleManager; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool StoreLogMessages
        {
            get { return logPublisher.StoreLogMessages; }
            set { logPublisher.StoreLogMessages = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DefaultInitialization()
        {
            LoggerHandlerManager
                .AddHandler(new ConsoleLoggerHandler())
                .AddHandler(new FileLoggerHandler());

            Log(Level.Info, "Default initialization");
        }

        /// <summary>
        /// 
        /// </summary>
        public static Level DefaultLevel
        {
            get { return defaultLevel; }
            set { defaultLevel = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ILoggerHandlerManager LoggerHandlerManager
        {
            get { return logPublisher; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Log()
        {
            Log("There is no message");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public static void Log(string message)
        {
            Log(defaultLevel, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public static void Log(Level level, string message)
        {
            var stackFrame = FindStackFrame();
            var methodBase = GetCallingMethodBase(stackFrame);
            var callingMethod = methodBase.Name;
            var callingClass = methodBase.ReflectedType.Name;
            var lineNumber = stackFrame.GetFileLineNumber();

            Log(level, message, callingClass, callingMethod, lineNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception"></param>
        public static void Log(Exception exception)
        {
            Log(Level.Error, exception.Message);
            moduleManager.ExceptionLog(exception);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="exception"></param>
        public static void Log<TClass>(Exception exception) where TClass : class
        {
            var message = string.Format("Log exception -> Message: {0}\nStackTrace: {1}", exception.Message,
                                    exception.StackTrace);
            Log<TClass>(Level.Error, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="message"></param>
        public static void Log<TClass>(string message) where TClass : class
        {
            Log<TClass>(defaultLevel, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TClass"></typeparam>
        /// <param name="level"></param>
        /// <param name="message"></param>
        public static void Log<TClass>(Level level, string message) where TClass : class
        {
            var stackFrame = FindStackFrame();
            var methodBase = GetCallingMethodBase(stackFrame);
            var callingMethod = methodBase.Name;
            var callingClass = typeof(TClass).Name;
            var lineNumber = stackFrame.GetFileLineNumber();

            Log(level, message, callingClass, callingMethod, lineNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <param name="message"></param>
        /// <param name="callingClass"></param>
        /// <param name="callingMethod"></param>
        /// <param name="lineNumber"></param>
        private static void Log(Level level, string message, string callingClass, string callingMethod, int lineNumber)
        {
            if (!isTurned || (!isTurnedDebug && level == Level.Debug))
                return;

            var currentDateTime = DateTime.Now;

            moduleManager.BeforeLog();
            var logMessage = new LogMessage(level, message, currentDateTime, callingClass, callingMethod, lineNumber);
            logPublisher.Publish(logMessage);
            moduleManager.AfterLog(logMessage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stackFrame"></param>
        /// <returns></returns>
        private static MethodBase GetCallingMethodBase(StackFrame stackFrame)
        {
            return stackFrame == null
                ? MethodBase.GetCurrentMethod() : stackFrame.GetMethod();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static StackFrame FindStackFrame()
        {
            var stackTrace = new StackTrace();
            for (var i = 0; i < stackTrace.GetFrames().Count(); i++)
            {
                var methodBase = stackTrace.GetFrame(i).GetMethod();
                var name = MethodBase.GetCurrentMethod().Name;
                if (!methodBase.Name.Equals("Log") && !methodBase.Name.Equals(name))
                    return new StackFrame(i, true);
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void On()
        {
            isTurned = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Off()
        {
            isTurned = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DebugOn()
        {
            isTurnedDebug = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DebugOff()
        {
            isTurnedDebug = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public enum Level
        {
            /// <summary>
            /// There is no preference for how a logged should be treated.
            /// </summary>
            None,

            /// <summary>
            /// The logged message is relevent to debugging.
            /// </summary>
            Debug,

            /// <summary>
            /// The logged message is informative or not erroneous.
            /// </summary>
            Fine,

            /// <summary>
            /// The logged message is informative or not erroneos.
            /// </summary>
            Info,

            /// <summary>
            /// The logged message is warning about a possible warning, deprecated features, some issue, or other.
            /// </summary>
            Warning,

            /// <summary>
            /// The logged message indicates an error has occured.
            /// </summary>
            Error,

            /// <summary>
            /// The logged message indicates a severe error has occured.
            /// </summary>
            Severe,

            /// <summary>
            /// The logged message indicates a fatal error has occured. Its expected that the program will cease
            /// execution after a fatal message occurs.
            /// </summary>
            Fatal,
        }

        /// <summary>
        /// 
        /// </summary>
        public static class FilterPredicates
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="logMessLevel"></param>
            /// <param name="filterLevel"></param>
            /// <returns></returns>
            public static bool ByLevelHigher(Level logMessLevel, Level filterLevel)
            {
                return ((int)logMessLevel >= (int)filterLevel);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="logMessLevel"></param>
            /// <param name="filterLevel"></param>
            /// <returns></returns>
            public static bool ByLevelLower(Level logMessLevel, Level filterLevel)
            {
                return ((int)logMessLevel <= (int)filterLevel);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="logMessLevel"></param>
            /// <param name="filterLevel"></param>
            /// <returns></returns>
            public static bool ByLevelExactly(Level logMessLevel, Level filterLevel)
            {
                return ((int)logMessLevel == (int)filterLevel);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="logMessage"></param>
            /// <param name="filterLevel"></param>
            /// <param name="filterPred"></param>
            /// <returns></returns>
            public static bool ByLevel(LogMessage logMessage, Level filterLevel, Func<Level, Level, bool> filterPred)
            {
                return filterPred(logMessage.Level, filterLevel);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public class FilterByLevel
        {
            /// <summary>
            /// 
            /// </summary>
            public Level FilteredLevel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public bool ExactlyLevel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public bool OnlyHigherLevel { get; set; }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="level"></param>
            public FilterByLevel(Level level)
            {
                FilteredLevel = level;
                ExactlyLevel = true;
                OnlyHigherLevel = true;
            }

            /// <summary>
            /// 
            /// </summary>
            public FilterByLevel()
            {
                ExactlyLevel = false;
                OnlyHigherLevel = true;
            }

            /// <summary>
            /// 
            /// </summary>
            public Predicate<LogMessage> Filter
            {
                get
                {
                    return delegate (LogMessage logMessage)
                    {
                        return FilterPredicates.ByLevel(logMessage, FilteredLevel, delegate (Level lm, Level fl)
                        {
                            return ExactlyLevel ?
                                FilterPredicates.ByLevelExactly(lm, fl) :
                                (OnlyHigherLevel ?
                                    FilterPredicates.ByLevelHigher(lm, fl) :
                                    FilterPredicates.ByLevelLower(lm, fl)
                                );
                        });
                    };
                }
            }
        }
    }
}