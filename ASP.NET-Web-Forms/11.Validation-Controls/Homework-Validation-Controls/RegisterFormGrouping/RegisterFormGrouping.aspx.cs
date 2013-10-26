using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegisterFormGrouping
{
    public partial class RegisterFormGrouping : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckBoxAccept.Checked = true;
        }

        protected void ButtonCheckLogonInfo_Click(object sender, EventArgs e)
        {
            this.Page.Validate("LogonInfo");
            this.CheckBoxAccept.Checked = true;
            if (!this.Page.IsValid)
            {
                this.LabelIsValid.Text = "Logon info is not valid.";
            }
            else
            {
                this.LabelIsValid.Text = "Logon info is valid.";
            }
        }

        protected void ButtonCheckPersonalInfo_Click(object sender, EventArgs e)
        {
            this.Page.Validate("PersonalInfo");
            this.CheckBoxAccept.Checked = true;
            if (!this.Page.IsValid)
            {
                this.LabelIsValid.Text = "Personal info is not valid.";
            }
            else
            {
                this.LabelIsValid.Text = "Personal info is valid.";
            }
        }

        protected void ButtonCheckAddressInfo_Click(object sender, EventArgs e)
        {
            this.Page.Validate("AddressInfo");
            this.CheckBoxAccept.Checked = true;
            if (!this.Page.IsValid)
            {
                this.LabelIsValid.Text = "Address info is not valid.";
            }
            else
            {
                this.LabelIsValid.Text = "Address info is valid.";
            }
        }

        protected void CustomValidatorAccept_ServerValidate(object source, ServerValidateEventArgs e)
        {
            e.IsValid = this.CheckBoxAccept.Checked;
        }
    }
}