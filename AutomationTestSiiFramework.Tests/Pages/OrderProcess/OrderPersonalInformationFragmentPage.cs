using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderPersonalInformationFragmentPage : BasePage
    {
        private static By FirstName => By.Name("firstname");
        private static By LastName => By.Name("lastname");
        private static By Email => By.Name("email");
        private static By SocialTitle => By.CssSelector(".radio-inline");
        private static By Continue => By.Name("continue");
        public OrderPersonalInformationFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        public OrderAddressFragmentPage FillPersonalInformation(string firstName, string lastName, string email,
            string socialTitle)
        {
            driver.FindElementsGraterThenZero(SocialTitle).First(x => x.Text == socialTitle).Click();
            driver.SendKeysWithWait(FirstName, firstName);
            driver.SendKeysWithWait(LastName, lastName);
            driver.SendKeysWithWait(Email, email);
            driver.ClickOnElement(Continue);
            return new OrderAddressFragmentPage(driver);
        }
    }
}