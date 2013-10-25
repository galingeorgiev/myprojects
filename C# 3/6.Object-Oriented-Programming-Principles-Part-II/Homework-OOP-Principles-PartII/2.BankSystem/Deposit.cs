/* Deposit accounts are allowed to deposit and with draw money. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    class Deposit : Account, IDepositMoney, IWithdrawMoney
    {
        public Deposit(string customerFirstName, string customerLastName, CustomerType customerType, double balance, double interestRate)
            : base(customerFirstName, customerLastName, customerType, balance, interestRate)
        {
        }

        /*Deposit accounts have no interest if their balance is positive and less than 1000.*/
        public override double InterestAmount(double numberOfMonths)
        {
            if (this.balance > 0 && this.balance < 1000)
            {
                Console.WriteLine("This account have no interest!");
                return 0;
            }

            return this.interestRate * numberOfMonths;
        }

        public void DepositMoney(double deposit)
        {
            this.balance = this.balance + deposit;
        }

        public void WithdrawMoney(double withdraw)
        {
            this.balance = this.balance - withdraw;
        }
    }
}