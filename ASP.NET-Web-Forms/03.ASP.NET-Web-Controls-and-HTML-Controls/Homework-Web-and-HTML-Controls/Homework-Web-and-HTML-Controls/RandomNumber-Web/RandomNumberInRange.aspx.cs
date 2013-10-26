using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumber_Web
{
    public partial class RandomNumberInRange : System.Web.UI.Page
    {
        protected void GenerateRandomNumber_Click(object sender, EventArgs e)
        {
            try
            {
                int firstValue = int.Parse(this.TextBoxFirstNumber.Text);
                int secondValue = int.Parse(this.TextBoxSecondNumber.Text);

                if (secondValue < firstValue)
                {
                    firstValue = firstValue ^ secondValue;
                    secondValue = firstValue ^ secondValue;
                    firstValue = firstValue ^ secondValue;
                }

                Random rnd = new Random();
                this.TextBoxResultNumber.Text = rnd.Next(firstValue, secondValue).ToString();  
            }
            catch (Exception ex)
            {
                this.TextBoxResultNumber.Text = ex.Message;
            }
        }
    }
}