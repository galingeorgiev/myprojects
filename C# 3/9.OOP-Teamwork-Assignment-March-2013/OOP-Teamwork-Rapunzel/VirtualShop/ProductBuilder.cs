using System;

namespace VirtualShop
{
    // Builder - abstract interface for creating objects (the product, in this case)
    public abstract class ProductBuilder
    {
        protected Product product;

        public Product GetProduct()
        {
            return this.product;
        }

        public void CreateNewProduct()
        {
            this.product = new Product();
        }

        public abstract void BuildName(string productName);
        public abstract void BuildPrice(double productPrice);
        public abstract void BuildCategory(Category productCategory);
        public abstract void BuildIsPromotion(bool isPromotion);
    }
}
