using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeleteViewState
{
    public partial class DeleteViewState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonExecute_Click(object sender, EventArgs e)
        {
            this.LiteralExecuteScript.Text = this.TextBoxAcceptScript.Text;
        }
    }
}