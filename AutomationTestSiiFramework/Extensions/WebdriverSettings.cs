using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AutomationTestSiiFramework.Extensions
{
    public class WebdriverSettings
    {
        public static ChromeOptions ChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddAdditionalCapability("useAutomationExtension", false);
            chromeOptions.AddExcludedArgument("enable-automation");
            chromeOptions.AddArgument("--disable-save-password-bubble");
            chromeOptions.AddArgument("ignore-certificate-errors");
            chromeOptions.AddArgument("start-maximized");
            return chromeOptions;
        }

        public static FirefoxOptions FirefoxOptions()
        {
            return new FirefoxOptions {AcceptInsecureCertificates = true};
        }

        public static InternetExplorerOptions InternetExplorerOptions()
        {
            return new InternetExplorerOptions
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                IgnoreZoomLevel = true
            };
        }

        public static EdgeOptions EdgeOptions()
        {
            return new EdgeOptions {PageLoadStrategy = PageLoadStrategy.Normal};
        }

        public static EdgeDriverService GetEdgeDriverService()
        {
            var driverService =
                EdgeDriverService.CreateDefaultService("C:\\Windows\\SysWOW64\\", "MicrosoftWebDriver.exe", 52296);
            driverService.HideCommandPromptWindow = true;
            driverService.SuppressInitialDiagnosticInformation = true;
            return driverService;
        }

        public static FirefoxDriverService GetFirefoxService()
        {
            var geckoService = FirefoxDriverService.CreateDefaultService(TestSettings.DriverPath);
            geckoService.Host = "::1";
            return geckoService;
        }
    }
}