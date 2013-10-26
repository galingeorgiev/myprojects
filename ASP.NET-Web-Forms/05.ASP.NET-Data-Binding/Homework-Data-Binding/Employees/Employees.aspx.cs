using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Northwind.Data;

namespace Employees
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                using (var db = new NorthwindEntities())
                {
                    this.GridViewEpmloyees.DataSource = (from emp in db.Employees
                                                        select new 
                                                        { 
                                                            FullName = emp.FirstName + " " + emp.LastName, 
                                                            Id = emp.EmployeeID 
                                                        }).ToList();

                    this.GridViewEpmloyees.DataBind();
                }
            }
        }
    }
}