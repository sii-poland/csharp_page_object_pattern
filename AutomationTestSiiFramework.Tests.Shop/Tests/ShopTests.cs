using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Tests.Shop.Pages;
using AutomationTestSiiFramework.Tests.Shop.Providers;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationTestSiiFramework.Tests.Shop.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class ShopTests : BaseTest
    {
        [Test]
        public void Shop_AddToCartDefineProduct_CheckThatInDetailsIsTheSameContentAsWeExpected()
        {
            var product = new HomeShopPage(Driver)
                .Go()
                .ProductsGrid
                .OpenProductByName("HUMMINGBIRD TSHIRT")
                .ToProduct();
            product.Price.Should().Be(19.12m);
            product.Name.Should().Be("HUMMINGBIRD TSHIRT");
        }


        [Test]
        public void Shop_AddToCartProductAndFillAWholeForm_CheckValidationAfterAddedOrder()
        {
            var user = UserFactory.RandomUser;
            var orderConfirmationPage = new HomeShopPage(Driver)
                .Go()
                .ProductsGrid.OpenProductByName("HUMMINGBIRD TSHIRT")
                .SetSize("L")
                .SetQuantity(5).AddToCart().ProceedToCheckout().ConfirmProceedToCheckout()
                .FillPersonalInformation(user)
                .FillAddresses(user.Address)
                .FillShippingMethod()
                .FillPaymentMethod("Pay by Check")
                .AcceptTermsOfService()
                .OrderWithObligationToPay();
            orderConfirmationPage.OrderSubtotal.Should().Be("$95.60");
        }
    }
}