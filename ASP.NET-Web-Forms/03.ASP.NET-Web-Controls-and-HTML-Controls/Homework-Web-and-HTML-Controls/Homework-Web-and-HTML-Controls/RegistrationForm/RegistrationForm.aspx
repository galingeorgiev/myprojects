<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="RegistrationForm.RegistrationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration form</title>
    <style>
        span {
            display:inline-block;
            width: 120px;
        }

        fieldset{
            width:300px;
            margin:0 auto;
        }

        #ButtonRegister{
            float:right;
            margin:15px 15px 0 0;
        }
        
        #RegisterInfo{
            margin:0 auto;
            width:300px;
        }
    </style>
</head>
<body>
    <form id="RegistrationForm" runat="server">
        <fieldset>
            <legend>Registration form</legend>
            <asp:Label Text="First name" runat="server" for="TextBoxFirstName" />
            <asp:TextBox runat="server" ID="TextBoxFirstName" />
            <br />
            <asp:Label Text="Last name" runat="server" for="TextBoxLastName" />
            <asp:TextBox runat="server" ID="TextBoxLastName" />
            <br />
            <asp:Label Text="Faculty number" runat="server" for="TextBoxFacultyNumber" />
            <asp:TextBox runat="server" ID="TextBoxFacultyNumber" />
            <br />
            <asp:Label Text="Select university" runat="server" for="DropDownListUniversity" />
            <asp:DropDownList runat="server" ID="DropDownListUniversity">
                <asp:ListItem Text="SU" Value="SU" />
                <asp:ListItem Text="TU" Value="TU" />
                <asp:ListItem Text="Telerik Academy" Value="Telerik Academy" />
            </asp:DropDownList>
            <br />
            <asp:Label Text="Select speciality" runat="server" for="DropDownListSpeciality" />
            <asp:DropDownList runat="server" ID="DropDownListSpeciality">
                <asp:ListItem Text="Web" Value="Web" />
                <asp:ListItem Text="Desktop" Value="Desktop" />
            </asp:DropDownList>
            <br />
            <asp:Label Text="Select course" runat="server" for="DropDownListCourses" />
            <asp:DropDownList runat="server" ID="DropDownListCourses">
                <asp:ListItem Text="C#" Value="C#" />
                <asp:ListItem Text="JS" Value="JS" />
                <asp:ListItem Text="PHP" Value="PHP" />
            </asp:DropDownList>
            <br />
            <asp:Button Text="Register" runat="server" ID="ButtonRegister" OnClick="Register_Click" />
        </fieldset>
        <asp:PlaceHolder runat="server" ID="RegisterInfo" />
    </form>
</body>
</html>
