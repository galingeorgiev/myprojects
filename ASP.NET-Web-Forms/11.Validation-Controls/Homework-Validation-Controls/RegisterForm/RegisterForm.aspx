<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterForm.aspx.cs" Inherits="RegisterForm.RegisterForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <fieldset>
        <legend>Register form</legend>
        <label>Username: </label>
        <asp:TextBox runat="server" ID="TextBoxUsername" />
        <br />

        <label>Password: </label>
        <asp:TextBox runat="server" ID="TextBoxPassword" />
        <br />

        <label>Repeat Password: </label>
        <asp:TextBox runat="server" ID="TextBoxRepeatPassword" />
        <br />

        <label>First name: </label>
        <asp:TextBox runat="server" ID="TextBoxFirstName" />
        <br />

        <label>Last name: </label>
        <asp:TextBox runat="server" ID="TextBoxLastName" />
        <br />

        <label>Age: </label>
        <asp:TextBox runat="server" ID="TextBoxAge" />
        <br />

        <label>Email: </label>
        <asp:TextBox runat="server" ID="TextBoxEmail" />
        <br />

        <label>Local Address: </label>
        <asp:TextBox runat="server" ID="TextBoxAddress" />
        <br />

        <label>Phone: </label>
        <asp:TextBox runat="server" ID="TextBoxPhone" />
        <br />

        <asp:CheckBox Text="I accept" runat="server" ID="CheckBoxAccept" />
        <br />

        <asp:Button Text="Register" ID="ButtonRegister" runat="server" />
    </fieldset>

        <asp:ValidationSummary runat="server" ID="ValidationSummaryRegisterForm" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Username is required!" ID="RequiredFieldValidatorUsername"
            ForeColor="Red" 
            Display="None"
            ControlToValidate="TextBoxUsername" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Password is required!" ID="RequiredFieldValidatorPassword"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxPassword" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="repeat password is required!" ID="RequiredFieldValidatorRepeatPassword"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxRepeatPassword" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="First name is required!" ID="RequiredFieldValidatorFirstName"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxFirstName" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Last name is required!" ID="RequiredFieldValidatorLastName"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxLastName" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Age is required!" ID="RequiredFieldValidatorAge"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxAge" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Email is required!" ID="RequiredFieldValidatorEmail"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxEmail" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Local address is required!" ID="RequiredFieldValidatorAddress"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxAddress" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RequiredFieldValidator 
            ErrorMessage="Phone is required!" ID="RequiredFieldValidatorPhone"
            ForeColor="Red" 
            Display="None" 
            ControlToValidate="TextBoxPhone" 
            runat="server" 
            EnableClientScript="false" />

        <asp:RangeValidator ID="RangeValidatorAge"
            ErrorMessage="Age should be between 18 and 81." 
            ControlToValidate="TextBoxAge" 
            runat="server" 
            ForeColor="Red" 
            Display="None" 
            Type="Integer"
            MinimumValue="18"
            MaximumValue="81" 
            EnableClientScript="false" />

        <asp:CompareValidator 
            ID="CompareValidatorPasswords"
            ErrorMessage="Passwords are not equals!" 
            ControlToCompare="TextBoxPassword"
            ControlToValidate="TextBoxRepeatPassword" 
            runat="server" 
            ForeColor="Red" 
            EnableClientScript="false" 
            Display="None" />

        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorEmail" 
            ForeColor="Red" 
            Display="None"
            ErrorMessage="Email is not valid" 
            ControlToValidate="TextBoxEmail" 
            runat="server" 
            EnableClientScript="false" 
            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}" />

        <asp:RegularExpressionValidator 
            ID="RegularExpressionValidatorPhone" 
            ForeColor="Red" 
            Display="None"
            ErrorMessage="Phone is not valid. Format should be: 0878123456" 
            ControlToValidate="TextBoxPhone" 
            runat="server" 
            EnableClientScript="false" 
            ValidationExpression="[0-9]{10}" />

        <asp:CustomValidator 
            ID="CustomValidatorAccept"
            ErrorMessage="I accept' must be checked" 
            runat="server" 
            Display="None"
            EnableClientScript="false" 
            OnServerValidate="CustomValidatorAccept_ServerValidate" ></asp:CustomValidator>
    </form>
</body>
</html>
