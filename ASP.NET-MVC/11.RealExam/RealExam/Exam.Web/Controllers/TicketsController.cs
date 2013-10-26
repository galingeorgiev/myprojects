using Exam.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Exam.Models;
using Microsoft.AspNet.Identity;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Transactions;

namespace Exam.Web.Controllers
{
    public class TicketsController : BaseController
    {
        public ActionResult Details(int id)
        {
            var ticket = this.Data.Tickets.All().Include(t => t.Category).Include(t => t.Comments).FirstOrDefault(t => t.Id == id);

            var ticketViewModel = new TicketDetailsViewModel()
            {
                Id = ticket.Id,
                Author = ticket.Author.UserName,
                Category = ticket.Category.Name,
                Description = ticket.Description,
                ScreenshotUrl = ticket.ScreenshotUrl,
                Title = ticket.Title,
                Priority = ticket.Priority.ToString(),
                Comments = ticket.Comments.AsQueryable().Select(CommentBasicViewModel.FromComment).ToList()
            };

            return View(ticketViewModel);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.PriorityId = new SelectList(EnumsController.EnumToDropDownList(typeof(Priority)), "Value", "Text");
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateInput(false)]
        public ActionResult Create(TicketCreateViewModel ticket)
        {
            ViewBag.PriorityId = new SelectList(EnumsController.EnumToDropDownList(typeof(Priority)), "Value", "Text");
            ViewBag.CategoryId = new SelectList(this.Data.Categories.All(), "Id", "Name");

            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                using (TransactionScope tsTransScope = new TransactionScope())
                {
                    var currentUserId = User.Identity.GetUserId();

                    var currentUser = this.Data.ApplicationUsers.All().FirstOrDefault(u => u.Id == currentUserId);
                    currentUser.Points = currentUser.Points + 1;

                    var newTicket = new Ticket()
                    {
                        AuthorId = currentUserId,
                        CategoryId = ticket.CategoryId,
                        Description = HttpUtility.HtmlEncode(ticket.Description),
                        Priority = (Priority)ticket.PriorityId,
                        ScreenshotUrl = ticket.ScreenshotUrl,
                        Title = ticket.Title
                    };

                    this.Data.Tickets.Add(newTicket);
                    this.Data.SaveChanges();
                    tsTransScope.Complete();
                }

                return RedirectToAction("TicketsList");
            }

            return View();
        }

        public ActionResult AllTickets([DataSourceRequest] DataSourceRequest request)
        {
            var allTickets = this.Data.Tickets.All().Select(TicketListViewModel.FromTicket);
            var listOfAllTickets = new List<TicketListReturnViewModel>();

            foreach (var ticket in allTickets)
            {
                var curentTicket = new TicketListReturnViewModel()
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author,
                    Category = ticket.Category,
                    Priority = Enum.GetName(typeof(Priority), ticket.Priority)
                };

                listOfAllTickets.Add(curentTicket);
            }

            return Json(listOfAllTickets.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult TicketsList()
        {
            var allTickets = this.Data.Tickets.All().Select(TicketListViewModel.FromTicket);
            var listOfAllTickets = new List<TicketListReturnViewModel>();

            foreach (var ticket in allTickets)
            {
                var curentTicket = new TicketListReturnViewModel()
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author,
                    Category = ticket.Category,
                    Priority = Enum.GetName(typeof(Priority), ticket.Priority)
                };

                listOfAllTickets.Add(curentTicket);
            }

            return View(listOfAllTickets);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Comment(CommentCreateViewModel comment)
        {
            if (User.Identity.IsAuthenticated && ModelState.IsValid)
            {
                var currentUserId = User.Identity.GetUserId();
                var newComment = new Comment()
                {
                    AuthorId = currentUserId,
                    Content = comment.Content,
                    TicketId = comment.Id
                };

                this.Data.Comments.Add(newComment);
                this.Data.SaveChanges();

                var currentUser = User.Identity.Name;

                return Content("<p><strong>" + currentUser + ": </strong>" + comment.Content + "</p>");
            }

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        [HttpPost]
        [Authorize]
        public ActionResult Search(int? searchedCategory)
        {
            if (searchedCategory == null)
            {
                var resultsAll = this.Data.Tickets.All()
                .Select(TicketBasicViewModel.FromTicket);
                return View(resultsAll);
            }
            else
            {
                var results = this.Data.Tickets.All()
                .Where(t => t.CategoryId == searchedCategory)
                .Select(TicketBasicViewModel.FromTicket);
                return View(results);
            }
        }

        [Authorize]
        public ActionResult CategoriesList()
        {
            var categories = this.Data.Categories.All().Select(x => new { Id = x.Id, Name = x.Name });
            return Json(categories, JsonRequestBehavior.AllowGet);
        }
    }

    public class EnumsController : BaseController
    {
        [NonAction]
        public static List<SelectListItem> EnumToDropDownList(Type enumType)
        {
            return Enum
              .GetValues(enumType)
              .Cast<int>()
              .Select(i => new SelectListItem
              {
                  Value = i.ToString(),
                  Text = Enum.GetName(enumType, i),
              }
              )
              .ToList();
        }
    }
}