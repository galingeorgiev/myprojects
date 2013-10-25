using System;
using System.Text;

namespace VirtualShop
{
    public class CustomerIndividual : Customer, ICalculateTaxes
    {
        private long idNumber;

        public long IDNumber
        {
            get
            {
                return this.idNumber;
            }
            set
            {
                string identifier = Convert.ToString(value);
                if (identifier.Length != 6)
                {
                    throw new IncorrectIndividualIDNumberException();
                }
                else
                {
                    this.idNumber = value;
                }
            }
        }

        public CustomerIndividual(string name, long idNumber)
            : base(name, 'i')
        {
            this.IDNumber = idNumber;
        }

        #region METHODS

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Name: " + this.Name);
            str.AppendFormat(", ID Nubmer: " + this.idNumber);
            str.AppendFormat(", Individual client");
            return str.ToString();
        }

        public double CalculateTaxes(double price)
        {
            double priceWithoutTaxes = CalculatePriceWithoutTaxes(price);
            return price - priceWithoutTaxes;
        }

        public double CalculatePriceWithoutTaxes(double price)
        {
            double taxes = 20;
            double priceWithoutTaxes = price / (100 + taxes) * 100;
            return priceWithoutTaxes;
        }

        #endregion

    }
}
