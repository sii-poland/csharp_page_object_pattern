using System.Collections.Generic;
using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.Shop.Models.User;
using Bogus.DataSets;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Shop.Pages.OrderProcess
{
    public class OrderPersonalInformationFragmentPage : BasePage
    {
        public OrderPersonalInformationFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FirstNameElement => Driver.WaitAndFind(By.Name("firstname"));
        private IWebElement LastNameElement => Driver.WaitAndFind(By.Name("lastname"));
        private IWebElement EmailElement => Driver.WaitAndFind(By.Name("email"));

        private IEnumerable<IWebElement> SocialTitleRadioButtons =>
            Driver.FindElementsGraterThenZero(By.CssSelector(".radio-inline input"));

        private IWebElement ContinueButton => Driver.WaitAndFind(By.Name("continue"));

        public OrderAddressFragmentPage FillPersonalInformation(User user)
        {
            SelectSocialTitle(user.Gender);
            Driver.SendKeysWithWait(FirstNameElement, user.FirstName);
            Driver.SendKeysWithWait(LastNameElement, user.LastName);
            Driver.SendKeysWithWait(EmailElement, user.Credentials.Email);
            Driver.ClickOnElement(ContinueButton);
            return new OrderAddressFragmentPage(Driver);
        }

        public OrderPersonalInformationFragmentPage SelectSocialTitle(Name.Gender gender)
        {
            SocialTitleRadioButtons.First(x => x.GetValue() == ((int) gender + 1).ToString()).Click();
            return this;
        }
    }
}