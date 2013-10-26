using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem
{
    public partial class ShowVotingResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int questionId = Convert.ToInt32(Request.Params["questionId"]);
            using (PollSystemEntities context = new PollSystemEntities())
            {
                Question question = context.Questions.Find(questionId);
                this.LiteralQuestion.Text = question.QuestionText;
                this.RepeaterAnswers.DataSource =
                    question.Answers.ToList();
                this.RepeaterAnswers.DataBind();
            }
        }
    }
}