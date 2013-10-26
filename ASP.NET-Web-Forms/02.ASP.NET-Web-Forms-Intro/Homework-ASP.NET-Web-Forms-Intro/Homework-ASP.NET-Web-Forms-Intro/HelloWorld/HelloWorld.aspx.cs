using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld
{
    public partial class HelloWorld : System.Web.UI.Page
    {
        protected void ShowMessage_Click(object sender, EventArgs e)
        {
            this.TextBoxMessage.Text = "Hello " + this.TextBoxName.Text + "!";
        }
    }
}