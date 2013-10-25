using System;
using System.Collections.Generic;

class Test
{
    public static void Product_OnPromotionTypeChanged(object sender, InPromotionEventArgs eventArgs)
    {
    }

    static void Main()
    {
        Product testProduct = new Product("alabala", true);
        testProduct.Promotion += Product_OnPromotionTypeChanged;
        List<Product> productsList = new List<Product>();
        productsList.Add(testProduct);

        Console.WriteLine("Call event!");
        testProduct.CheckForPromotion(productsList);
    }
}