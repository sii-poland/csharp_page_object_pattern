namespace AutomationTestSiiFramework.Models
{
    public class WebDriverConfiguration
    {
        public Browser BrowserName { get; set; }
        public BrowserType BrowserType { get; set; }
        public bool Headless { get; set; }
        public string GridUrl { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
        public string BrowserLanguage { get; set; }
    }
}