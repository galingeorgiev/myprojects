namespace FindProductInRange
{
    using System;

    public class Product : IComparable<Product>
    {
        private string name;
        private int price;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        
        public int CompareTo(Product that)
        {
            if (this.Price > that.Price)
            {
                return 1;
            }
            else if (this.Price < that.Price)
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
            return this.Name + " - " + this.Price;
        }
    }
}
