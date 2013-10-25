namespace TradeCompanyItems
{
    using System;

    public class Item : IComparable<Item>
    {
        private int barcode;
        private string vendor;
        private string title;
        private int price;

        public Item(int barcode, string vendor, string title, int price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public int Barcode
        {
            get { return this.barcode; }
            set { this.barcode = value; }
        }

        public string Vendor
        {
            get { return this.vendor; }
            set { this.vendor = value; }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        public int CompareTo(Item that)
        {
            if (this.Price.CompareTo(that.Price) == 1)
            {
                return 1;
            }
            else if (this.Price.CompareTo(that.Price) == -1)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return this.Vendor + " " + this.Title + " " + this.Barcode;
        }
    }
}
