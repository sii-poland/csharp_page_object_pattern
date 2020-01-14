using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace SiiFramework.Extensions
{
    public static class SeleniumLoggerExtension
    {
        public static List<LogEntry> TakeJsErrors(this IWebDriver driver)
        {
            var logs = driver.Manage().Logs;
            var logEntries = logs.GetLog(LogType.Browser);
            var errorLogs = logEntries.Where(x => x.Level == LogLevel.Severe).ToList();
            if (!errorLogs.Any()) return null;
            return errorLogs;
        }
    }
}