/* Loan and mortgage accounts can only deposit money. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.BankSystem
{
    class Mortgage : Account, IDepositMoney
    {
        public Mortgage(string customerFirstName, string customerLastName, CustomerType customerType, double balance, double interestRate)
            : base(customerFirstName, customerLastName, customerType, balance, interestRate)
        {
        }

        /* Mortgage accounts have ½ interest for the first 12 months for
         * companies and no interest for the first 6 months for individuals. */
        public override double InterestAmount(double numberOfMonths)
        {
            if (this.customerType == CustomerType.Company)
            {
                if (numberOfMonths < 12)
                {
                    throw new ApplicationException("Number of monts for mortgage account can not be less from 12 months!");
                }
                else
                {
                    return ((this.interestRate / 2) * 12) + ((numberOfMonths - 12) * this.interestRate);
                }
            }

            if (this.customerType == CustomerType.Individual)
            {
                if (numberOfMonths < 6)
                {
                    throw new ApplicationException("Number of monts for mortgage account can not be less from 6 months!");
                }
                else
                {
                    return this.interestRate * (numberOfMonths - 6);
                }
            }
            else
            {
                throw new ApplicationException("Pleace check and try again!");
            }
        }

        public void DepositMoney(double deposit)
        {
            this.balance = this.balance + deposit;
        }
    }
}
