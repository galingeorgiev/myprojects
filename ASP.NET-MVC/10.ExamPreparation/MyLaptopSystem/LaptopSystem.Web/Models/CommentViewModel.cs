using MyLaptopSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LaptopSystem.Web.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }

        public string User { get; set; }

        [Required]
        [ShouldNotContainEmail()]
        public string Content { get; set; }

        public static Expression<Func<Comment, CommentViewModel>> FromComment
        {
            get 
            {
                return comment => new CommentViewModel()
                {
                    Id = comment.Id, Content = comment.Content, User = comment.Author.UserName
                };
            }
        }
    }
}