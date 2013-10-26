using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClientIP
{
    public partial class ClientIP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.LiteralClientIP.Text = "Your IP is: " + Request.UserHostAddress;
        }
    }
}