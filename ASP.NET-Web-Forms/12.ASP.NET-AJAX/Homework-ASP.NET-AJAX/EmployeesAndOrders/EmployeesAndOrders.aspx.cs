using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.ModelBinding;
using System.Threading;

namespace EmployeesAndOrders
{
    public partial class EmployeesAndOrders : System.Web.UI.Page
    {
        public IQueryable<Order> Orders { get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Employee> GridViewEmployees_GetData()
        {
            var db = new NorthwindEntities();
            return db.Employees;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Order> GridViewOrders_GetData([Control] int? gridViewEmployees)
        {
            Thread.Sleep(2000);
            var db = new NorthwindEntities();
            return db.Orders.Where(o => o.EmployeeID == gridViewEmployees);
        }
    }
}