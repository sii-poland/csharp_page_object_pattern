using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages.OrderProcess
{
    public class OrderPersonalInformationFragmentPage : BasePage
    {
        public OrderPersonalInformationFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        public By FirstName => By.Name("firstname");
        public By LastName => By.Name("lastname");
        public By Email => By.Name("email");
        public By SocialTitle => By.CssSelector(".radio-inline");

        private By Continue => By.Name("continue");

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