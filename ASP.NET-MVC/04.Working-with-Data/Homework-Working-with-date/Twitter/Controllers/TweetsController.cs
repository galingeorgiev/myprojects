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
    public class TweetsController : BaseController
    {
        public TweetsController()
        {
        }

        public TweetsController(IUowData data) 
            : base(data)
        {
        }

        // GET: /Tweets/
        public ActionResult Index()
        {
            var tweets = this.Data.Tweets.All().Include(t => t.User).Include(t => t.Tags);

            return View(tweets);
        }

        // GET: /Tweets/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.Data.Tweets.All().Include(t => t.Tags).FirstOrDefault(t => t.Id == (int)id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            return View(tweet);
        }

        // GET: /Tweets/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Tweets/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TweetCreateViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                var tags = tweet.Tags
                    .Split(new string[] { ",", ", ", " , ", " ," }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(t => new Tag() { Name = t });
                var user = this.Data.Users.All().FirstOrDefault(u => u.UserName == User.Identity.Name);
                var tweetToCreate = new Tweet()
                {
                    User = user, 
                    Content = tweet.Content,
                    Tags = new HashSet<Tag>(tags)
                };
                tweet.User = user;
                this.Data.Tweets.Add(tweetToCreate);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tweet);
        }

        // GET: /Tweets/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.Data.Tweets.All().Include(t => t.User).FirstOrDefault(t => t.Id == (int)id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            if (tweet.User.UserName != User.Identity.Name)
            {
                return View("EditNoPermisions");
            }

            return View(tweet);
        }

        // POST: /Tweets/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TweetViewModel tweet)
        {
            if (tweet != null && ModelState.IsValid)
            {
                var tweetToUpdate = this.Data.Tweets.All().Include(t => t.User).FirstOrDefault(t => t.Id == tweet.Id);
                tweetToUpdate.Content = tweet.Content;

                if (tweetToUpdate.User.UserName != User.Identity.Name)
                {
                    return View("EditNoPermisions");
                }

                this.Data.Tweets.Update(tweetToUpdate);
                this.Data.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tweet);
        }

        // GET: /Tweets/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tweet tweet = this.Data.Tweets.All().Include(t => t.User).FirstOrDefault(t => t.Id == (int)id);

            if (tweet == null)
            {
                return HttpNotFound();
            }

            if (tweet.User.UserName != User.Identity.Name)
            {
                return View("EditNoPermisions");
            }

            return View(tweet);
        }

        // POST: /Tweets/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tweet tweet = this.Data.Tweets.All().Include(t => t.User).FirstOrDefault(t => t.Id == (int)id);

            if (tweet.User.UserName != User.Identity.Name)
            {
                return View("EditNoPermisions");
            }

            this.Data.Tweets.Delete(tweet);
            this.Data.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        [OutputCache(Duration=900)]
        public ActionResult Search(string searchedWord)
        {
            var tweets = this.Data
                .Tweets
                .All()
                .Include(t => t.Tags)
                .Include(t => t.User)
                .Where(t => t.Tags.Any(tag => tag.Name.ToLower().Contains(searchedWord.ToLower())));

            return View(tweets);
        }

        protected override void Dispose(bool disposing)
        {
            this.Data.Dispose();
            base.Dispose(disposing);
        }
    }
}
