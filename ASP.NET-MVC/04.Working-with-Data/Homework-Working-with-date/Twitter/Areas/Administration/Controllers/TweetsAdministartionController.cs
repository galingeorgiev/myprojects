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
using Twitter.Controllers;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Twitter.Areas.Administration.Controllers
{
    [Authorize(Users="admin")]
    public class TweetsAdministartionController : BaseController
    {
        public TweetsAdministartionController()
        {
        }

        public TweetsAdministartionController(IUowData data)
            : base(data)
        {
        }

        // GET: /Administration/Tweets/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllTweets([DataSourceRequest] DataSourceRequest request)
        {
            return Json(this.Data
                .Tweets
                .All()
                .Include(t => t.Tags)
                .ToDataSourceResult(request));
        }

        // GET: /Administration/Tweets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.Data.Tweets.GetById((int)id);

            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, Tweet tweet)
        {
            var results = new List<Tweet>();

            if (ModelState.IsValid)
            {
                this.Data.Tweets.Add(tweet);
                this.Data.SaveChanges();
                results.Add(tweet);
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }


        // POST: /Administration/Tweets/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, Tweet tweet)
        {
            var results = new List<Tweet>();

            if (ModelState.IsValid)
            {
                var tweetToUpdate = this.Data.Tweets.GetById(tweet.Id);
                tweetToUpdate.Content = tweet.Content;
                this.Data.Tweets.Update(tweetToUpdate);
                this.Data.SaveChanges();
                results.Add(tweet);
            }

            return Json(results.ToDataSourceResult(request, ModelState));
        }

        // GET: /Administration/Tweets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tweet tweet = this.Data.Tweets.GetById((int)id);
            if (tweet == null)
            {
                return HttpNotFound();
            }
            return View(tweet);
        }

        // POST: /Administration/Tweets/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed([DataSourceRequest] DataSourceRequest request, Tweet tweet)
        {
            var results = new List<Tweet>();
            Tweet tweetToRemove = this.Data.Tweets.GetById((int)tweet.Id);
            this.Data.Tweets.Delete(tweetToRemove);
            this.Data.SaveChanges();
            results.Add(tweet);
            return Json(results.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.Data.Dispose();
            base.Dispose(disposing);
        }
    }
}
