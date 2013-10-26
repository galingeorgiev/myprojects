<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Cookies.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="formLogin" runat="server">
        <p>Enter username and press 'Login'. After that press 'Go to Home page'!</p>
    <fieldset>
        <legend>Login form</legend>
        <asp:TextBox runat="server" ID="TextBoxUsername" />
        <asp:Button Text="Login" runat="server" ID="ButtonLogin" OnClick="ButtonLogin_Click" />
        <asp:Button Text="Go to Home page" runat="server" ID="ButtonGoToHomePage" OnClick="ButtonGoToHomePage_Click" />
    </fieldset>
    </form>
</body>
</html>
