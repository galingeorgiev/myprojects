using System;

namespace VirtualShop
{
    public class InPromotionEventArgs : EventArgs
    {
        private string productName;

        public InPromotionEventArgs(string productName)
        {
            this.productName = productName;
        }

        public string ProductName
        {
            get { return this.productName; }
        }
    }
}
