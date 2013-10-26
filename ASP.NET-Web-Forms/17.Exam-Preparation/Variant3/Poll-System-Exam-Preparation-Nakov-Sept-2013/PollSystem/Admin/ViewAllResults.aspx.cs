using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem
{
    public partial class ViewAllResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterAnswers.DataSource = null;
            this.RepeaterAnswers.DataBind();
        }

        protected void GridViewQuestions_SelectedIndexChanged(
            object sender, EventArgs e)
        {
            int questionId = Convert.ToInt32(
                this.GridViewQuestions.SelectedDataKey.Value);
            using (PollSystemEntities context = new PollSystemEntities())
            {
                var answers = context.Answers.Where(
                    a => a.QuestionId == questionId).ToList();

                this.RepeaterAnswers.DataSource = answers;
                this.RepeaterAnswers.DataBind();
            }
        }

        public IQueryable<Question> GridViewQuestions_GetData()
        {
            PollSystemEntities context = new PollSystemEntities();
            return context.Questions.OrderBy(q => q.QuestionId);
        }
    }
}