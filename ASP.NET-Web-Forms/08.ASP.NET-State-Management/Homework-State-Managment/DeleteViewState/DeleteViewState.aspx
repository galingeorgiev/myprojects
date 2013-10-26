<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteViewState.aspx.cs" Inherits="DeleteViewState.DeleteViewState" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <%--<script>
        document.getElementById("__VIEWSTATE").removeNode();
    </script>--%>
    <p>Get script from DeleteViewState.aspx (comment in code) and paste it in textbox. Then pres Execute button. This will remove viewstate node.</p>
    <p>In Chrome does not work and throw this message in console: 'Resource interpreted as Script but transferred with MIME type text/html: "http://localhost:28954/__vwd/js/artery".'</p>
    <p>I test it in IE10 and work fine.</p>
    <form id="formDeleteViewState" runat="server">
        <asp:TextBox runat="server" ID="TextBoxAcceptScript" />
        <asp:Button Text="Execute" ID="ButtonExecute" OnClick="ButtonExecute_Click" runat="server" />
        <asp:Literal Text="" ID="LiteralExecuteScript" runat="server" />
    </form>
</body>
</html>
