using System;
using System.Collections.Generic;

class Product
{
    private string name;
    private bool isPromotion;

    public event PromotionEventHandler Promotion;

    public Product(string name, bool isPromotion)
    {
        this.name = name;
        this.isPromotion = isPromotion;
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

    public void CheckForPromotion(IEnumerable<Product> productsList)
    {
        foreach (var product in productsList)
        {
            if (product.isPromotion)
            {
                OnPromotionTypeChanged(product);
            }
        }
    }
}
