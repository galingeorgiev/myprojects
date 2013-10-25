using System;
using System.Collections.Generic;

namespace VirtualShop
{
    public class Product
    {
        private Category category;
        private double price;
        private string name;
        private bool isPromotion;
        private ExpirationDate expirationDate;

        public event PromotionEventHandler Promotion;

        public Product()
        {
        }

        public Product(string name, double price, Category category)
        {
            this.name = name;
            this.price = price;
            this.category = category;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public Category Category
        {
            get { return this.category; }
            set { this.category = value; }
        }

        public bool IsPromotion
        {
            get { return this.isPromotion; }
            set { this.isPromotion = value; }
        }

        public ExpirationDate ExpirationDate
        {
            get { return this.expirationDate; }
            set { this.expirationDate = value; }
        }

        public override string ToString()
        {
            return string.Format("Product information | Name: {0} | Price: {1:c2} | Category: {2} | ", this.Name.PadRight(8), Convert.ToString(this.Price).PadRight(5), Convert.ToString(this.Category).PadRight(7));
        }

        protected void OnPromotionTypeChanged(Product product)
        {
            if (Promotion != null)
            {
                Console.WriteLine("Product {0} is in promotion: {1}", product.name, product.isPromotion);
                InPromotionEventArgs args = new InPromotionEventArgs(product.name);
                Promotion(this, args);
            }
        }

        public void CheckForPromotion(Dictionary<Product, int> productsList)
        {
            foreach (var product in productsList)
            {
                if (product.Key.isPromotion)
                {
                    OnPromotionTypeChanged(product.Key);
                }
            }
        }
    }
}
