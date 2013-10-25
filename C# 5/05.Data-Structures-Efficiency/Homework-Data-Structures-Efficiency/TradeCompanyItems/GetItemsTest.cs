/* A large trade company has millions of articles, each described by 
 * barcode, vendor, title and price. Implement a data structure to 
 * store them that allows fast retrieval of all articles in given 
 * price range [x…y]. Hint: use OrderedMultiDictionary<K,T> from 
 * Wintellect's Power Collections for .NET. 
 */

namespace TradeCompanyItems
{
    public class GetItemsTest
    {
        public static void Main()
        {
            TradeCompany testCompany = new TradeCompany();

            Item item1 = new Item(123456, "Telerik", "C#", 200);
            Item item2 = new Item(243243, "Google", "JS", 300);
            Item item3 = new Item(566454, "Microsoft", "C#", 200);
            Item item4 = new Item(234323, "Telerik", "PHP", 500);
            Item item5 = new Item(765746, "Microsoft", "CSS", 2000);
            Item item6 = new Item(898799, "Telerik", "HTML", 1500);
            Item item7 = new Item(435345, "Telerik", "JS", 600);
            Item item8 = new Item(657532, "Telerik", "C#", 800);

            testCompany.AddItem(item1);
            testCompany.AddItem(item2);
            testCompany.AddItem(item3);
            testCompany.AddItem(item4);
            testCompany.AddItem(item5);
            testCompany.AddItem(item6);
            testCompany.AddItem(item7);
            testCompany.AddItem(item8);

            testCompany.GetItemsInRange(0, 1000);
        }
    }
}
