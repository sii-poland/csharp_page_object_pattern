using System;
using System.IO;
using System.Linq;
using System.Threading;
using Allure.Commons;
using AutomationTestSiiFramework.Helpers;
using OpenQA.Selenium;
using WDSE;
using WDSE.Decorators;
using WDSE.ScreenshotMaker;

namespace AutomationTestSiiFramework.Extensions
{
    public static class AllureExtensions
    {
        private static string GetCleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars()
                .Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        private static string GetPathToFile(string title)
        {
            var path = $"{Configuration.WebDriver.ScreenshotsPath}\\{title}{DateTime.Now:HH}";
            Directory.CreateDirectory(path);
            var pathToFile =
                $"{path}\\{GetCleanFileName(DateTime.UtcNow.ToLongTimeString())}_{Thread.CurrentThread.ManagedThreadId}.png";
            return pathToFile;
        }

        public static void TakeFullPageScreenshot(this IWebDriver driver, string title)
        {
            driver.SaveScreenshot(title, true);
        }

        public static void TakeStandardScreenshot(this IWebDriver driver, string title)
        {
            driver.SaveScreenshot(title, false);
        }

        private static void SaveScreenshot(this IWebDriver driver, string title, bool fullPage)
        {
            try
            {
                title = GetCleanFileName(title);
                var pathToFile = GetPathToFile(GetCleanFileName(title));

                if (fullPage)
                {
                    driver.SaveFullPageScreenshot(pathToFile);
                }
                else
                {
                    driver.SaveStandardScreenshot(pathToFile);
                }

                AllureLifecycle.Instance.AddAttachment(pathToFile, title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Taking a screenshot failed: {ex.Message}");
            }
        }

        private static void SaveFullPageScreenshot(this IWebDriver driver, string pathToFile)
        {
            var bytesArr = driver.TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            bytesArr.ToMagickImage().Write(pathToFile);
        }

        private static void SaveStandardScreenshot(this IWebDriver driver, string pathToFile)
        {
            var screenshot = ((ITakesScreenshot) driver).GetScreenshot();
            screenshot.SaveAsFile(pathToFile, ScreenshotImageFormat.Png);
        }
    }
}