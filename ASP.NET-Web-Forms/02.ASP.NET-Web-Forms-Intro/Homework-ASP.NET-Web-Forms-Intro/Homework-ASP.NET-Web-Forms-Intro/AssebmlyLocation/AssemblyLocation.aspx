<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssemblyLocation.aspx.cs" Inherits="AssebmlyLocation.AssemblyLocation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hello C#</title>
    <style>
        input{
            width:90%;
        }
    </style>
</head>
<body>
    <form id="assemblyLocation" runat="server">
    <div>
        <p>Hello C# from aspx code!</p>
        <asp:TextBox runat="server" ID="TextBox" ReadOnly="true" />
        <br />
        <asp:TextBox runat="server" ID="TextBoxLocation" ReadOnly="true" />
    </div>
    </form>
</body>
</html>
