using System.IO;
using AutomationTestSiiFramework.Model;

namespace AutomationTestSiiFramework.Extensions
{
    public class TestSettings
    {
        public static JsonConfiguration ConfigurationJson => JsonConfigurationHelper.GetJsonConfiguration();

        public static string PathToSolution =>
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent?.Parent?.Parent?.FullName;

        public static string DriverPath => $"{PathToSolution}\\AutomationTestSiiFramework\\Drivers";
    }
}