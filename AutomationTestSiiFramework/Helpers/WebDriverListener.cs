using AutomationTestSiiFramework.Extensions;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace AutomationTestSiiFramework.Helpers
{
    public class WebDriverListener : EventFiringWebDriver
    {
        private readonly IWebDriver _driver;
        private readonly L _logger;

        public WebDriverListener(IWebDriver parentDriver, L logger) : base(parentDriver)
        {
            _driver = parentDriver;
            _logger = logger;
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
            _logger.Info(text);
        }

        private void LogScreenshot(string text)
        {
            _driver.TakeStandardScreenshot(text);
        }
    }
}