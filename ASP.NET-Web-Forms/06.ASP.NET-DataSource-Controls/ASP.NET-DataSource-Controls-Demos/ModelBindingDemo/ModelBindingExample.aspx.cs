using System;
using System.Linq;
using System.Web.UI;

namespace ModelBindingDemo
{
    public partial class ModelBindingExample : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GridViewProducts_GetData()
        {
            NorthwindEntities context = new NorthwindEntities();
            return context.Products.
                Include("Supplier").Include("Category").
                OrderBy(p => p.ProductID);
        }
    }
}