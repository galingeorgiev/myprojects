using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LaptopSystem.Web.Models;

namespace LaptopSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentsAdministrationController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReadComments([DataSourceRequest] DataSourceRequest request)
        {
            var result = this.Data.Comments.All()
                .Select(x => new CommentViewModel
                    {
                        Id = x.Id,
                        Content = x.Content,
                        AuthorUsername = x.Author.UserName
                    });

            return Json(result.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateComment([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            var commentDb = this.Data.Comments.GetById(comment.Id);

            commentDb.Content = comment.Content;
            this.Data.SaveChanges();

            return Json(new[] { comment }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DestroyComment([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            this.Data.Comments.Delete(comment.Id);
            this.Data.SaveChanges();

            return Json(new[] { comment }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
	}
}