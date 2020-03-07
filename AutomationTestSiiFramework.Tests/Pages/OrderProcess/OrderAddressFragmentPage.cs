using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Tests.Pages.OrderProcess
{
    public class OrderAddressFragmentPage : BasePage
    {
        private static By Address => By.Name("address1");
        private static By City => By.Name("city");
        private static By StateDropdown => By.Name("id_state");
        private static By CountryDropdown => By.Name("id_country");
        private static By PostCode => By.Name("postcode");
        private static By ConfirmAddress => By.Name("confirm-addresses");
        public OrderAddressFragmentPage(IWebDriver driver) : base(driver)
        {
        }

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