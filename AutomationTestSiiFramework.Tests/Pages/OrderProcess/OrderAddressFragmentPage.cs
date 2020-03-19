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

        private IWebElement AddressElement => Driver.FindElement(By.Name("address1"));
        private IWebElement CityElement => Driver.FindElement(By.Name("city"));
        private IWebElement StateDropdownElement => Driver.FindElement(By.Name("id_state"));
        private IWebElement PostCodeElement => Driver.FindElement(By.Name("postcode"));
        private IWebElement ConfirmAddressElement => Driver.FindElement(By.Name("confirm-addresses"));

        public OrderShippingFragmentPage FillAddresses(Address address)
        {
            Driver.SendKeysWithWait(AddressElement, address.Street);
            Driver.SendKeysWithWait(CityElement, address.City);
            var selectState = new SelectElement(StateDropdownElement);
            selectState.SelectByValue(address.State);
            Driver.SendKeysWithWait(PostCodeElement, address.PostalCode);
            Driver.ClickOnElement(ConfirmAddressElement);
            return new OrderShippingFragmentPage(Driver);
        }
    }
}