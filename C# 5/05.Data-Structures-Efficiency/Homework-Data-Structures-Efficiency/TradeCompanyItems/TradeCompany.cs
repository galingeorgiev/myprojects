namespace TradeCompanyItems
{
    using System;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class TradeCompany
    {
        private OrderedMultiDictionary<int, Item> itemsInCompany = new OrderedMultiDictionary<int, Item>(true);

        public void AddItem(Item item)
        {
            this.itemsInCompany.Add(item.Price, item);
        }

        public void GetItemsInRange(int from, int to)
        {
            var items = this.itemsInCompany.Range(from, true, to, true).ToList();

            foreach (var item in items)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
        }
    }
}
