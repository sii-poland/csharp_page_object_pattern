using System;
using AutomationTestSiiFramework.Base;
using AutomationTestSiiFramework.Tests.Models.Order;
using AutomationTestSiiFramework.Tests.Pages;
using AutomationTestSiiFramework.Tests.Pages.Cart;
using FluentAssertions;
using NUnit.Framework;

namespace AutomationTestSiiFramework.Tests.Tests.PrestaShop
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class CalculationsGenericTest : BaseTest
    {
        private static int RandomQuantity => new Random().Next(1, 5);

        private void AddRandomProductToBasket(OrderDetails expectedOrder)
        {
            new HomeShopPage(Driver)
                .Go()
                .ProductsGrid
                .OpenRandomProduct()
                .SetQuantity(RandomQuantity)
                .AddToCart(expectedOrder)
                .ContinueShopping();
        }

        [Test]
        public void Shop_Generic_AddFiveRandomProductsInRandomQuantity_CheckThatInCartIsTheSameContentAsWeExpected()
        {
            const int quantityOfProductsToAdd = 5;
            var expectedOrder = new OrderDetails();
            for (var i = 0; i < quantityOfProductsToAdd; i++)
            {
                AddRandomProductToBasket(expectedOrder);
            }

            var actualOrder = new ShoppingCartPage(Driver)
                .Go()
                .ToOrder();

            actualOrder.Should().BeEquivalentTo(expectedOrder,
                options => options.IncludingNestedObjects());
        }
    }
}