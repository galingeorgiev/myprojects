using System;

namespace VirtualShop
{
    public class HomeProductsBuilder : ProductBuilder
    {
        public override void BuildName(string productName)
        {
            product.Name = productName;
        }

        public override void BuildPrice(double productPrice)
        {
            product.Price = productPrice;
        }

        public override void BuildCategory(Category productCategory)
        {
            product.Category = productCategory;
        }

        public override void BuildIsPromotion(bool isPromotion)
        {
            product.IsPromotion = isPromotion;
        }
    }
}
