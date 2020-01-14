using System.Globalization;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Data
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

        public double PriceOnlyValue => double.Parse(Price.Replace("$", ""), CultureInfo.InvariantCulture);
    }
}