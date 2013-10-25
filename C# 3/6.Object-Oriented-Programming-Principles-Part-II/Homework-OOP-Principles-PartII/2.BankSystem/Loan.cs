/* Loan and mortgage accounts can only deposit money. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    class Loan : Account, IDepositMoney
    {
        public Loan(string customerFirstName, string customerLastName, CustomerType customerType, double balance, double interestRate)
            : base(customerFirstName, customerLastName, customerType, balance, interestRate)
        {
        }

        /* Loan accounts have no interest for the first 3 monthsif are held
         * by individuals and for the first 2 months if are held by a company. */
        public override double InterestAmount(double numberOfMonths)
        {
            if (this.customerType == CustomerType.Individual)
            {
                numberOfMonths = numberOfMonths - 3; // 3 is number months without interest
            }

            if (this.customerType == CustomerType.Company)
            {
                numberOfMonths = numberOfMonths - 2; // 2 is number months without interest
            }

            if (numberOfMonths <= 0)
            {
                throw new ApplicationException("You period is less or equal from 0!");
            }

            return numberOfMonths * this.interestRate;
        }


        public void DepositMoney(double deposit)
        {
            this.balance = this.balance + deposit;
        }
    }
}
