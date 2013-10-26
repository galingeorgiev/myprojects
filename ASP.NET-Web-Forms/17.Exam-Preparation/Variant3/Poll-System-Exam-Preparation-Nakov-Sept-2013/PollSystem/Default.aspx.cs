using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem
{
    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (PollSystemEntities context = new PollSystemEntities())
            {
                var questions = context.Questions.Include("Answers").
                    OrderBy(question => Guid.NewGuid());
                this.ListViewPolls.DataSource = questions.Take(3).ToList();
                this.DataBind();
            }
        }

        protected void Vote_Command(object sender, CommandEventArgs e)
        {
            int answerId = Convert.ToInt32(e.CommandArgument);
            using (PollSystemEntities context = new PollSystemEntities())
            {
                Answer answer = context.Answers.Find(answerId);
                answer.Votes++;
                context.SaveChanges();
                Response.Redirect("ShowVotingResults.aspx?questionId=" +
                    answer.QuestionId);
            }
        }
    }
}