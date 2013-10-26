using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cookies
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Username", this.TextBoxUsername.Text.Trim());
            cookie.Expires = DateTime.Now.AddMinutes(1);
            Response.Cookies.Add(cookie);
            this.TextBoxUsername.Text = "";
        }

        protected void ButtonGoToHomePage_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("Home.aspx");
        }
    }
}