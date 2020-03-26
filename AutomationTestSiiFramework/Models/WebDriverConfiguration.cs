namespace AutomationTestSiiFramework.Models
{
    public class WebDriverConfiguration
    {
        public string BrowserName { get; set; }
        public string BrowserType { get; set; }
        public bool Headless { get; set; }
        public string GridUrl { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
    }
}