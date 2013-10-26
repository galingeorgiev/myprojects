using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind.Data;

namespace Employees_SinglePage
{
    public partial class Emploees : System.Web.UI.Page
    {
        List<Employee> employees = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                this.employees = db.Employees.ToList();
            }

            this.FormViewEmployee.DataSource = this.employees;
            this.FormViewEmployee.DataBind();
        }

        protected void FormViewEmployee_PageIndexChanging(object sender, FormViewPageEventArgs e)
        {
            this.FormViewEmployee.PageIndex = e.NewPageIndex;
            this.FormViewEmployee.DataSource = this.employees;
            this.FormViewEmployee.DataBind();
        }
    }
}