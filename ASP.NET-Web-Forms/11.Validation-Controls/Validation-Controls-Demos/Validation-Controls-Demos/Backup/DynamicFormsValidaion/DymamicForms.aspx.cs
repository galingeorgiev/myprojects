using System;

public partial class DynamicForms : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        Page.Validate("ValidationGroupContacts");

        if (Page.IsValid)
        {
            Response.Write("Page is valid!");
        }
    }

    protected void CheckBoxEnterContacts_CheckedChanged(object sender, EventArgs e)
    {
        this.PanelContacts.Visible = this.CheckBoxEnterContacts.Checked;
    }
}
