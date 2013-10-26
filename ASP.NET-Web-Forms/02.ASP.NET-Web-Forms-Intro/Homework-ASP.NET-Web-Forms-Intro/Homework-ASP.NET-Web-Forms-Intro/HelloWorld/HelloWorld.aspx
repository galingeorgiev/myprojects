<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HelloWorld.aspx.cs" Inherits="HelloWorld.HelloWorld" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello</title>
</head>
<body>
    <form id="helloWorld" runat="server">
    <div>
        <label for="TextBoxName">Enter you name: </label>
        <asp:TextBox runat="server" ID="TextBoxName" />
        <asp:Button Text="Show message" runat="server" OnClick="ShowMessage_Click" />
        <asp:TextBox runat="server" ID="TextBoxMessage" />
    </div>
    </form>
</body>
</html>
