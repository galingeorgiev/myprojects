using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using Error_Handler_Control;
using WebFormsTemplate.Models;

namespace WebFormsTemplate.Administration
{
    public partial class Categories : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelCreateNewCategory.Visible = false;
                this.PanelUpdateCategory.Visible = false;
                this.PanelDelete.Visible = false;
            }
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<WebFormsTemplate.Models.Category> GridViewCategories_GetData()
        {
            var db = new LibraryDbContext();
            return db.Categories;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_UpdateItem(int id)
        {
            var db = new LibraryDbContext();
            Category item = db.Categories.FirstOrDefault(c => c.Id == id);
            // Load the item here, e.g. item = MyDataLayer.Find(id);
            if (item == null)
            {
                // The item wasn't found
                ModelState.AddModelError("", String.Format("Item with id {0} was not found", id));
                return;
            }
            TryUpdateModel(item);
            if (ModelState.IsValid)
            {
                // Save changes here, e.g. MyDataLayer.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category modified");
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewCategories_DeleteItem(int id)
        {
            var db = new LibraryDbContext();
            Category item = db.Categories.FirstOrDefault(c => c.Id == id);

            if (item != null)
            {
                db.Categories.Remove(item);
                db.SaveChanges();
            }
        }

        protected void ButtonShowCreateNewForm_Click(object sender, EventArgs e)
        {
            this.ButtonShowCreateNewForm.Visible = false;
            this.PanelCreateNewCategory.Visible = true;
        }

        protected void ButtonCreateCategory_Click(object sender, EventArgs e)
        {
            string categoryName = this.TextBoxCategoryName.Text;

            var category = new Category();

            if (!string.IsNullOrEmpty(categoryName))
            {
                category.Name = categoryName;
                var db = new LibraryDbContext();
                db.Categories.Add(category);
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Category created");
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name cannot be empty.");
            }

            this.ButtonShowCreateNewForm.Visible = true;
            this.PanelCreateNewCategory.Visible = false;
        }

        protected void ButtonCancelCreate_Click(object sender, EventArgs e)
        {
            this.TextBoxCategoryName.Text = "";
            this.ButtonShowCreateNewForm.Visible = true;
            this.PanelCreateNewCategory.Visible = false;
        }

        // The id parameter should match the DataKeyNames value set on the control
        // or be decorated with a value provider attribute, e.g. [QueryString]int id
        //public WebFormsTemplate.Models.Category DetailsViewBooks_GetItem([Control] int? gridViewCategories)
        //{
        //    return null;
        //}

        // The id parameter name should match the DataKeyNames value set on the control
        //public void DetailsViewBooks_UpdateItem([Control] int? gridViewCategories)
        //{
        //    var db = new LibraryDbContext();
        //    WebFormsTemplate.Models.Category item = db.Categories.FirstOrDefault(c => c.Id == gridViewCategories);
        //    // Load the item here, e.g. item = MyDataLayer.Find(id);
        //    if (item == null)
        //    {
        //        // The item wasn't found
        //        ModelState.AddModelError("", String.Format("Item with id {0} was not found", gridViewCategories));
        //        return;
        //    }
        //    TryUpdateModel(item);
        //    if (ModelState.IsValid)
        //    {
        //        // Save changes here, e.g. MyDataLayer.SaveChanges();
        //        db.SaveChanges();
        //    }
        //}

        protected void ButtonEdin_Command(object sender, CommandEventArgs e)
        {

            this.CurrentCategory.Text = e.CommandArgument.ToString();
            this.PanelUpdateCategory.Visible = true;
            int categoryId = int.Parse(e.CommandArgument.ToString());
            var db = new LibraryDbContext();
            Category item = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            this.TextBoxUpdateCategory.Text = item.Name;
        }

        protected void ButtonUpdateCategory_Click(object sender, EventArgs e)
        {
            string newName = this.TextBoxUpdateCategory.Text;
            int categoryId = int.Parse(this.CurrentCategory.Text);

            var db = new LibraryDbContext();
            var item = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            item.Name = newName;
            db.SaveChanges();
            this.GridViewCategories.DataBind();
            ErrorSuccessNotifier.AddSuccessMessage("Category modified.");
            this.PanelUpdateCategory.Visible = false;
        }

        protected void ButtonCancelUpdate_Click(object sender, EventArgs e)
        {
            this.TextBoxUpdateCategory.Text = "";
            this.PanelUpdateCategory.Visible = false;
        }

        protected void ButtonYesDelete_Click(object sender, EventArgs e)
        {
            int categoryId = int.Parse(this.CurrentCategory.Text);
            var db = new LibraryDbContext();
            var item = db.Categories.Include("Books").FirstOrDefault(c => c.Id == categoryId);

            if (item.Books != null)
            {
                db.Books.RemoveRange(item.Books);
            }

            db.Categories.Remove(item);
            db.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Category deleted.");
            this.PanelDelete.Visible = false;
            this.GridViewCategories.DataBind();
        }

        protected void ButtonNoDelete_Click(object sender, EventArgs e)
        {
            this.TextBoxCategoryDelete.Text = "";
            this.PanelDelete.Visible = false;
        }

        protected void ButtonDelete_Command(object sender, CommandEventArgs e)
        {
            this.CurrentCategory.Text = e.CommandArgument.ToString();
            this.PanelDelete.Visible = true;
            int categoryId = int.Parse(e.CommandArgument.ToString());
            var db = new LibraryDbContext();
            Category item = db.Categories.FirstOrDefault(c => c.Id == categoryId);
            this.TextBoxCategoryDelete.Text = item.Name;
        }
    }
}