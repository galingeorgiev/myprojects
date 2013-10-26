using Error_Handler_Control;
using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem
{
    public partial class EditQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Question> GridViewQuestions_GetData()
        {
            PollSystemEntities context = new PollSystemEntities();
            return context.Questions.OrderBy(q => q.QuestionId);
        }

        public void GridViewQuestions_DeleteItem(int questionId)
        {
            PollSystemEntities context = new PollSystemEntities();
            Question question = context.Questions.Include("Answers").
                FirstOrDefault(q => q.QuestionId == questionId);
            try
            {
                context.Answers.RemoveRange(question.Answers);
                context.Questions.Remove(question);
                context.SaveChanges();
                this.GridViewQuestions.PageIndex = 0;
                ErrorSuccessNotifier.AddInfoMessage("Question successfully deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}