using System;
using System.IO;
using System.Linq;
using Allure.Commons;
using LLibrary;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;

namespace SiiFramework.Extensions
{
    public class WebDriverListener : EventFiringWebDriver
    {
        private readonly L logger;

        public WebDriverListener(IWebDriver parentDriver, L logger) : base(parentDriver)
        {
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
            LogMessage($"{e.Element} clicked");
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
            LogMessage($"Value of the {e.Element} changed to `{e.Value}`");
        }

        private void WebDriverListener_Navigated(object sender,
            WebDriverNavigationEventArgs e)
        {
            LogMessage($"Navigated to [{e.Driver.Title}]({e.Url})");
        }

        private void LogMessage(string text)
        {
            Console.WriteLine(text);
            logger.Info(text);
        }

    }
}