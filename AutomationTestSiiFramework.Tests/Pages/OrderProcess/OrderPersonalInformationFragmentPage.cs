using System.Collections.Generic;
using System.Linq;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Models.User;
using Bogus.DataSets;
using OpenQA.Selenium;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderPersonalInformationFragmentPage : BasePage
    {
        public OrderPersonalInformationFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement FirstNameElement => Driver.FindElement(By.Name("firstname"));
        private IWebElement LastNameElement => Driver.FindElement(By.Name("lastname"));
        private IWebElement EmailElement => Driver.FindElement(By.Name("email"));

        private IEnumerable<IWebElement> SocialTitleRadioButtons =>
            Driver.FindElements(By.CssSelector(".radio-inline input"));

        private IWebElement ContinueButton => Driver.FindElement(By.Name("continue"));

        public OrderAddressFragmentPage FillPersonalInformation(User user)
        {
            Driver.Wait().Until(x => SocialTitleRadioButtons.ToList().Count > 0);
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