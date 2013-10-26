using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionObject
{
    public partial class SessionObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAddText_Click(object sender, EventArgs e)
        {
            if (Session["text"] == null)
            {
                Session.Add("text", new List<string>());
            }

            List<string> current = (List<string>)Session["text"];
            current.Add(this.TextBoxContent.Text);
            Session["text"] = current;
            this.TextBoxContent.Text = "";
        }

        protected void ButtonShowText_Click(object sender, EventArgs e)
        {
            List<string> current = (List<string>)Session["text"];
            if (current != null)
            {
                this.LiteralTextContainer.Text = string.Join(", ", current);
            }
            else
            {
                this.LiteralTextContainer.Text = "empty";
            }
        }
    }
}