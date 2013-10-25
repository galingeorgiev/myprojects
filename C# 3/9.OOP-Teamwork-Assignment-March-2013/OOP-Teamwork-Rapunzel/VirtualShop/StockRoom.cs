using System;
using System.Collections.Generic;

namespace VirtualShop
{
    public class StockRoom
    {
        public static Dictionary<Product, int> ProductList()
        {
            Dictionary<Product, int> productList = new Dictionary<Product, int>();

            ProductBuilder foodProduct1 = new FoodsProductsBuilder();
            CreateProduct newFoodProduct1 = new CreateProduct();
            newFoodProduct1.SetProductBuilder(foodProduct1);
            newFoodProduct1.ConstructProduct("Apple", 2.3, Category.Foods, false);
            Product apple = newFoodProduct1.GetProduct();

            ProductBuilder foodProduct2 = new FoodsProductsBuilder();
            CreateProduct newFoodProduct2 = new CreateProduct();
            newFoodProduct2.SetProductBuilder(foodProduct2);
            newFoodProduct2.ConstructProduct("Pear", 4, Category.Foods, false);
            Product pear = newFoodProduct2.GetProduct();

            ProductBuilder foodProduct3 = new FoodsProductsBuilder();
            CreateProduct newFoodProduct3 = new CreateProduct();
            newFoodProduct3.SetProductBuilder(foodProduct3);
            newFoodProduct3.ConstructProduct("Orange", 7, Category.Foods, false);
            Product orange = newFoodProduct3.GetProduct();

            ProductBuilder foodProduct4 = new FoodsProductsBuilder();
            CreateProduct newFoodProduct4 = new CreateProduct();
            newFoodProduct4.SetProductBuilder(foodProduct4);
            newFoodProduct4.ConstructProduct("Kiwi", 1, Category.Foods, false);
            Product kiwi = newFoodProduct4.GetProduct();

            ProductBuilder drinkProduct1 = new DrinksProductsBuilder();
            CreateProduct newDrinkProduct1 = new CreateProduct();
            newDrinkProduct1.SetProductBuilder(drinkProduct1);
            newDrinkProduct1.ConstructProduct("Beer", 6.4, Category.Drinks, true);
            Product beer = newDrinkProduct1.GetProduct();

            ProductBuilder drinkProduct2 = new DrinksProductsBuilder();
            CreateProduct newDrinkProduct2 = new CreateProduct();
            newDrinkProduct2.SetProductBuilder(drinkProduct2);
            newDrinkProduct2.ConstructProduct("Limonada", 12.4, Category.Drinks, false);
            Product limonada = newDrinkProduct2.GetProduct();

            ProductBuilder drinkProduct3 = new DrinksProductsBuilder();
            CreateProduct newDrinkProduct3 = new CreateProduct();
            newDrinkProduct3.SetProductBuilder(drinkProduct3);
            newDrinkProduct3.ConstructProduct("Voda", 4.95, Category.Drinks, false);
            Product voda = newDrinkProduct3.GetProduct();

            ProductBuilder drinkProduct4 = new DrinksProductsBuilder();
            CreateProduct newDrinkProduct4 = new CreateProduct();
            newDrinkProduct4.SetProductBuilder(drinkProduct4);
            newDrinkProduct4.ConstructProduct("Fanta", 43.25, Category.Drinks, false);
            Product fanta = newDrinkProduct4.GetProduct();

            ProductBuilder homeProduct1 = new HomeProductsBuilder();
            CreateProduct newHomeProduct1 = new CreateProduct();
            newHomeProduct1.SetProductBuilder(homeProduct1);
            newHomeProduct1.ConstructProduct("Chair", 342.3, Category.Home, true);
            Product chair = newHomeProduct1.GetProduct();

            ProductBuilder homeProduct2 = new HomeProductsBuilder();
            CreateProduct newHomeProduct2 = new CreateProduct();
            newHomeProduct2.SetProductBuilder(homeProduct2);
            newHomeProduct2.ConstructProduct("Lamp", 245.3, Category.Home, false);
            Product lamp = newHomeProduct2.GetProduct();

            ProductBuilder homeProduct3 = new HomeProductsBuilder();
            CreateProduct newHomeProduct3 = new CreateProduct();
            newHomeProduct3.SetProductBuilder(homeProduct3);
            newHomeProduct3.ConstructProduct("Buhalka", 3.32, Category.Home, true);
            Product buhalka = newHomeProduct3.GetProduct();

            ProductBuilder homeProduct4 = new HomeProductsBuilder();
            CreateProduct newHomeProduct4 = new CreateProduct();
            newHomeProduct4.SetProductBuilder(homeProduct4);
            newHomeProduct4.ConstructProduct("Vaza", 4.64, Category.Home, false);
            Product vaza = newHomeProduct4.GetProduct();

            ProductBuilder gardenProduct1 = new GardenProductsBuilder();
            CreateProduct newGardenProduct1 = new CreateProduct();
            newGardenProduct1.SetProductBuilder(gardenProduct1);
            newGardenProduct1.ConstructProduct("Lopatka", 92.3, Category.Garden, false);
            Product lopatka = newGardenProduct1.GetProduct();

            ProductBuilder gardenProduct2 = new GardenProductsBuilder();
            CreateProduct newGardenProduct2 = new CreateProduct();
            newGardenProduct2.SetProductBuilder(gardenProduct2);
            newGardenProduct2.ConstructProduct("Basket", 2.35, Category.Garden, false);
            Product basket = newGardenProduct2.GetProduct();

            ProductBuilder gardenProduct3 = new GardenProductsBuilder();
            CreateProduct newGardenProduct3 = new CreateProduct();
            newGardenProduct3.SetProductBuilder(gardenProduct3);
            newGardenProduct3.ConstructProduct("Saksiq", 3.13, Category.Garden, false);
            Product saksiq = newGardenProduct3.GetProduct();

            ProductBuilder gardenProduct4 = new GardenProductsBuilder();
            CreateProduct newGardenProduct4 = new CreateProduct();
            newGardenProduct4.SetProductBuilder(gardenProduct4);
            newGardenProduct4.ConstructProduct("Flowers", 34.4, Category.Garden, false);
            Product flowers = newGardenProduct4.GetProduct();

            productList.Add(apple, 100);
            productList.Add(pear, 120);
            productList.Add(orange, 100);
            productList.Add(kiwi, 100);
            productList.Add(beer, 100);
            productList.Add(limonada, 100);
            productList.Add(voda, 100);
            productList.Add(fanta, 100);
            productList.Add(chair, 100);
            productList.Add(lamp, 100);
            productList.Add(buhalka, 100);
            productList.Add(vaza, 100);
            productList.Add(lopatka, 100);
            productList.Add(basket, 100);
            productList.Add(saksiq, 100);
            productList.Add(flowers, 100);

            return productList;
        }
    }
}
