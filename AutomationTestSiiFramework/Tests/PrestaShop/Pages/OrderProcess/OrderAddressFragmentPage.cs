using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages.OrderProcess
{
    public class OrderAddressFragmentPage : BasePage
    {
        public OrderAddressFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        public By Address => By.Name("address1");
        public By City => By.Name("city");
        public By StateDropdown => By.Name("id_state");
        public By CountryDropdown => By.Name("id_country");

        public By PostCode => By.Name("postcode");

        private By ConfirmAddress => By.Name("confirm-addresses");


        public OrderShippingFragmentPage FillAddresses(string address, string city, string country, string state,
            string postCode)
        {
            driver.SendKeysWithWait(Address, address);
            driver.SendKeysWithWait(City, city);
            var selectCountry = new SelectElement(driver.FindElement(CountryDropdown));
            selectCountry.SelectByText(country);
            var selectState = new SelectElement(driver.FindElement(StateDropdown));
            selectState.SelectByText(state);
            driver.SendKeysWithWait(PostCode, postCode);
            driver.ClickOnElement(ConfirmAddress);
            return new OrderShippingFragmentPage(driver);
        }
    }
}