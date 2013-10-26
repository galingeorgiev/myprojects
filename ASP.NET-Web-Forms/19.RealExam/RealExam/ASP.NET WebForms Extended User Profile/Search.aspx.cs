using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using WebFormsTemplate.Models;
using Error_Handler_Control;

namespace WebFormsTemplate
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = Request.Params["q"];
            this.labelHeaderText.Text = "Search Results for Query &quot;" + query + "&quot;:";
            
        }

        public IEnumerable<Book> ListViewSearchResults_GetData([QueryString] string q)
        {
            var db = new LibraryDbContext();

            if (string.IsNullOrEmpty(q))
            {
                return db.Books
                .Include("Category")
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Author)
                .ToList();
            }
            else
            {
                return db.Books
                .Include("Category")
                .Where(b =>
                    b.Title.ToLower().Contains(q.ToLower()) ||
                    b.Author.ToLower().Contains(q.ToLower()) ||
                    b.Category.Name.ToLower().Contains(q.ToLower()))
                .OrderBy(b => b.Title)
                .ThenBy(b => b.Author)
                .ToList();
            }
        }
    }
}