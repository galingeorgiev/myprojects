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
    public partial class EditAnswer : System.Web.UI.Page
    {
        bool isNewAnswer = false;
        private int questionId;
        private int answerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.questionId =
                Convert.ToInt32(Request.Params["questionId"]);
            this.answerId =
                Convert.ToInt32(Request.Params["answerId"]);
            isNewAnswer = (this.answerId == 0);
        }

        protected void LinkButtonSave_Click(object sender, EventArgs e)
        {
            using (PollSystemEntities context = new PollSystemEntities())
            {
                Answer answer;
                if (isNewAnswer)
                {
                    answer = new Answer();
                    answer.QuestionId = questionId;
                    context.Answers.Add(answer);
                }
                else
                {
                    answer = context.Answers.Find(this.answerId);
                }
                try
                {
                    answer.AnswerText = this.TextBoxAnswerText.Text;
                    answer.Votes = int.Parse(this.TextBoxVotes.Text);
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("Answer " +
                        (this.isNewAnswer ? "created." : "edited."));
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    Response.Redirect("EditQuestion.aspx?questionId=" + 
                        answer.QuestionId, false);
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!isNewAnswer)
            {
                using (PollSystemEntities context = new PollSystemEntities())
                {
                    Answer answer  = context.Answers.Find(answerId);
                    this.TextBoxAnswerText.Text = answer.AnswerText;
                    this.TextBoxVotes.Text = answer.Votes.ToString();
                }
            }
        }
    }
}