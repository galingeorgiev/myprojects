using System;

namespace VirtualShop
{
    public class CreateProduct
    {
        private ProductBuilder productBuilder;

        public void SetProductBuilder(ProductBuilder productBuilder)
        {
            this.productBuilder = productBuilder;
        }

        public Product GetProduct()
        {
            return this.productBuilder.GetProduct();
        }

        public void ConstructProduct(string productName, double productPrice, Category productCategory, bool isPromotion)
        {
            this.productBuilder.CreateNewProduct();
            this.productBuilder.BuildName(productName);
            this.productBuilder.BuildPrice(productPrice);
            this.productBuilder.BuildCategory(productCategory);
            this.productBuilder.BuildIsPromotion(isPromotion);
        }
    }
}
