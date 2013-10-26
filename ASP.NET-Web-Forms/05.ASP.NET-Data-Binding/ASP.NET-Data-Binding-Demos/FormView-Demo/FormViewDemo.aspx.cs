using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace FormView_Demo
{
    public partial class FormViewDemo : System.Web.UI.Page
    {
        List<Customer> customers = new List<Customer>()
        {
            new Customer() { FirstName = "Svetlin", LastName = "Nakov", Email = "svetlin@nakov.com", Phone = "0894 77 22 53", IsSenior=true },
            new Customer() { FirstName = "Bai", LastName = "Ivan", Email = "bai.ivan@gmail.com", Phone = "0899 555 444" },
            new Customer() { FirstName = "Kaka", LastName = "Mara", Email = "kaka.mara@kaval.net", Phone = "095 955 955" }
        };

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack)
			{
				this.customers = (List<Customer>)ViewState["customers"];
			}
		}

		protected void Page_PreRender(object sender, EventArgs e)
		{
			this.FormViewCustomer.DataSource = this.customers;
			this.FormViewCustomer.DataBind();
			ViewState["customers"] = this.customers;
		}

		protected void FormViewCustomer_PageIndexChanging(
			object sender, FormViewPageEventArgs e)
        {
            this.FormViewCustomer.PageIndex = e.NewPageIndex;
            this.FormViewCustomer.DataSource = this.customers;
            this.FormViewCustomer.DataBind();
        }

		protected void LinkButtonEdit_Click(object sender, EventArgs e)
		{
			this.FormViewCustomer.ChangeMode(FormViewMode.Edit);
			this.MultiViewButtons.SetActiveView(this.ViewEditMode);
		}

		protected void LinkButtonSave_Click(object sender, EventArgs e)
		{
			this.FormViewCustomer.ChangeMode(FormViewMode.ReadOnly);
			this.MultiViewButtons.SetActiveView(this.ViewNormalMode);
			int customerIndex = this.FormViewCustomer.PageIndex;
			TextBox textBoxPhone = (TextBox)
				this.FormViewCustomer.FindControl("TextBoxPhone");
			this.customers[customerIndex].Phone = textBoxPhone.Text;
			TextBox textBoxEmail = (TextBox)
				this.FormViewCustomer.FindControl("TextBoxEmail");
			this.customers[customerIndex].Email = textBoxEmail.Text;
		}
    }
}
