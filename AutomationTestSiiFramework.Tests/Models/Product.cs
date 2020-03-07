using System.Globalization;

namespace AutomationTestSiiFramework.Tests.Models
{
    public class Product
    {
        public Product(string name, string price, string description)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        public string Name { get; }

        public string Price { get; }

        public string Description { get; }

        public decimal PriceOnlyValue => decimal.Parse(Price.Replace("$", ""), CultureInfo.InvariantCulture);
    }
}