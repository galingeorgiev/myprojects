using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImportDbFromXml;
using SearchInDb;

namespace BookmarkingSite.Client
{
    public class Program
    {
        public static void Main()
        {
            //XmlTools.ImportToDb();
            //SearchTools.SearchByUsernameAndTag();
            SearchTools.ComplexSearch();
        }
    }
}
