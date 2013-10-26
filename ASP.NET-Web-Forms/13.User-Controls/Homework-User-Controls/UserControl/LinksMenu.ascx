<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LinksMenu.ascx.cs" Inherits="MenuUserControl.LinksMenu" %>

<asp:DataList runat="server" ID="menuList">
    <ItemTemplate>
        <a href="<%#: Eval("Href") %>"><%#: Eval("Title") %> </a>
    </ItemTemplate>
</asp:DataList>