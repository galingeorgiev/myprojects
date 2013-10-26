using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twitter.Data;

namespace Twitter.Controllers
{
    public class BaseController : Controller
    {
        protected IUowData Data { get; set; }

        public BaseController()
        {
            this.Data = new UowData();
        }

        public BaseController(IUowData data)
        {
            this.Data = data;
        }
    }
}