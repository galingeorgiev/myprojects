using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AssebmlyLocation
{
    public partial class AssemblyLocation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TextBox.Text = "Hello C# from C# code!";
            this.TextBoxLocation.Text = Assembly.GetAssembly(typeof(AssemblyLocation)).Location;
        }
    }
}