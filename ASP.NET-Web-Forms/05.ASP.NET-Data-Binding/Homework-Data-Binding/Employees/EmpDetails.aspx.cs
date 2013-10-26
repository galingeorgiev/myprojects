using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind.Data;

namespace Employees
{
    public partial class EmpDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            using (var db = new NorthwindEntities())
            {
                var employee = db.Employees.Where(emp => emp.EmployeeID == id).ToList();
                this.EmployeeDetails.DataSource = employee;
                this.EmployeeDetails.DataBind();
            }
        }
    }
}