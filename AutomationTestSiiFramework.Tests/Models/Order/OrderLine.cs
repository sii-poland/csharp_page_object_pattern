namespace AutomationTestSiiFramework.Tests.Models.Order
{
    public class OrderLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }

        public void AddOne()
        {
            Quantity++;
            TotalPrice = Product.Price * Quantity;
        }
    }
}
