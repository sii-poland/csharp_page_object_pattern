using System.Collections.Generic;
using System.Linq;

namespace AutomationTestSiiFramework.Tests.Models.Order
{
    public class OrderDetails
    {
        public OrderDetails()
        {
            Items = new List<OrderLine>();
        }

        public List<OrderLine> Items { get; set; }
        public decimal TotalOrderCost { get; set; }
        public int OrderLinesQuantity => Items.Count;
        public int OrderedItemsQuantity => Items.Sum(item => item.Quantity);

        private bool IsProductAlreadyInBasket(string name)
        {
            return Items.Any(x => x.Product.Name == name);
        }

        public void Add(OrderLine orderLine)
        {
            if (IsProductAlreadyInBasket(orderLine.Product.Name))
            {
                Items.First(item => item.Product.Name == orderLine.Product.Name).Add(orderLine.Quantity);
            }
            else
            {
                Items.Add(orderLine);
            }

            TotalOrderCost = Items.Sum(item => item.TotalPrice);
        }
    }
}