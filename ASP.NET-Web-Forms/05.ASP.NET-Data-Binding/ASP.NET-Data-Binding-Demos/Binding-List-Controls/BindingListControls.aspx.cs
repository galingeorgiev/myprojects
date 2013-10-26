using System;
using System.Text;

namespace Binding_List_Controls
{
    public partial class BindingListControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                // This is not the first load of the page,
                // so we should skip the data binding
                return;
            }

            // Bind the BulletedList
            var urls = new[]
            {
                new { Text="Google", Url="http://www.google.com" },
                new { Text="Bing!", Url="http://www.bing.com" },
                new { Text="MSDN", Url="http://msdn.microsoft.com" }
            };
            this.BulletedListMenu.DataSource = urls;
            this.BulletedListMenu.DataBind();

            // Bind the ListBox
            string[] towns = { "Sofia", "Plovdiv", "Varna", "Kaspichan" };
            this.ListBoxTowns.DataSource = towns;
            this.ListBoxTowns.DataBind();
            this.ListBoxTowns.SelectedIndex = 2;

            // Bind the DropDownList
            string[] genders = { "Male", "Female", "Other" };
            this.DropDownListGender.DataSource = genders;
            this.DropDownListGender.DataBind();
            this.DropDownListGender.SelectedIndex = 1;

            // Bind the CheckBoxList
            var food = new[]
            {
                new { ID=101, Text="Salad" },
                new { ID=102, Text="Steak" },
                new { ID=103, Text="Beer" },
            };
            this.CheckBoxListFood.DataSource = food;
            this.CheckBoxListFood.DataBind();

            // Bind the RadioButtonList
            var paymentMethods = new[]
            {
                new { ID=1, Text="Cash" },
                new { ID=2, Text="Credit card" }
            };
            this.RadioButtonListPayment.DataSource = paymentMethods;
            this.RadioButtonListPayment.DataBind();
            this.RadioButtonListPayment.SelectedIndex = 1;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(
                "Town: <b>" + ListBoxTowns.SelectedValue + "</b><br/>");
            result.AppendLine(
                "Gender: <b>" + DropDownListGender.SelectedValue + "</b><br/>");
            for (int i = 0; i < CheckBoxListFood.Items.Count; i++)
            {
                if (CheckBoxListFood.Items[i].Selected)
                {
                    result.AppendLine(
                        "Food: <b>" + CheckBoxListFood.Items[i].Text + "</b> " +
                        "(ID=" + CheckBoxListFood.Items[i].Value + ") <br/>");
                }
            }
            result.AppendLine(
                "Payment: <b>" + RadioButtonListPayment.SelectedItem.Text +
                "</b> (ID=" + RadioButtonListPayment.SelectedItem.Value + ")<br/>");
            this.ResultsRow.Visible = true;
            this.LiteralResult.Text = result.ToString();
        }
    }
}