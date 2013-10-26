using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        protected void ButtonOne_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "1";
        }

        protected void ButtonTwo_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "2";
        }

        protected void ButtonThree_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "3";
        }

        protected void ButtonPlus_Click(object sender, EventArgs e)
        {
            ViewState.Add("currentOperation", "+");

            try
            {
                if (ViewState["firstNum"] == null)
                {
                    ViewState.Add("firstNum", this.TextBoxNums.Text);
                    this.TextBoxNums.Text = "";
                }
                else
                {
                    this.ButtonEqual_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                this.TextBoxNums.Text = ex.Message;
            }
        }

        protected void ButtonFour_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "4";
        }

        protected void ButtonFive_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "5";
        }

        protected void ButtonSix_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "6";
        }

        protected void ButtonMinus_Click(object sender, EventArgs e)
        {
            ViewState.Add("currentOperation", "-");

            try
            {
                if (ViewState["firstNum"] == null)
                {
                    ViewState.Add("firstNum", this.TextBoxNums.Text);
                    this.TextBoxNums.Text = "";
                }
                else
                {
                    this.ButtonEqual_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                this.TextBoxNums.Text = ex.Message;
            }
        }

        protected void ButtonSeven_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "7";
        }

        protected void ButtonEight_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "8";
        }

        protected void ButtonNine_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "9";
        }

        protected void ButtonMultiplication_Click(object sender, EventArgs e)
        {
            ViewState.Add("currentOperation", "*");

            try
            {
                if (ViewState["firstNum"] == null)
                {
                    ViewState.Add("firstNum", this.TextBoxNums.Text);
                    this.TextBoxNums.Text = "";
                }
                else
                {
                    this.ButtonEqual_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                this.TextBoxNums.Text = ex.Message;
            }
        }

        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            ViewState.Remove("firstNum");
            ViewState.Remove("currentOperation");
            this.TextBoxNums.Text = "";
        }

        protected void ButtonZero_Click(object sender, EventArgs e)
        {
            this.TextBoxNums.Text += "0";
        }

        protected void ButtonDivision_Click(object sender, EventArgs e)
        {
            ViewState.Add("currentOperation", "/");

            try
            {
                if (ViewState["firstNum"] == null)
                {
                    ViewState.Add("firstNum", this.TextBoxNums.Text);
                    this.TextBoxNums.Text = "";
                }
                else
                {
                    this.ButtonEqual_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                this.TextBoxNums.Text = ex.Message;
            }
        }

        protected void ButtonSquareRoot_Click(object sender, EventArgs e)
        {
            ViewState.Add("currentOperation", "s");

            try
            {
                if (ViewState["firstNum"] == null)
                {
                    ViewState.Add("firstNum", this.TextBoxNums.Text);
                    this.TextBoxNums.Text = "";
                }

                this.ButtonEqual_Click(sender, e);
            }
            catch (Exception ex)
            {
                this.TextBoxNums.Text = ex.Message;
            }
        }

        protected void ButtonEqual_Click(object sender, EventArgs e)
        {
            try
            {
                double firstNum = double.Parse(ViewState["firstNum"].ToString());
                double secondNum = 0;

                if (this.TextBoxNums.Text != string.Empty)
                {
                    secondNum = double.Parse(this.TextBoxNums.Text);
                }
                
                if (ViewState["currentOperation"] != null)
                {
                    switch (ViewState["currentOperation"].ToString())
                    {
                        case "+":
                            firstNum = firstNum + secondNum;
                            this.TextBoxNums.Text = firstNum.ToString();
                            break;

                        case "-":
                            firstNum = firstNum - secondNum;
                            this.TextBoxNums.Text = firstNum.ToString();
                            break;

                        case "*":
                            firstNum = firstNum * secondNum;
                            this.TextBoxNums.Text = firstNum.ToString();
                            break;

                        case "/":
                            firstNum = firstNum / secondNum;
                            this.TextBoxNums.Text = firstNum.ToString();
                            break;

                        case "s":
                            firstNum = Math.Sqrt(firstNum);
                            this.TextBoxNums.Text = firstNum.ToString();
                            break;

                        default:
                            this.TextBoxNums.Text = "Missing command";
                            break;
                    }

                    ViewState["firstNum"] = firstNum;
                }

            }
            catch (Exception ex)
            {
                this.TextBoxNums.Text = ex.Message;
            }
        }
    }
}