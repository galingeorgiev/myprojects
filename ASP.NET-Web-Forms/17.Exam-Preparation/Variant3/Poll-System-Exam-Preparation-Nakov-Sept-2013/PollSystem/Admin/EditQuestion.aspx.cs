using Error_Handler_Control;
using PollSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PollSystem.Admin
{
    public partial class EditQuestion : System.Web.UI.Page
    {
        bool isNewQuestion = false;
        private int questionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.questionId =
                Convert.ToInt32(Request.Params["questionId"]);
            isNewQuestion = (this.questionId == 0);
        }
        
        protected void LinkButtonSaveQuestion_Click(object sender, EventArgs e)
        {
            using (PollSystemEntities context = new PollSystemEntities())
            {
                Question question;
                if (isNewQuestion)
                {
                    question = new Question();
                    context.Questions.Add(question);
                }
                else
                {
                    question = context.Questions.Find(this.questionId);
                }
                question.QuestionText = this.TextBoxQuestionText.Text;
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Question " +
                        (this.isNewQuestion ? "created." : "edited."));
                    if (isNewQuestion)
                    {
                        ErrorSuccessNotifier.ShowAfterRedirect = true;
                        Response.Redirect("EditQuestion.aspx?questionId=" + 
                            question.QuestionId, false);
                    }
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!isNewQuestion)
            {
                using (PollSystemEntities context = new PollSystemEntities())
                {
                    Question question = context.Questions.Find(questionId);
                    this.TextBoxQuestionText.Text = question.QuestionText;
                    this.RepeaterAnswers.DataSource =
                        question.Answers.ToList();
                    this.RepeaterAnswers.DataBind();
                    this.LinkButtonCreateNewAnswer.Visible = true;
                }
            }
        }

        protected void LinkButtonCreateNewAnswer_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditAnswer.aspx?questionId=" + questionId);
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {

            int answerId = Convert.ToInt32(e.CommandArgument);            
            PollSystemEntities context = new PollSystemEntities();
            try 
            {
                context.Database.ExecuteSqlCommand(
                    "DELETE FROM Answers WHERE AnswerId={0}", answerId);
                ErrorSuccessNotifier.AddInfoMessage("Question successfully deleted.");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }

    }
}