using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace VirtualShop
{
    public class DrawConsoleUI
    {
        public static void Product_OnPromotionTypeChanged(object sender, InPromotionEventArgs eventArgs)
        {
        }

        public static void Ads_AdsTypeChanged(object sender, AdsEventArgs eventArgs)
        {
        }

        private static bool isFinished = false;
        private static List<Customer> customers = new List<Customer>();
        private static Dictionary<Product, int> productsInStockRoom = StockRoom.ProductList();
        private static Customer currentCustomer = null;

        public static void DrawConsole(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Product testEventProduct = new Product();
            Ads testEventAds = new Ads();

            while (!isFinished)
            {
                testEventProduct.Promotion += Product_OnPromotionTypeChanged;
                testEventProduct.CheckForPromotion(StockRoom.ProductList());
                DrawBorders(width, height);

                Console.WriteLine(" ****** !!! Advertisements !!! ******");
                testEventAds.AdsEH += Ads_AdsTypeChanged;
                testEventAds.CheckForActiveAds(AdsStock.GetAllAds());
                Console.WriteLine(" ****** !!! Advertisements !!! ******");
                DrawBorders(width, height);

                Console.WriteLine("   You are browsing as {0}", 
                    currentCustomer == null ? "nobody! Register or login." : currentCustomer.Name + ".");
                DrawBorders(width, height);

                DrawMenu(width);
                int choice = DrawSubMenu();
                ShowChoice(choice);

                AskToContinue(); //Gives time to user can read message

                Console.Clear();
            }
        }

        private static void DrawBorders(int width, int height)
        {
            //Top and bottom borders
            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
        }

        private static void DrawMenu(int width)
        {
            List<string> menus = new List<string>()
            {
                "Create new client - enter 1",
                "Log In (Choose customer) - enter 2",
                "Add new product in basket - enter 3",
                "Calculation and Taxes - enter 4",
                "Confirm - enter 5",
                "Log Out - enter 6",
                "End - enter 7"
            };

            for (int i = 0; i < menus.Count; i++)
            {
                Console.WriteLine(menus[i]);
            }

            for (int i = 0; i < width; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private static int DrawSubMenu()
        {
            Console.Write("Choose menu: ");
            int choice = 0;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Choose menu: ");
            }
            return choice;
        }

        private static void ShowChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    MenuCreateClient();
                    break;
                case 2:
                    ChooseCustomer();
                    break;
                case 3:
                    AddProductsInBasket();
                    break;
                case 4:
                    CalculateTaxes();
                    break;
                case 5:
                    ConfirmPurchase();
                    break;
                case 6:
                    LogOut();
                    break;
                case 7:
                    End();
                    break;
                default:
                    break;
            }
        }

        #region MENUS

        //First menu
        private static void MenuCreateClient()
        {
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            Console.WriteLine("If you are individual client type 'y'. Otherwise you will be a corporate client.");
            string type = Console.ReadLine();
            Random id = new Random();
            if (type == "y")
            {
                customers.Add(new CustomerIndividual(customerName, id.Next(100000, 999999)));
            }
            else
            {
                customers.Add(new CustomerCorporate(customerName, id.Next(100000, 999999)));
            }
            
            Console.WriteLine("New customer with name {0} is created!", customerName);
        }

        //Second Choose customer menu
        private static void ChooseCustomer()
        {
            if (currentCustomer == null)
            {
                if (customers.Count == 0)
                {
                    Console.WriteLine("\r\nNo registered clients found!\r\nPlease create a new one.\r\n");
                    MenuCreateClient();
                }
                if (customers.Count == 1)
                {
                    currentCustomer = customers[0];
                }
                else
                {
                    Console.WriteLine("Choose customer's number.");
                    int i = 0;
                    foreach (var customer in customers)
                    {
                        Console.WriteLine("| {0} for {1} | ", i, customers[i]);
                        i++;
                    }

                    //Check for correct customer number
                    int customerNumber = -1;
                    bool isNumber = int.TryParse(Console.ReadLine(), out customerNumber);
                    bool isNumberCorrect = customerNumber >= 0 & customerNumber < customers.Count;
                    do
                    {
                        if (isNumberCorrect)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Choose correct customer's number.");
                            isNumber = int.TryParse(Console.ReadLine(), out customerNumber);
                        }
                        isNumberCorrect = customerNumber >= 0 & customerNumber < customers.Count;
                    }
                    while (isNumber & !isNumberCorrect);
                    currentCustomer = customers[customerNumber];
                }

                Console.WriteLine("You are browsing as {0}.\r\n", currentCustomer.Name);
            }
        }

        //Third menu
        private static void AddProductsInBasket()
        {
            if (customers.Count == 0)
            {
                MenuCreateClient();
            }
            Console.WriteLine();

            ChooseCustomer();

            //Printing products list
            Console.WriteLine("Select product from the list, press enter to purchase: ");
            for (int i = 0; i < StockRoom.ProductList().Count; i++)
            {
                var prod = productsInStockRoom.ElementAt(i);
                Console.WriteLine("Press {0} for: {1} In stock {2}", Convert.ToString(i).PadRight(3), Convert.ToString(prod.Key).PadRight(10), Convert.ToString(prod.Value).PadRight(10));
            }
            Console.WriteLine();

            //Picking products from product list
            Console.WriteLine("Plese select products to buy. Enter symbol different than number to stop.");
            bool isPicking = true;
            do
            {
                int productID, productCount;
                Console.WriteLine("Select Product:");
                if (int.TryParse(Console.ReadLine(), out productID))
                {
                    Console.WriteLine("How much do you want?");
                    if (int.TryParse(Console.ReadLine(), out productCount))
                    {
                        var prod = productsInStockRoom.ElementAt(productID);
                        if (productCount <= productsInStockRoom[prod.Key])
                        {
                            currentCustomer.AddProduct(prod.Key, productCount);
                            productsInStockRoom[prod.Key] -= productCount;
                            Console.WriteLine("Product added!");
                        }
                        else
                        {
                            Console.WriteLine("Not enough {0}s in stock", prod.Key.Name);
                        }
                    }
                    else
                    {
                        isPicking = false;
                    }
                }
                else
                {
                    isPicking = false;
                }
            }
            while (isPicking);

            //Printing elements in shoping basket
            Console.WriteLine("Products in basket: ");
            foreach (var product in currentCustomer.CurrentClientBasket)
            {
                Console.WriteLine("{0} {1}s of price {2:c2}", product.Value, product.Key.Name.ToLower(), product.Key.Price);
            }
        }

        //Fourth menu
        private static void CalculateTaxes()
        {
            if (customers.Count == 0)
            {
                Console.WriteLine("First you should buy products!");
                AddProductsInBasket();
            }
            else
            {
                bool isBasketEmpty = true;
                foreach (var client in customers)
                {
                    if (client.CurrentClientBasket.Count > 0)
                    {
                        isBasketEmpty = false;
                        break;
                    }
                }
                if (isBasketEmpty)
                {
                    Console.WriteLine("First you should buy products!");
                    AddProductsInBasket();
                }
            }

            ChooseCustomer();
            Console.WriteLine();
            if (currentCustomer is CustomerIndividual)
            {
                CustomerIndividual currentIndividualCustomer = currentCustomer as CustomerIndividual;

                double totalPrice = 0;
                double fullPrice = 0;

                double totalTaxes = 0;
                double taxes = 0;                

                double totalPriceWithoutTaxes = 0;
                double priceWithoutTaxes = 0;                
                

                foreach (var product in currentCustomer.CurrentClientBasket)
                {
                    totalPrice = product.Key.Price * product.Value;
                    fullPrice += totalPrice;

                    totalPriceWithoutTaxes = currentIndividualCustomer.CalculatePriceWithoutTaxes(totalPrice);
                    priceWithoutTaxes += totalPriceWithoutTaxes;

                    totalTaxes = currentIndividualCustomer.CalculateTaxes(totalPrice);
                    taxes += totalTaxes;

                    totalPrice = 0;
                    totalPriceWithoutTaxes = 0;
                    totalTaxes = 0;
                }
                
                Console.WriteLine("Price: {0:c2} | Taxes: {1:c2} | Total: {2:c2}",
                    priceWithoutTaxes, taxes, fullPrice);
            }
            else
            {
                double fullPrice = 0;
                CustomerCorporate currentCorporateCustomer = currentCustomer as CustomerCorporate;
                foreach (var product in currentCustomer.CurrentClientBasket)
                {
                    fullPrice = fullPrice + (product.Key.Price * product.Value);
                }
                double taxes = currentCorporateCustomer.CalculateTaxes(fullPrice);
                double priceWithoutTaxes = currentCorporateCustomer.CalculatePriceWithoutTaxes(fullPrice);
                Console.WriteLine("Price: {0:c2} | Taxes: {1:c2} | Total: {2:c2}",
                    taxes, priceWithoutTaxes, fullPrice);
            }
            Console.WriteLine();
        }

        //Fifth menu
        private static void ConfirmPurchase()
        {
            CalculateTaxes();

            ChooseCustomer();

            currentCustomer.ConfirmPurchases();
            Console.WriteLine("We have sent you a mail with information about your purchases!");
            Console.WriteLine();
        }

        //Sixth LOG OUT menu
        private static void LogOut()
        {
            if (currentCustomer == null)
            {
                Console.WriteLine("You were't logged in!");
            }
            else
            {
                currentCustomer = null;
                Console.WriteLine("\r\nLog out SUCCESFUL!\r\n");
            }
        }

        //Seventh End menu
        private static void End()
        {
            isFinished = true;

            Console.WriteLine("\r\nGood bye!");
            Console.WriteLine();
        }

        #endregion

        private static void AskToContinue()
        {
            Console.WriteLine("Press 'Enter' to continue!");
            string choice = Console.ReadLine();
        }
    }
}