<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Escaping.aspx.cs" Inherits="Escaping.Escaping" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="escaping" runat="server">
    <div>
        <asp:Label Text="Enter HTML tag here: " runat="server" />
        <asp:TextBox runat="server" ID="TextBoxInput" />
        <asp:Button Text="Show text" OnClick="ShowText_Click" runat="server" />
        <asp:TextBox runat="server" ID="TextBoxOutput" ReadOnly="true" />
        <asp:Label Text="" ID="LabelOutput" runat="server" />
    </div>
    </form>
</body>
</html>
