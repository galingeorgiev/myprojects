using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;

namespace WebFormsTemplate
{
    public partial class EditPost : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int PostId = Convert.ToInt32(Request.QueryString["PostId"]);
                using (var db = new ApplicationDbContext())
                {
                    var currentPost = db.Posts.Where(p => p.Id == PostId).FirstOrDefault();

                    if (currentPost != null)
                    {
                        this.LabelAuthor.Text = "Author: " + currentPost.Author;
                        this.TextBoxPost.Text = currentPost.PostText;
                    }
                }
            }
        }

        protected void ButtonSaveChanges_Click(object sender, EventArgs e)
        {
            int PostId = Convert.ToInt32(Request.QueryString["PostId"]);
            using (var db = new ApplicationDbContext())
            {
                var currentPost = db.Posts.Where(p => p.Id == PostId).FirstOrDefault();

                if (currentPost != null)
                {
                    currentPost.PostText = this.TextBoxPost.Text;
                    db.SaveChanges();
                    Response.Redirect("~/UserPosts.aspx");
                }
            }
        }
    }
}