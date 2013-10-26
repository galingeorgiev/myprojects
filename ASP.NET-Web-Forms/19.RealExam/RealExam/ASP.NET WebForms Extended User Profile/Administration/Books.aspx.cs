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
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.PanelCreateNewBook.Visible = false;
                this.PanelEditBook.Visible = false;
                this.PanelDeleteBook.Visible = false;
            }
        }

        public IQueryable<WebFormsTemplate.Models.Book> GridViewBooks_GetData()
        {
            var db = new LibraryDbContext();
            return db.Books.Include("Category");
        }

        protected void ButtonCreateNewBookPanel_Click(object sender, EventArgs e)
        {
            this.ButtonCreateNewBookPanel.Visible = false;
            this.PanelCreateNewBook.Visible = true;
        }

        public IQueryable<Category> DropDownListCategories_GetData()
        {
            var db = new LibraryDbContext();
            return db.Categories;
        }

        protected void ButtonCancelCreateBook_Click(object sender, EventArgs e)
        {
            this.ButtonCreateNewBookPanel.Visible = true;
            this.PanelCreateNewBook.Visible = false;
        }

        protected void ButtonCreateBook_Click(object sender, EventArgs e)
        {
            string title = this.TextBoxBookTitle.Text;
            string author = this.TextBoxBookAuthor.Text;
            string isbn = this.TextBoxBookISBN.Text;
            string webSite = this.TextBoxBookWebSite.Text;
            string description = this.TextBoxBookDescription.Text;
            string categoryId = this.DropDownListCategories.SelectedValue;

            if (string.IsNullOrEmpty(title))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book title cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(author))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book author cannot be empty.");
                return;
            }

            if (string.IsNullOrEmpty(categoryId))
            {
                ErrorSuccessNotifier.AddErrorMessage("Book category cannot be empty.");
                return;
            }

            var db = new LibraryDbContext();
            int catId = int.Parse(categoryId);
            Category bookCategory = db.Categories.FirstOrDefault(b => b.Id == catId);

            Book book = new Book() 
            {
                Title = title,
                Author = author,
                ISBN = isbn, 
                WebSite = webSite,
                Description = description, 
                Category = bookCategory
            };

            try
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }

            this.TextBoxBookTitle.Text = "";
            this.TextBoxBookAuthor.Text = "";
            this.TextBoxBookISBN.Text = "";
            this.TextBoxBookWebSite.Text = "";
            this.TextBoxBookDescription.Text = "";

            ErrorSuccessNotifier.AddSuccessMessage("Book created");
            this.ButtonCreateNewBookPanel.Visible = true;
            this.PanelCreateNewBook.Visible = false;
            this.GridViewBooks.DataBind();
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_UpdateItem(int id)
        {
            var db = new LibraryDbContext();
            Book item = db.Books.FirstOrDefault(b => b.Id == id);
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
                ErrorSuccessNotifier.AddSuccessMessage("Book modified");
                db.SaveChanges();
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewBooks_DeleteItem(int id)
        {
            var db = new LibraryDbContext();
            Book item = db.Books.FirstOrDefault(b => b.Id == id);
            db.Books.Remove(item);
            db.SaveChanges();
            ErrorSuccessNotifier.AddSuccessMessage("Book deleted");
        }

        protected void ButtonEdin_Command(object sender, CommandEventArgs e)
        {
            int bookId = int.Parse(e.CommandArgument.ToString());
            this.CurrentBook.Text = e.CommandArgument.ToString();
            this.PanelEditBook.Visible = true;
            var db = new LibraryDbContext();
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            this.TextBoxEditBookTitle.Text = book.Title;
            this.TextBoxEditBookAuthor.Text = book.Author;
            this.TextBoxEditBookISBN.Text = book.ISBN;
            this.TextBoxEditBookSite.Text = book.WebSite;
            this.TextBoxEditBookDescription.Text = book.Description;
        }

        protected void ButtonEditCancel_Click(object sender, EventArgs e)
        {
            this.PanelEditBook.Visible = false;
        }

        protected void ButtonEditSave_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(this.CurrentBook.Text);
            var db = new LibraryDbContext();
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);

            if (string.IsNullOrEmpty(this.DropDownListEditBookCategory.SelectedValue))
            {
                ErrorSuccessNotifier.AddErrorMessage("Please select category from drop down menu.");
                return;
            }

            int newCategoryId = int.Parse(this.DropDownListEditBookCategory.SelectedValue);
            var cat = db.Categories.FirstOrDefault(c => c.Id == newCategoryId);

            book.Title = this.TextBoxEditBookTitle.Text;
            book.Author = this.TextBoxEditBookAuthor.Text;
            book.ISBN = this.TextBoxEditBookISBN.Text;
            book.WebSite = this.TextBoxEditBookSite.Text;
            book.Description = this.TextBoxEditBookDescription.Text;
            book.Category = cat;
            db.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Book Updated");
            this.PanelEditBook.Visible = false;
            this.GridViewBooks.DataBind();
        }

        protected void ButtonDelete_Command(object sender, CommandEventArgs e)
        {
            int bookId = int.Parse(e.CommandArgument.ToString());
            var db = new LibraryDbContext();
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            this.TextBoxDeleteBookTitle.Text = book.Title;
            this.PanelDeleteBook.Visible = true;
            this.CurrentBook.Text = e.CommandArgument.ToString();
        }

        protected void ButtonDeleteBookYes_Click(object sender, EventArgs e)
        {
            int bookId = int.Parse(this.CurrentBook.Text);
            var db = new LibraryDbContext();
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);

            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Book deleted");
                this.GridViewBooks.DataBind();
                this.PanelDeleteBook.Visible = false;
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage("Book is missing.");
            }
        }

        protected void ButtonDeleteBookNo_Click(object sender, EventArgs e)
        {
            this.PanelDeleteBook.Visible = false;
        }
    }
}