<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberInRange.aspx.cs" Inherits="RandomNumber_Web.RandomNumberInRange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate random number</title>
    <style>
        #TextBoxResultNumber{
            width: 300px;
        }
    </style>
</head>
<body>
    <form id="randomNumberInRange" runat="server">
    <div>
        <asp:Label Text="Enter first number" runat="server" for="TextBoxFirstNumber" />
        <asp:TextBox runat="server" ID="TextBoxFirstNumber" />
        <asp:Label Text="Enter second number" runat="server" for="TextBoxSecondNumber" />
        <asp:TextBox runat="server" ID="TextBoxSecondNumber" />
        <asp:Button Text="Generate" runat="server" OnClick="GenerateRandomNumber_Click" />
        <asp:TextBox runat="server" ID="TextBoxResultNumber" />
    </div>
    </form>
</body>
</html>
