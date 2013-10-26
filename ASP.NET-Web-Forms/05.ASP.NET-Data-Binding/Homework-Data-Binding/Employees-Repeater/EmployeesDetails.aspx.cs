using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind.Data;

namespace Employees_Repeater
{
    public partial class EmployeesDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (var db = new NorthwindEntities())
            {
                var employees = db.Employees.ToList();
                this.RepeaterEmployees.DataSource = employees;
                this.RepeaterEmployees.DataBind();
            }
        }
    }
}