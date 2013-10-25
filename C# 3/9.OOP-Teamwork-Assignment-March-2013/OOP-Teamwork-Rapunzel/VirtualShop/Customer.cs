using System;
using System.Collections.Generic;

namespace VirtualShop
{
    public abstract class Customer
    {
        #region FIELDS

        private string name;
        private Dictionary<Product, int> currentClientBasket;
        private Dictionary<Product, int> clientBasketHistory;
        private char type;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public char Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public Dictionary<Product, int> CurrentClientBasket
        {
            get { return this.currentClientBasket; }
            private set { }
        }

        public Dictionary<Product, int> ClientBasketHistory
        {
            get { return this.clientBasketHistory; }
            private set { }
        }

        #endregion

        #region CONSTRUCTORS

        public Customer(string name, char type)
        {
            this.name = name;
            this.type = type;
            this.clientBasketHistory = new Dictionary<Product, int>();
            this.currentClientBasket = new Dictionary<Product, int>();
        }

        //New client categories: Individual client and Corporate client

        #endregion

        #region METHODS

        //Add product in basket
        public void AddProduct(Product product, int count)
        {
            this.currentClientBasket.Add(product, count);
        }

        //Confirm purchase
        public void ConfirmPurchases()
        {
            foreach (var prod in currentClientBasket)
            {
                this.clientBasketHistory.Add(prod.Key, prod.Value);
            }
            this.currentClientBasket.Clear();
        }

        //Clear basket
        public void ClearBasket()
        {
            this.currentClientBasket.Clear();
        }

        #endregion
    }
}