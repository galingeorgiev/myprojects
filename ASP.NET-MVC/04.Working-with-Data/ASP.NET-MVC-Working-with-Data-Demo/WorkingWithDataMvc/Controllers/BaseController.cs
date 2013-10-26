namespace WorkingWithDataMvc.Controllers
{
    using System.Web.Mvc;
    using WorkingWithDataMvc.Data;

    public class BaseController : Controller
    {
        public BaseController(IUowData data)
        {
            this.Data = data;
        }

        protected IUowData Data { get; set; }
    }
}