using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsTemplate.Models;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;

namespace WebFormsTemplate
{
    public partial class AdminPosts : System.Web.UI.Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new ApplicationDbContext())
                {
                    this.GridViewPosts.DataSource = db.Posts.ToList();
                    this.GridViewPosts.DataBind();
                    //string[] keys = db.Posts.Select(p => p.Id).ToList().Select(p => p.ToString()).ToArray();
                    //this.GridViewPosts.DataKeyNames = keys;
                }
            }
        }

        //protected void GridViewPosts_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        //{
        //    Response.Redirect("UserPosts.aspx?postId=" + this.GridViewPosts.SelectedDataKey.Value);
        //}

        //protected void GridViewPosts_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Attributes["onmouseover"] =
        //            "this.style.background='#EEEEEE';this.style.cursor='hand'";
        //        e.Row.Attributes["onmouseout"] =
        //            "this.style.background='white'";
        //        e.Row.Attributes["onclick"] =
        //            ClientScript.GetPostBackClientHyperlink(
        //            this.GridViewPosts, "Select$" + e.Row.RowIndex);
        //    }
        //}

        protected void ButtonAddNewPost_Click(object sender, EventArgs e)
        {
            string currentUserName = Context.User.Identity.Name;
            string postText = this.TextBoxAddPost.Text;

            var newPost = new Post() { Author = currentUserName, PostText = postText };

            using (var db = new ApplicationDbContext())
            {
                db.Posts.Add(newPost);
                db.SaveChanges();

                this.GridViewPosts.DataSource = db.Posts.ToList();
                this.GridViewPosts.DataBind();
            }

            this.TextBoxAddPost.Text = "";
        }

        //protected void GridViewPosts_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "DeletePost")
        //    {
        //        int Id = Convert.ToInt32(e.CommandArgument);

        //        using (var db = new ApplicationDbContext())
        //        {
        //            var currentPost = db.Posts.Where(p => p.Id == Id).FirstOrDefault();
        //            if (currentPost != null)
        //            {
        //                db.Posts.Remove(currentPost);
        //                db.SaveChanges();

        //                this.GridViewPosts.DataSource = db.Posts.ToList();
        //                this.GridViewPosts.DataBind();
        //            }
        //        }
        //    }
        //}

        protected void ButtonDelete_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "DeletePost")
            {
                int Id = Convert.ToInt32(e.CommandArgument);

                using (var db = new ApplicationDbContext())
                {
                    var currentPost = db.Posts.Where(p => p.Id == Id).FirstOrDefault();
                    if (currentPost != null)
                    {
                        db.Posts.Remove(currentPost);
                        db.SaveChanges();

                        this.GridViewPosts.DataSource = db.Posts.ToList();
                        this.GridViewPosts.DataBind();
                    }
                }
            }
        }
    }
}