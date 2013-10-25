/* Your task is to write a program to model the bank system by classes
 * and interfaces. You should identify the classes, interfaces, base
 * classes and abstract actions and implement the calculation of the
 * interest functionality through overridden methods. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    class TestBankSystem
    {
        static void Main()
        {
            //Create new deposit and test functionality
            Deposit testDeposit = new Deposit("Svetlin", "Nakov", CustomerType.Individual, 1500, 1);
            Console.WriteLine("----- Balance after creating account -----");
            Console.WriteLine(testDeposit.Balance); //Print 1500
            testDeposit.DepositMoney(100); // Add money in deposit
            Console.WriteLine("----- Balance after adding 100 -----");
            Console.WriteLine(testDeposit.Balance); //Print 1600
            testDeposit.WithdrawMoney(600); // Withdraw money from deposit
            Console.WriteLine("----- Balance after draw 600 -----");
            Console.WriteLine(testDeposit.Balance); //Print 1000
            Console.WriteLine("----- Interest amount -----");
            Console.WriteLine(testDeposit.InterestAmount(12)); //Calculate interest amount for 12 months with interest rate 1%, print 12
            testDeposit.WithdrawMoney(100); // Withdraw money from deposit
            testDeposit.InterestAmount(15); // Balance is 900 and doesn't have interest
        }
    }
}
