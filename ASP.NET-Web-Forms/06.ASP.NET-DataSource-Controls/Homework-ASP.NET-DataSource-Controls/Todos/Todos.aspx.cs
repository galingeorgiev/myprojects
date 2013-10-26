using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Todos
{
    public partial class Todos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new TodosDBEntities())
            {
                db.Categories.ToList();
            }
        }

        protected void ButtonInsertCategory_Click(object sender, EventArgs e)
        {
            this.ListViewCategories.InsertItemPosition = InsertItemPosition.LastItem;
        }

        protected void ListViewCategory_ItemInserted(object sender, EventArgs e)
        {
            this.ListViewCategories.InsertItemPosition = InsertItemPosition.None;
        }

        protected void ButtonAddTodo_Click(object sender, EventArgs e)
        {
            this.PlaceHolderCategoriesDetailsAdnAdd.Controls.Add(this.FormViewAddTodo);
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //this.PlaceHolderCategoriesDetailsAdnAdd.Controls.Clear();
        }
    }
}