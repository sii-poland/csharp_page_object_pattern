using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions.WebDriver;
using AutomationTestSiiFramework.Tests.Shop.Models.User;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Tests.Shop.Pages.OrderProcess
{
    public class OrderAddressFragmentPage : BasePage
    {
        public OrderAddressFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private IWebElement AddressElement => Driver.WaitAndFind(By.Name("address1"));
        private IWebElement CityElement => Driver.WaitAndFind(By.Name("city"));
        private IWebElement StateDropdownElement => Driver.WaitAndFind(By.Name("id_state"));
        private IWebElement PostCodeElement => Driver.WaitAndFind(By.Name("postcode"));
        private IWebElement ConfirmAddressElement => Driver.WaitAndFind(By.Name("confirm-addresses"));

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