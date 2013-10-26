<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterFormGrouping.aspx.cs" Inherits="RegisterFormGrouping.RegisterFormGrouping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset>
            <legend>Register form</legend>

            <fieldset>
                <legend>Logon info</legend>
                <label>Username: </label>
                <asp:TextBox runat="server" ID="TextBoxUsername" ValidationGroup="LogonInfo" />
                <br />

                <label>Password: </label>
                <asp:TextBox runat="server" ID="TextBoxPassword" ValidationGroup="LogonInfo" />
                <br />

                <label>Repeat Password: </label>
                <asp:TextBox runat="server" ID="TextBoxRepeatPassword" ValidationGroup="LogonInfo" />
                <br />
                <asp:Button Text="Check Logon info" ID="ButtonLogonInfo" OnClick="ButtonCheckLogonInfo_Click" runat="server" />
            </fieldset>

            <fieldset>
                <legend>Personal info</legend>
                <label>First name: </label>
                <asp:TextBox runat="server" ID="TextBoxFirstName" ValidationGroup="PersonalInfo" />
                <br />

                <label>Last name: </label>
                <asp:TextBox runat="server" ID="TextBoxLastName" ValidationGroup="PersonalInfo" />
                <br />

                <label>Age: </label>
                <asp:TextBox runat="server" ID="TextBoxAge" ValidationGroup="PersonalInfo" />
                <br />

                <label>Email: </label>
                <asp:TextBox runat="server" ID="TextBoxEmail" ValidationGroup="PersonalInfo" />
                <br />

                <label>Phone: </label>
                <asp:TextBox runat="server" ID="TextBoxPhone" ValidationGroup="PersonalInfo" />
                <br />
                <asp:Button Text="Check Personal info" ID="ButtonCheckPersonalInfo" OnClick="ButtonCheckPersonalInfo_Click" runat="server" />
            </fieldset>

            <fieldset>
                <legend>Address info</legend>
                <label>Local Address: </label>
                <asp:TextBox runat="server" ID="TextBoxAddress" ValidationGroup="AddressInfo" />
                <br />
                <asp:Button Text="Check Address info" ID="ButtonCheckAddressInfo" OnClick="ButtonCheckAddressInfo_Click" runat="server" />
            </fieldset>

            <asp:CheckBox Text="I accept" runat="server" ID="CheckBoxAccept" />
            <br />
            <asp:Button Text="Register" ID="ButtonRegister" runat="server" />
        </fieldset>

        <asp:ValidationSummary runat="server" ID="ValidationSummaryRegisterForm" />
        <asp:Label Text="" ID="LabelIsValid" runat="server" />

        <asp:RequiredFieldValidator
            ErrorMessage="Username is required!" ID="RequiredFieldValidatorUsername"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxUsername"
            runat="server"
            EnableClientScript="false" 
            ValidationGroup="LogonInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="Password is required!" ID="RequiredFieldValidatorPassword"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxPassword"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="LogonInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="repeat password is required!" ID="RequiredFieldValidatorRepeatPassword"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxRepeatPassword"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="LogonInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="First name is required!" ID="RequiredFieldValidatorFirstName"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxFirstName"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="PersonalInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="Last name is required!" ID="RequiredFieldValidatorLastName"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxLastName"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="PersonalInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="Age is required!" ID="RequiredFieldValidatorAge"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxAge"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="PersonalInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="Email is required!" ID="RequiredFieldValidatorEmail"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxEmail"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="PersonalInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="Local address is required!" ID="RequiredFieldValidatorAddress"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxAddress"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="AddressInfo" />

        <asp:RequiredFieldValidator
            ErrorMessage="Phone is required!" ID="RequiredFieldValidatorPhone"
            ForeColor="Red"
            Display="None"
            ControlToValidate="TextBoxPhone"
            runat="server"
            EnableClientScript="false"
            ValidationGroup="PersonalInfo" />

        <asp:RangeValidator ID="RangeValidatorAge"
            ErrorMessage="Age should be between 18 and 81."
            ControlToValidate="TextBoxAge"
            runat="server"
            ForeColor="Red"
            Display="None"
            Type="Integer"
            MinimumValue="18"
            MaximumValue="81"
            EnableClientScript="false"
            ValidationGroup="PersonalInfo" />

        <asp:CompareValidator
            ID="CompareValidatorPasswords"
            ErrorMessage="Passwords are not equals!"
            ControlToCompare="TextBoxPassword"
            ControlToValidate="TextBoxRepeatPassword"
            runat="server"
            ForeColor="Red"
            EnableClientScript="false"
            Display="None"
            ValidationGroup="LogonInfo" />

        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorEmail"
            ForeColor="Red"
            Display="None"
            ErrorMessage="Email is not valid"
            ControlToValidate="TextBoxEmail"
            runat="server"
            EnableClientScript="false"
            ValidationExpression="[a-zA-Z][a-zA-Z0-9\-\.]*[a-zA-Z]@[a-zA-Z][a-zA-Z0-9\-\.]+[a-zA-Z]+\.[a-zA-Z]{2,4}"
            ValidationGroup="PersonalInfo" />

        <asp:RegularExpressionValidator
            ID="RegularExpressionValidatorPhone"
            ForeColor="Red"
            Display="None"
            ErrorMessage="Phone is not valid. Format should be: 0878123456"
            ControlToValidate="TextBoxPhone"
            runat="server"
            EnableClientScript="false"
            ValidationExpression="[0-9]{10}"
            ValidationGroup="PersonalInfo" />

        <asp:CustomValidator
            ID="CustomValidatorAccept"
            ErrorMessage="I accept' must be checked"
            runat="server"
            Display="None"
            EnableClientScript="false"
            OnServerValidate="CustomValidatorAccept_ServerValidate"></asp:CustomValidator>
    </form>
</body>
</html>
