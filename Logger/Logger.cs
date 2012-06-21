using System;
using System.Diagnostics;

namespace Logger
{
    /// <summary>
    /// Custom simple Logging system
    /// </summary>
    public static class Logger
    {
        private static TextWriterTraceListener tr = new TextWriterTraceListener("application.log");

        /// <summary>
        /// Log application error
        /// </summary>
        /// <param name="message">error message to log</param>
        /// <param name="module">module caused error</param>
        public static void Error(string message, string module)
        {
            WriteEntry(message, "ERROR", module);
        }

        /// <summary>
        /// Log application error
        /// </summary>
        /// <param name="ex">exception to log</param>
        /// <param name="module">module caused error</param>
        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.Message, "ERROR", module);
        }

        /// <summary>
        /// Log application warning
        /// </summary>
        /// <param name="message">warning message to log</param>
        /// <param name="module">module caused warning</param>
        public static void Warning(string message, string module)
        {
            WriteEntry(message, "WARNING", module);
        }

        /// <summary>
        /// Log application info
        /// </summary>
        /// <param name="message">info message to log</param>
        /// <param name="module">module written down info</param>
        public static void Info(string message, string module)
        {
            WriteEntry(message, "Info", module);
        }

        /// <summary>
        /// Common method to store log messages
        /// </summary>
        /// <param name="message">text message</param>
        /// <param name="type">message type</param>
        /// <param name="module">module caused message</param>
        public static void WriteEntry(string message, string type, string module)
        {
            tr.WriteLine(
                string.Format("{0};{1};{2};{3}",
                                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                type,
                                module,
                                message));
            tr.Flush();
        }
    }
}
