using System.IO;
using Microsoft.Extensions.Configuration;

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
        public static double DefaultTimeout { get; } = 5;
        public static string DirectoryPath { get; }  
        public static string InternetAppUrl { get; set; }
        public static string ShopAppUrl { get; set; }
    }
}