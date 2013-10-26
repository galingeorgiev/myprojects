using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RandomNumberInRange
{
    public partial class RandomNumberInRange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGenerateRandomNumber_Click(object sender, EventArgs e)
        {
            try
            {
                int firstValue = int.Parse(this.InputFirstValue.Value);
                int secondValue = int.Parse(this.InputSecondValue.Value);

                if (secondValue < firstValue)
                {
                    firstValue = firstValue ^ secondValue;
                    secondValue = firstValue ^ secondValue;
                    firstValue = firstValue ^ secondValue;
                }

                Random rnd = new Random();
                this.InputResultNumber.Value = rnd.Next(firstValue, secondValue).ToString(); 
            }
            catch (Exception ex)
            {
                this.InputResultNumber.Value = ex.Message;
            }
        }
    }
}