using System;
using System.Text;
using Salient.ReflectiveLoggingAdapter;

namespace SOAPI2.Tests
{
    public class FixtureBase
    {
        static FixtureBase()
        {
            LogManager.CreateInnerLogger = (logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
                                           =>
                                           new SimpleDebugAppender(logName, logLevel, showLevel, showDateTime,
                                                                   showLogName, dateTimeFormat);
        }

        #region Nested type: SimpleDebugAppender

        private class SimpleDebugAppender : AbstractAppender
        {
            public SimpleDebugAppender(string logName, LogLevel logLevel, bool showLevel, bool showDateTime,
                                       bool showLogName, string dateTimeFormat)
                : base(logName, logLevel, showLevel, showDateTime, showLogName, dateTimeFormat)
            {
            }

            protected override void WriteInternal(LogLevel level, object message, Exception exception)
            {
                var sb = new StringBuilder();
                FormatOutput(sb, level, message, exception);
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            }
        }

        #endregion
    }
}