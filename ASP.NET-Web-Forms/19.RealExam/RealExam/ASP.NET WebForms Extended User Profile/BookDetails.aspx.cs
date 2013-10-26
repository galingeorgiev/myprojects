using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Error_Handler_Control;
using WebFormsTemplate.Models;

namespace WebFormsTemplate
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        public WebFormsTemplate.Models.Book FormViewBook_GetItem([QueryString] int? id)
        {
            var db = new LibraryDbContext();
            return db.Books.FirstOrDefault(b => b.Id == id);
        }
    }
}