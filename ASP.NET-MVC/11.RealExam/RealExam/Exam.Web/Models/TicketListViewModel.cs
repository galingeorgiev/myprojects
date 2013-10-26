using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Exam.Web.Models
{
    public class TicketListViewModel
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public static Expression<Func<Ticket, TicketListViewModel>> FromTicket
        {
            get
            {
                return ticket => new TicketListViewModel()
                {
                    Id = ticket.Id,
                    Title = ticket.Title,
                    Author = ticket.Author.UserName,
                    Category = ticket.Category.Name,
                    Priority =  ticket.Priority
                };
            }
        }
    }
}