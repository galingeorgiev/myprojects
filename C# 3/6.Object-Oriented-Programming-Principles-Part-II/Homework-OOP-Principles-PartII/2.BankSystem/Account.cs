/* All accounts have customer, balance and interest rate (monthly based).
 * All accounts can calculate their interest amount for a given period (in months).
 * In the common case its is calculated as follows: number_of_months * interest_rate. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    public abstract class Account
    {
        private string customerFirstName;
        private string customerLastName;
        protected CustomerType customerType;
        protected double balance;
        protected double interestRate;

        public Account(string customerFirstName, string customerLastName, CustomerType customerType, double balance, double interestRate)
        {
            this.customerFirstName = customerFirstName;
            this.customerLastName = customerLastName;
            this.customerType = customerType;
            this.balance = balance;
            this.interestRate = interestRate;
        }

        public string CustomerFirstName
        {
            get { return this.customerFirstName; }
        }

        public string CustomerLastName
        {
            get { return this.customerLastName; }
        }

        public CustomerType CustomerType
        {
            get { return this.customerType; }
        }

        public double Balance
        {
            get { return this.balance; }
        }

        public double InterestRate
        {
            get { return this.interestRate; }
        }

        public abstract double InterestAmount(double numberOfMonths);
    }
}
