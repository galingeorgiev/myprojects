using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Web.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Identity;
using MyLaptopSystem.Models;

namespace LaptopSystem.Web.Controllers
{
    public class LaptopsController : BaseController
    {
        [Authorize]
        public ActionResult Index()
        {
            var allLaptops = this.Data.Laptops.All().Select(LaptopBasicViewModel.FromLaptop);
            return View(allLaptops);
        }

        public ActionResult AllLaptops([DataSourceRequest] DataSourceRequest request)
        {
            var allLaptops = this.Data.Laptops.All().Select(LaptopBasicViewModel.FromLaptop);
            return Json(allLaptops.ToDataSourceResult(request));
        }

        public ActionResult Details(int id)
        {
            var selectedLaptop = this.Data.Laptops.All()
                .Where(l => l.Id == id)
                .Select(LaptopDetailsViewModel.FromLaptop)
                .FirstOrDefault();

            return View(selectedLaptop);
        }

        [Authorize]
        public ActionResult Vote(int id)
        {
            var currentUserId = User.Identity.GetUserId();
            if (User.Identity.IsAuthenticated && !this.Data.Votes.All().Any(l => l.laptopId == id && l.VotedById == currentUserId))
            {
                var newVote = new Vote() { VotedById = currentUserId, laptopId = id };
                this.Data.Votes.Add(newVote);
                this.Data.SaveChanges();
            }

            var votesCount = this.Data.Laptops.GetById(id).Votes.Count();

            return Content(votesCount.ToString());
        }

        [Authorize]
        public ActionResult Comment(CommentViewModel comment)
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var newComment = new Comment()
                {
                    AuthorId = currentUserId,
                    Content = comment.Content,
                    laptopId = comment.Id
                };

                this.Data.Comments.Add(newComment);
                this.Data.SaveChanges();

                var currentUser = User.Identity.Name;

                return Content("<div class='span7 divider'>" +
                    "<p>Comment by " + currentUser + "</p>" +
                    "<p>" + comment.Content + "</p>" +
                    "</div>");
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [Authorize]
        public ActionResult SearchModel(string text)
        {
            var results = this.Data.Laptops.All()
                .Where(l => l.Model.ToLower().Contains(text.ToLower()))
                .Select(x => new { Model = x.Model });

            return Json(results, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Search(LaptopSearchViewModel laptop)
        {
            var laptops = this.Data.Laptops.All();

            if (!string.IsNullOrEmpty(laptop.SearchModel))
            {
                laptops = laptops.Where(l => l.Model.ToLower().Contains(laptop.SearchModel.ToLower()));
            }

            if (laptop.SearchManufacturer != 0)
            {
                laptops = laptops.Where(l => l.Manufacturer.Id == laptop.SearchManufacturer);
            }

            if (laptop.PriceSearch > 0)
            {
                laptops = laptops.Where(l => l.Price <= laptop.PriceSearch);
            }

            var result = laptops.Select(LaptopBasicViewModel.FromLaptop);
            return View(result);
        }

        [Authorize]
        public ActionResult ManufacturerList()
        {
            var laptops = this.Data.Manufacturers.All().Select(x => new { Id = x.Id, Name = x.Name });
            return Json(laptops, JsonRequestBehavior.AllowGet);
        }
    }
}