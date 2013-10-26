using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exam.Web.Models
{
    public class TicketCreateViewModel
    {
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required]
        [ShouldNotContainesBugWord(ErrorMessage="The word 'bug' should not be used in the title!")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Priority")]
        public int PriorityId { get; set; }

        public Priority Priority { get; set; }

        public string ScreenshotUrl { get; set; }

        public string Description { get; set; }
    }
}