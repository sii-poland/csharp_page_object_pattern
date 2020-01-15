using System.IO;

namespace AutomationTestSiiFramework.Extensions
{
    public class TestSettings
    {
        public static string BrowserName { get; set; }

        public static string PathToSolution =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.Parent?.FullName;

        public static string DriverPath => $"{PathToSolution}\\AutomationTestSiiFramework\\Drivers";

        public static string BrowserType { get; set; }
        public static string GridUrl { get; set; }
        public static int DefaultTimeout { get; set; }
        public static string ScreenshotsPath { get; set; }
        public static string InternetAppUrl { get; set; }
        public static string ShopAppUrl { get; set; }
    }
}