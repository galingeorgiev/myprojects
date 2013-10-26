using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Escaping
{
    public partial class Escaping : System.Web.UI.Page
    {
        protected void ShowText_Click(object sender, EventArgs e)
        {
            string output = Server.HtmlEncode(this.TextBoxInput.Text);
            this.LabelOutput.Text = output;
            this.TextBoxOutput.Text = Server.HtmlDecode(this.TextBoxInput.Text);
        }
    }
}