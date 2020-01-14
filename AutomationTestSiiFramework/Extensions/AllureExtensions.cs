using System;
using System.IO;
using System.Linq;
using Allure.Commons;
using LLibrary;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Extensions
{
    public static class AllureExtensions
    {
        private static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars()
                .Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public static void SaveScreenshot(this IWebDriver driver, string title, L logger)
        {
            string path = null;
            try
            {
                title = CleanFileName(title);
                path = $"{TestSettings.DirectoryPath}\\{title}{DateTime.Now:HH}";
                Directory.CreateDirectory(path);
                var pathToFile = $"{path}\\{CleanFileName(DateTime.UtcNow.ToLongTimeString())}.png";
                var screenshot = ((ITakesScreenshot) driver).GetScreenshot();
                screenshot.SaveAsFile(pathToFile, ScreenshotImageFormat.Png);
                AllureLifecycle.Instance.AddAttachment("name", ".png", pathToFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Taking a screenshot failed: {ex.Message}");
                logger.Error($"Error with screenshot path: {path} title: {title}");
            }
        }
    }
}