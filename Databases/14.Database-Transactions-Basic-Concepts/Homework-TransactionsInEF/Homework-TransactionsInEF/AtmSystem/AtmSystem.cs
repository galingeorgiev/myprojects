/* Task 1
* Suppose you are creating a simple engine for an ATM machine. Create a new 
* database "ATM" in SQL Server to hold the accounts of the card holders and 
* the balance (money) for each account. Add a new table CardAccounts with the
* following fields: 
* 	 Id (int)
* 	 CardNumber (char(10))
* 	 CardPIN (char(4))
* 	 CardCash (money)
* Add a few sample records in the table.
* 
* !!!!!!!!! Use ATMDB.txt to create database !!!!!!!!!
* 
* Task 2
* Using transactions write a method which retrieves some money (for example $200)
* from certain account. The retrieval is successful when the following sequence of
* sub-operations is completed successfully:
*    - A query checks if the given CardPIN and CardNumber are valid.
*    - The amount on the account (CardCash) is evaluated to see whether it is 
*      bigger than the requested sum (more than $200).
*    - The ATM machine pays the required sum (e.g. $200) and stores in the table
*      CardAccounts the new amount (CardCash = CardCash - 200).
* Why does the isolation level need to be set to “repeatable read”?
* 
* Task 3
* Extend the project from the previous exercise and add a new table TransactionsHistory
* with fields (Id, CardNumber, TransactionDate, Ammount) containing information about 
* all money retrievals on all accounts.
* Modify the program logic so that it saves historical information (logs) in the new 
* table after each successful money withdrawal.
* What should the isolation level be for the transaction?
* 
* !!!!!!!!! CardCash field is changed to 'Concurrency mode - fixed' !!!!!!!!!
*/

namespace AtmSystem
{
    using AtmModel;
    using System;
    using System.Linq;

    public class AtmSystem
    {
        public static void Main()
        {
            Console.WriteLine("Enter you card number (e.g. 4654767567)");
            //string cardNumber = Console.ReadLine();
            string cardNumber = "8765345766";

            Console.WriteLine("Enter PIN");
            //string pin = Console.ReadLine();
            string pin = "2345";

            Console.WriteLine("How much money do you want to retriev.");
            //decimal money = decimal.Parse(Console.ReadLine());
            decimal money = 200m;

            RetrievMoney(cardNumber, pin, money);
        }

        public static void RetrievMoney(string cardNumber, string pin, decimal retrievMoney)
        {
            using (var db = new ATMEntities())
            {
                using (var secondDb = new ATMEntities())
                {
                    var account = (from accounts in db.CardAccounts
                                   where accounts.CardNimber == cardNumber &&
                                         accounts.CardPIN == pin
                                   select accounts).FirstOrDefault();

                    var secondAccount = (from accounts in secondDb.CardAccounts
                                   where accounts.CardNimber == cardNumber &&
                                         accounts.CardPIN == pin
                                   select accounts).FirstOrDefault();

                    if (account == null)
                    {
                        Console.WriteLine("Invalid PIN!\nPlease try again.");
                    }
                    else if (account.CardCash >= retrievMoney)
                    {
                        Nullable<decimal> ammount = account.CardCash - retrievMoney;
                        account.CardCash = ammount;
                        db.SaveChanges();
                        Console.WriteLine("Now you retriev {0} money!", retrievMoney);

                        db.TransactionsHistories.Add(new TransactionsHistory
                        {
                            Ammount = ammount,
                            CardNumber = cardNumber,
                            TransactionDate = DateTime.Now
                        });
                        db.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("You have not enought money in card!");
                    }

                    // Try to uncomment lines below
                    // They will throw exception because we try to change CardCash in secondDb context, but he is changed db context.
                    // !!!!!!!!! CardCash field is changed to 'Concurrency mode - fixed' !!!!!!!!!
                    //secondAccount.CardCash = secondAccount.CardCash - retrievMoney;
                    //secondDb.SaveChanges();
                }
            }
        }
    }
}