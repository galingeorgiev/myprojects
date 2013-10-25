/* Write a program to read a large collection of products (name + price) 
 * and efficiently find the first 20 products in the price range [a…b]. 
 * Test for 500 000 products and 10 000 price searches.
 * Hint: you may use OrderedBag<T> and sub-ranges.
 */

namespace FindProductInRange
{
    using System;
    using Wintellect.PowerCollections;

    public class FindProductInRange
    {
        public static void Main()
        {
            OrderedBag<Product> products = new OrderedBag<Product>();

            Random priceGenerator = new Random();
            int numberofProducts = 500000;

            for (int i = 0; i < numberofProducts; i++)
            {
                Product testProduct = new Product();
                testProduct.Price = priceGenerator.Next(1, int.MaxValue);
                testProduct.Name = "product" + i;
                products.Add(testProduct);
            }

            Console.WriteLine("{0} products added in bag.", numberofProducts);

            Product firstProduct = new Product();
            firstProduct.Price = 10;
            Product secondProduct = new Product();
            secondProduct.Price = int.MaxValue / 10;
            var productsInRange = products.Range(firstProduct, true, secondProduct, true);

            Console.WriteLine("First 20 products in range {0} - {1}", firstProduct.Price, secondProduct.Price);
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(productsInRange[i]);
            }

            Console.WriteLine("\nProducts in range {0} - {1}", firstProduct.Price, secondProduct.Price);
            var productsInBigRange = products.Range(firstProduct, true, secondProduct, true);
            Console.WriteLine("{0} products are found.", productsInBigRange.Count);
        }
    }
}
