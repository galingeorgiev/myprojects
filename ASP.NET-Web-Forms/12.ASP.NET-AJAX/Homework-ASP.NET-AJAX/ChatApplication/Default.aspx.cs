using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChatApplication
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int numberOfElements = 100;
            var db = new MessagesEntities();
            this.ListViewMessages.DataSource = 
                db.Messages.OrderBy(m => m.MessageId)
                .Skip(Math.Max(0, db.Messages.Count() - numberOfElements))
                .Take(numberOfElements).ToList();
            this.ListViewMessages.DataBind();
        }

        protected void ButtonAddMessage_Click(object sender, EventArgs e)
        {
            var db = new MessagesEntities();
            Message message = new Message() { MessageText = this.TextBoxMessage.Text };
            db.Messages.Add(message);
            db.SaveChanges();
            this.TextBoxMessage.Text = "";
        }
    }
}