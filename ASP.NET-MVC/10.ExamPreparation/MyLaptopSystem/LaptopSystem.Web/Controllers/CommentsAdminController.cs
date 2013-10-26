using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using LaptopSystem.Web.Models;

namespace LaptopSystem.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CommentsAdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var comments = this.Data.Comments.All().Select(CommentViewModel.FromComment);
            return Json(comments.ToDataSourceResult(request));
        }

        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var editedComment = this.Data.Comments.GetById(comment.Id);
                editedComment.Content = comment.Content;
                this.Data.Comments.Update(editedComment);
                this.Data.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("Content", "Comment is invalid!");
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CommentViewModel comment)
        {
            if (ModelState.IsValid)
            {
                var commentForDelete = this.Data.Comments.GetById(comment.Id);
                this.Data.Comments.Delete(commentForDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { comment }.ToDataSourceResult(request, ModelState));
        }
	}
}