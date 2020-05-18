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

namespace AutomationTestSiiFramework.Extensions.WebDriver
{
    public static class ScreenshotExtensions
    {
        public static void TakeFullPageScreenshot(this IWebDriver driver, string fileName)
        {
            driver.SaveScreenshot(fileName, true);
        }

        public static void TakeStandardScreenshot(this IWebDriver driver, string fileName)
        {
            driver.SaveScreenshot(fileName, false);
        }

        private static void SaveScreenshot(this IWebDriver driver, string fileName, bool fullPage)
        {
            try
            {
                var safeFileName = GetSafeFileName(fileName);
                var pathToFile = GetPathToFile(GetSafeFileName(safeFileName));

                if (fullPage)
                {
                    driver.SaveFullPageScreenshot(pathToFile);
                }
                else
                {
                    driver.SaveStandardScreenshot(pathToFile);
                }

                AllureLifecycle.Instance.AddAttachment(pathToFile, safeFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Taking a screenshot failed: {ex.Message}");
            }
        }

        private static void SaveFullPageScreenshot(this IWebDriver driver, string pathToFile)
        {
            var bytesArr = GetBaseDriver(driver).TakeScreenshot(new VerticalCombineDecorator(new ScreenshotMaker()));
            bytesArr.ToMagickImage().Write(pathToFile);
        }

        private static void SaveStandardScreenshot(this IWebDriver driver, string pathToFile)
        {
            var screenshot = ((ITakesScreenshot) GetBaseDriver(driver)).GetScreenshot();
            screenshot.SaveAsFile(pathToFile, ScreenshotImageFormat.Png);
        }

        private static string GetSafeFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars()
                .Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        private static string GetPathToFile(string fileName)
        {
            var path = $"{Configuration.WebDriver.ScreenshotsPath}\\{fileName}{DateTime.Now:HH}";
            Directory.CreateDirectory(path);
            var pathToFile =
                $"{path}\\{GetSafeFileName(DateTime.UtcNow.ToLongTimeString())}_{Thread.CurrentThread.ManagedThreadId}.png";
            return pathToFile;
        }

        private static IWebDriver GetBaseDriver(IWebDriver driver)
        {
            if (driver is WebDriverListener webDriverListener)
            {
                return webDriverListener.WrappedDriver;
            }

            return driver;
        }
    }
}