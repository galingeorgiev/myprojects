using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Exam.Web.Models
{
    public class CommentCreateViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}