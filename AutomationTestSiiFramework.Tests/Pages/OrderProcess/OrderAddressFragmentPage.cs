using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using AutomationTestSiiFramework.Tests.Models.User;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderAddressFragmentPage : BasePage
    {
        public OrderAddressFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement Address => Driver.FindElement(By.Name("address1"));
        private IWebElement City => Driver.FindElement(By.Name("city"));
        private IWebElement StateDropdown => Driver.FindElement(By.Name("id_state"));
        private IWebElement PostCode => Driver.FindElement(By.Name("postcode"));
        private IWebElement ConfirmAddress => Driver.FindElement(By.Name("confirm-addresses"));

        public OrderShippingFragmentPage FillAddresses(Address address)
        {
            Driver.SendKeysWithWait(Address, address.Street);
            Driver.SendKeysWithWait(City, address.City);
            var selectState = new SelectElement(StateDropdown);
            selectState.SelectByValue(address.State);
            Driver.SendKeysWithWait(PostCode, address.PostalCode);
            Driver.ClickOnElement(ConfirmAddress);
            return new OrderShippingFragmentPage(Driver);
        }
    }
}