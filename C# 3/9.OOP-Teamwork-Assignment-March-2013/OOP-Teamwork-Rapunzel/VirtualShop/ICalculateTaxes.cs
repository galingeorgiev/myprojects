using System;

namespace VirtualShop
{
    interface ICalculateTaxes
    {
        double CalculateTaxes(double taxes);
        double CalculatePriceWithoutTaxes(double taxes);
    }
}
