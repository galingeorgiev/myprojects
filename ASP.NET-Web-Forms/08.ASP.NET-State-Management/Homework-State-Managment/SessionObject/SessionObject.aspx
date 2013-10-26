<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SessionObject.aspx.cs" Inherits="SessionObject.SessionObject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox runat="server" ID="TextBoxContent" Width="400" />
        <asp:Button Text="Add text" ID="ButtonAddText" OnClick="ButtonAddText_Click" runat="server" />
        <asp:Button Text="Show text" ID="ButtonShowText" OnClick="ButtonShowText_Click" runat="server" />
        <br />
        <asp:Literal Text="" ID="LiteralTextContainer" runat="server" />
    </form>
</body>
</html>
