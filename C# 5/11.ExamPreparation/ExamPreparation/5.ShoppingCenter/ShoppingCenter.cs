namespace ShoppingCenter
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using Wintellect.PowerCollections;

    public class Product : IComparable<Product>
    {
        private string name;
        private double price;
        private string producer;

        public Product()
        {
        }

        public Product(string name, double price, string producer)
        {
            this.name = name;
            this.price = price;
            this.producer = producer;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

        public string Producer
        {
            get
            {
                return this.producer;
            }

            set
            {
                this.producer = value;
            }
        }

        public int CompareTo(Product other)
        {
            if (this.name.CompareTo(other.name) < 0)
            {
                return -1;
            }
            else if (this.name.CompareTo(other.name) > 0)
            {
                return 1;
            }
            else
            {
                if (this.producer.CompareTo(other.producer) < 0)
                {
                    return -1;
                }
                else if (this.producer.CompareTo(other.producer) > 0)
                {
                    return 1;
                }
                else
                {
                    if (this.price.CompareTo(other.price) < 0)
                    {
                        return -1;
                    }
                    else if (this.price.CompareTo(other.price) > 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.name, this.producer, this.price);
        }
    }

    public class ShoppingCenter
    {
        private readonly OrderedMultiDictionary<double, Product> productsByPrice = new OrderedMultiDictionary<double, Product>(true);
        private readonly MultiDictionary<string, Product> productsByName = new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByProducer = new MultiDictionary<string, Product>(true);
        private readonly MultiDictionary<string, Product> productsByNameAndProducer = new MultiDictionary<string, Product>(true);

        public void AddProduct(Product product)
        {
            this.productsByPrice.Add(product.Price, product);
            this.productsByName.Add(product.Name, product);
            this.productsByProducer.Add(product.Producer, product);
            this.productsByNameAndProducer.Add(product.Name + product.Producer, product);
        }

        public IEnumerable<Product> FindProductByName(string name)
        {
            var result = this.productsByName[name].OrderBy(x => x);
            return result;
        }

        public IEnumerable<Product> FindProductByProducer(string producer)
        {
            var result = this.productsByProducer[producer].OrderBy(x => x);
            return result;
        }

        public IEnumerable<Product> FindProductByRange(double from, double to)
        {
            var result = this.productsByPrice.Range(from, true, to, true).Values.OrderBy(x => x);
            return result;
        }

        public int DeleteProductByNameAndProducer(string nameAndProducer)
        {
            var result = this.productsByNameAndProducer[nameAndProducer].ToList(); // This is way to make deep copy. If delete ToList() throw exception.
            int deletedProducts = result.Count;

            if (deletedProducts > 0)
            {
                foreach (var product in result)
                {
                    this.RemoveProduct(product);
                }
            }

            return deletedProducts;
        }

        public int DeleteProductByProducer(string producer)
        {
            var result = this.productsByProducer[producer].ToList(); // This is way to make deep copy. If delete ToList() throw exception.
            int deletedProducts = result.Count;

            if (deletedProducts > 0)
            {
                foreach (var product in result)
                {
                    this.RemoveProduct(product);
                }
            }

            return deletedProducts;
        }

        private void RemoveProduct(Product product)
        {
            this.productsByName.Remove(product.Name, product);
            this.productsByProducer.Remove(product.Producer, product);
            this.productsByNameAndProducer.Remove(product.Name + product.Producer, product);
            this.productsByPrice.Remove(product.Price, product);
        }
    }

    public class Program
    {
        public static void Main()
        {
            StringBuilder result = new StringBuilder();
            ShoppingCenter currentShoppingCenter = new ShoppingCenter();
            int numberOfCommands = int.Parse(Console.ReadLine());

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");

            for (int i = 0; i < numberOfCommands; i++)
            {
                string currentLine = Console.ReadLine();
                int commandEnd = currentLine.IndexOf(' ');
                string command = currentLine.Substring(0, commandEnd);
                string commandParams = currentLine.Substring(commandEnd + 1, currentLine.Length - commandEnd - 1).Trim();

                switch (command)
                {
                    case "AddProduct":
                        AddProduct(commandParams, currentShoppingCenter, result);
                        break;
                    case "FindProductsByName":
                        FindProductByName(commandParams, currentShoppingCenter, result);
                        break;
                    case "FindProductsByProducer":
                        FindProductByProducer(commandParams, currentShoppingCenter, result);
                        break;
                    case "DeleteProducts":
                        DeleteProduct(commandParams, currentShoppingCenter, result);
                        break;
                    case "FindProductsByPriceRange":
                        FindProductByPriceRange(commandParams, currentShoppingCenter, result);
                        break;
                }
            }

            Console.WriteLine(result);
        }

        private static void FindProductByPriceRange(string commandParams, ShoppingCenter currentShoppingCenter, StringBuilder result)
        {
            string[] productParams = commandParams.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            double from = double.Parse(productParams[0].Trim(), CultureInfo.InvariantCulture);
            double to = double.Parse(productParams[1].Trim(), CultureInfo.InvariantCulture);
            var products = currentShoppingCenter.FindProductByRange(from, to);

            if (products.Count() > 0)
            {
                foreach (var product in products)
                {
                    result.AppendLine(product.ToString());
                }
            }
            else
            {
                result.AppendLine("No products found");
            }
        }

        private static void DeleteProduct(string commandParams, ShoppingCenter currentShoppingCenter, StringBuilder result)
        {
            string[] deleteParams = commandParams.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            int productsDeleted = 0;

            if (deleteParams.Length == 1)
            {
                productsDeleted = currentShoppingCenter.DeleteProductByProducer(deleteParams[0].Trim());
            }
            else if (deleteParams.Length == 2)
            {
                productsDeleted = currentShoppingCenter.DeleteProductByNameAndProducer(deleteParams[0].Trim() + deleteParams[1].Trim());
            }

            if (productsDeleted > 0)
            {
                result.AppendLine(string.Format("{0} products deleted", productsDeleted));
            }
            else
            {
                result.AppendLine("No products found");
            }
        }

        private static void FindProductByProducer(string commandParams, ShoppingCenter currentShoppingCenter, StringBuilder result)
        {
            var products = currentShoppingCenter.FindProductByProducer(commandParams);

            if (products.Count() > 0)
            {
                foreach (var product in products)
                {
                    result.AppendLine(product.ToString());
                }
            }
            else
            {
                result.AppendLine("No products found");
            }
        }

        private static void FindProductByName(string commandParams, ShoppingCenter currentShoppingCenter, StringBuilder result)
        {
            var products = currentShoppingCenter.FindProductByName(commandParams);

            if (products.Count() > 0)
            {
                foreach (var product in products)
                {
                    result.AppendLine(product.ToString());
                }
            }
            else
            {
                result.AppendLine("No products found");
            }
        }

        private static void AddProduct(string commandParams, ShoppingCenter currentShoppingCenter, StringBuilder result)
        {
            string[] productParams = commandParams.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            string productName = productParams[0].Trim();
            double productPrice = double.Parse(productParams[1].Trim(), CultureInfo.InvariantCulture);
            string productProducer = productParams[2].Trim();
            Product currentProduct = new Product(productName, productPrice, productProducer);
            currentShoppingCenter.AddProduct(currentProduct);
            result.AppendLine("Product added");
        }
    }
}