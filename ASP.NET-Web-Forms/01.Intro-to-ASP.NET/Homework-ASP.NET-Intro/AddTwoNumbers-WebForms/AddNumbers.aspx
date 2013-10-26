<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNumbers.aspx.cs" Inherits="AddTwoNumbers_WebForms.AddNumbers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label Text="Enter first number" runat="server" />
            <asp:TextBox ID="TextBoxFirstNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label Text="Enter second number" runat="server" />
            <asp:TextBox ID="TextBoxSecondNumber" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="ButtonSum" runat="server" OnClick="ButtonSum_Click" Text="Button" />
        </div>
        <asp:Label ID="LabelResult" runat="server"></asp:Label>
    </form>
</body>
</html>
