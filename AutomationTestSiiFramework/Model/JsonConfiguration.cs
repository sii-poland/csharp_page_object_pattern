namespace AutomationTestSiiFramework.Model
{
    public class JsonConfiguration
    {
        public string ApplicationName { get; set; }
        public string BrowserName { get; set; }
        public string BrowserType { get; set; }
        public string GridUrl { get; set; }
        public string InternetAppUrl { get; set; }
        public string ShopAppUrl { get; set; }
        public string ScreenshotsPath { get; set; }
        public int DefaultTimeout { get; set; }
    }
}