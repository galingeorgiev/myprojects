<%@ Page Language="C#" AutoEventWireup="true" Inherits="DynamicForms"
  Codebehind="DymamicForms.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
  "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <title>Validation Group Demo</title>
</head>

<body>
<form id="FormValidation" runat="server">
    First Name:
    <asp:TextBox id="TextBoxFirstName" runat="server"
        ValidationGroup="ValidationGroupNames"></asp:TextBox>
    <asp:RequiredFieldValidator
        id="RequiredFieldValidatorFirstName"
        runat="server" ForeColor="Red"
        ErrorMessage="First name is required!"
        ControlToValidate="TextBoxFirstName" >
    </asp:RequiredFieldValidator>
    <br />
    Last Name:
    <asp:TextBox id="TextBoxLastName" runat="server"
        ValidationGroup="ValidationGroupNames"></asp:TextBox>
    <asp:RequiredFieldValidator
        id="RequiredFieldValidatorLastName"
        runat="server" ForeColor="Red"
        ErrorMessage="Last name is required!"
        ControlToValidate="TextBoxLastName" >
    </asp:RequiredFieldValidator>
    <br />
    <asp:CheckBox ID="CheckBoxEnterContacts" runat="server" 
        Text="Enter contacts information" AutoPostBack="True" 
        oncheckedchanged="CheckBoxEnterContacts_CheckedChanged" />
    <br />
    <asp:Panel ID="PanelContacts" runat="server" Visible="False">
        Phone number:
        <asp:TextBox id="TextBoxPhone" runat="server"
            ValidationGroup="ValidationGroupContacts"></asp:TextBox>
        <asp:RequiredFieldValidator
            id="RequiredFieldValidatorPhone"
            runat="server" ForeColor="Red"
            ErrorMessage="A telephone number is required!"
            ControlToValidate="TextBoxPhone"
            Display="Dynamic" >
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
            id="RegularExpressionValidatorPhone"
            runat="server" ForeColor="Red"
            ErrorMessage="Phone number is not formatted correctly!"
            ControlToValidate="TextBoxPhone"
            ValidationExpression=
            "(\d{3,4})(\-(\d{3,4}))+" 
            Display="Dynamic" >
        </asp:RegularExpressionValidator>
        <br />
        Email address:
        <asp:TextBox ID="TextBoxEmail" runat="server" 
            ValidationGroup="ValidationGroupContacts"></asp:TextBox>
        <asp:RequiredFieldValidator
            id="RequiredFieldValidatorEmail"
            runat="server" ForeColor="Red"
            ErrorMessage="An email address is required!"
            ControlToValidate="TextBoxEmail"
            Display="Dynamic">
        </asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator
	        id="RegularExpressionValidatorEmail"
	        runat="server" ForeColor="Red"
	        ErrorMessage="Email address is not formatted correctly!"
	        ControlToValidate="TextBoxEmail"	    
            ValidationExpression=
                "[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}">
        </asp:RegularExpressionValidator>
    </asp:Panel>
    <asp:ValidationSummary ID="ValidationSummary" runat="server" />
    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit"
        OnClick="ButtonSubmit_Click" />
</form>
</body>

</html>
