using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace TreeView
{
    public partial class TreeView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ShowResult_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in this.TreeViewBooksCatalog.CheckedNodes)
            {
                this.CheckedNodeInfo.Text = this.CheckedNodeInfo.Text + node.Text + " ";
            }
        }
    }
}