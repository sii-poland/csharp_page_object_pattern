using System.Globalization;

namespace AutomationTestSiiFramework.Tests.PrestaShop.Data
{
    public class Order
    {
        private readonly string subtotal;

        public Order(string subtotal)
        {
            this.subtotal = subtotal;
        }

        public double SubtotalOnlyValue => double.Parse(subtotal.Replace("$", ""), CultureInfo.InvariantCulture);
    }
}