namespace SiiFramework.ExampleTest.PrestaShop.Data
{
    public class Product
    {
        private string name;
        private string price;
        private string description;

        public string Name => name;

        public string Price => price;
        public string Description => description;

        public Product(string name, string  price, string description)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }
    }
}