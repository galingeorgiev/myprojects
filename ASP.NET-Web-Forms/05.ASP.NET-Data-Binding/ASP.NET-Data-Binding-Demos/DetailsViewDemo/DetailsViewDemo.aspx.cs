using System;
using System.Collections.Generic;

namespace GridViewDemo
{
    public partial class DetailsViewDemo : System.Web.UI.Page
    {
        List<Customer> customers = new List<Customer>()
        {
            new Customer() { FirstName = "Svetlin", LastName = "Nakov", Email = "svetlin@nakov.com", Phone = "0894 77 22 53", IsSenior=true },
            new Customer() { FirstName = "Bai", LastName = "Ivan", Email = "bai.ivan@gmail.com", Phone = "0899 555 444" },
            new Customer() { FirstName = "Kaka", LastName = "Mara", Email = "kaka.mara@kaval.net", Phone = "095 955 955" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DetailsViewCustomer.DataSource = this.customers;
            this.DetailsViewCustomer.DataBind();
        }

        protected void DetailsViewCustomer_PageIndexChanging(object sender, 
            System.Web.UI.WebControls.DetailsViewPageEventArgs e)
        {
            this.DetailsViewCustomer.PageIndex = e.NewPageIndex;
            this.DetailsViewCustomer.DataSource = this.customers;
            this.DetailsViewCustomer.DataBind();
        }
    }
}
