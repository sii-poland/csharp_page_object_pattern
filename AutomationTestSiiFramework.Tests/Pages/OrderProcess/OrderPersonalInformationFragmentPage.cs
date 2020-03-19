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

        private IWebElement FirstName => Driver.FindElement(By.Name("firstname"));
        private IWebElement LastName => Driver.FindElement(By.Name("lastname"));
        private IWebElement Email => Driver.FindElement(By.Name("email"));
        private IEnumerable<IWebElement> SocialTitle => Driver.FindElements(By.CssSelector(".radio-inline input"));
        private IWebElement Continue => Driver.FindElement(By.Name("continue"));

        public OrderAddressFragmentPage FillPersonalInformation(User user)
        {
            Driver.Wait().Until(x => SocialTitle.ToList().Count > 0);
            SelectSocialTitle(user.Gender);
            Driver.SendKeysWithWait(FirstName, user.FirstName);
            Driver.SendKeysWithWait(LastName, user.LastName);
            Driver.SendKeysWithWait(Email, user.Credentials.Email);
            Driver.ClickOnElement(Continue);
            return new OrderAddressFragmentPage(Driver);
        }

        public OrderPersonalInformationFragmentPage SelectSocialTitle(Name.Gender gender)
        {
            SocialTitle.First(x => x.GetValue() == ((int) gender + 1).ToString()).Click();
            return this;
        }
    }
}