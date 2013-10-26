using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Twitter.Models;
using Twitter.Data;

namespace Twitter.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController()
        {
        }

        public UsersController(IUowData data)
            : base(data)
        {
        }

        // GET: /Users/
        public ActionResult Index()
        {
            return View(this.Data.Users.All());
        }

        // GET: /Users/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var tweets = this.Data.Tweets.All().Where(u => u.User.Id == id);

            if (tweets == null)
            {
                return HttpNotFound();
            }

            return View(tweets);
        }
    }
}
