using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Exam.Models;
using Exam.Web.Models;

namespace Exam.Web.Controllers
{
    [Authorize(Roles="Admin")]
    public class CategoriesAdminController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var comments = this.Data.Categories.All().Select(CategoryViewModel.FromCategory);
            return Json(comments.ToDataSourceResult(request));
        }

        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var editedCategory = this.Data.Categories.GetById(category.Id);
                editedCategory.Name = category.Name;
                this.Data.Categories.Update(editedCategory);
                this.Data.SaveChanges();
            }
            else
            {
                ModelState.AddModelError("Name", "Category name is invalid!");
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }

        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                // Delete is cascading!!!
                var categoryForDelete = this.Data.Categories.GetById(category.Id);
                this.Data.Categories.Delete(categoryForDelete);
                this.Data.SaveChanges();
            }

            return Json(new[] { category }.ToDataSourceResult(request, ModelState));
        }
	}
}