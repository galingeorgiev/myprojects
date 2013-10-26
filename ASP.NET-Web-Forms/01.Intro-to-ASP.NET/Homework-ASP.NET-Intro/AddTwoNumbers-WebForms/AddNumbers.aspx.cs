using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AddTwoNumbers_WebForms
{
    public partial class AddNumbers : System.Web.UI.Page
    {
        protected void ButtonSum_Click(object sender, EventArgs e)
        {
            try
            {
                double result = double.Parse(TextBoxFirstNumber.Text) + double.Parse(TextBoxSecondNumber.Text);

                LabelResult.Text = "Result is: " + result.ToString();
            }
            catch (Exception ex)
            {
                LabelResult.Text = ex.Message;
            }
        }
    }
}