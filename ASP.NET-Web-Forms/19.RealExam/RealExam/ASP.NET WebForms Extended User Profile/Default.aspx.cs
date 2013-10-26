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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Category> ListViewCategories_GetData()
        {
            var db = new LibraryDbContext();
            return db.Categories.Include("Books");
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string searchedWord = this.TextBoxSearch.Text;

            if (searchedWord.Length >= 20)
            {
                ErrorSuccessNotifier.AddErrorMessage("Search field lenght is too long. Max lenght is 20 chars.");
                return;
            }

            Response.Redirect("~/Search.aspx?q=" + searchedWord);
        }
    }
}