using System;
using System.IO;
using System.Linq;
using Allure.Commons;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace AutomationTestSiiFramework.Extensions
{
    public class WebDriverListener : EventFiringWebDriver
    {
        private readonly IWebDriver driver;
        private readonly L logger;

        public WebDriverListener(IWebDriver parentDriver, L logger) : base(parentDriver)
        {
            driver = parentDriver;
            this.logger = logger;
            Navigating += WebDriverListener_Navigating;
            Navigated += WebDriverListener_Navigated;
            FindingElement += WebDriverListener_FindingElement;
            ElementClicking += WebDriverListener_ElementClicking;
            ElementClicked += WebDriverListener_ElementClicked;
            ElementValueChanged += WebDriverListener_ElementValueChanged;
        }

        private void WebDriverListener_Navigating(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogMessage($"Navigating to {e.Url}");
        }

        private void WebDriverListener_ElementClicked(object sender,
            WebElementEventArgs e)
        {
            LogScreenshot($"{e.Element} clicked");
        }

        private void WebDriverListener_ElementClicking(object sender,
            WebElementEventArgs e)
        {
            LogMessage($"Clicking on the {e.Element.TagName} `{e.Element.Text}` {e.Element}");
        }

        private void WebDriverListener_FindingElement(object sender,
            FindElementEventArgs e)
        {
            LogMessage($"Finding element `{e.FindMethod}`");
        }

        private void WebDriverListener_ElementValueChanged(object sender,
            WebElementValueEventArgs e)
        {
            LogScreenshot($"Value of the {e.Element} changed to `{e.Value}`");
        }

        private void WebDriverListener_Navigated(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogScreenshot($"Navigated to [{e.Driver.Title}]({e.Url})");
        }

        private void LogMessage(string text)
        {
            Console.WriteLine(text);
            logger.Info(text);
        }

        private void LogScreenshot(string text)
        {
            SaveScreenshot(text);
        }

        private static string CleanFileName(string fileName)
        {
            return Path.GetInvalidFileNameChars()
                .Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }

        public void SaveScreenshot(string title)
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
                var aa = AllureLifecycle.Instance;
                AllureLifecycle.Instance.AddAttachment(pathToFile, title);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Taking a screenshot failed: {ex.Message}");
                logger.Error($"Error with screenshot path: {path} title: {title}");
            }
        }
    }
}