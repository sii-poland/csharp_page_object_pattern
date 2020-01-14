using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Pages.OrderProcess
{
    public class FillAddressFragmentPage : BasePage
    {
        public FillAddressFragmentPage(IWebDriver driver) : base(driver)
        {
        }

        private By Address => By.Name("address1");
        private By City => By.Name("city");
        private By StateDropdown => By.Name("id_state");
        private By CountryDropdown => By.Name("id_country");

        private By PostCode => By.Name("postcode");

        public By ConfirmAddress => By.Name("confirm-addresses");


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