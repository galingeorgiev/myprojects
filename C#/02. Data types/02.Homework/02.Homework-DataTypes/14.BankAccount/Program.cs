using System;

namespace _14.BankAccount
{
    class Program
    {
        static void Main()
        {
            string customerFirstName;
            string customerMiddleName;
            string customerLastName;
            decimal moneyBalance = 0M;
            string bankName;
            //For IBAN and BIC code we may use char array.
            string IBAN = "BG00 XXXX 0000 0000 0000 00";
            string bicCode = "XXXXXXXX";
            //Lenght of credit cards numbers is between 12 and 19 digits.
            ulong creditCardNumber = 1234567890123456789u;
        }
    }
}
