namespace AutomationTestSiiFramework.Tests.Shop.Models.Order
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public void Add(int quantity)
        {
            Quantity += quantity;
            TotalPrice = Product.Price * Quantity;
        }
    }
}