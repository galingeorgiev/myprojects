<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPosts.aspx.cs" Inherits="WebFormsTemplate.UserPosts" %>

<asp:Content ID="BodyContentUser" ContentPlaceHolderID="MainContent" runat="server">
    <h1>User</h1>
    <asp:GridView 
        ID="GridViewPosts" 
        runat="server" 
        ItemType="WebFormsTemplate.Models.Post" 
        AutoGenerateColumns="false" 
        DataKeyNames="Id"
        OnRowDataBound="GridViewPosts_RowDataBound">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="PostText" HeaderText="Post Text" />
        </Columns>
        </asp:GridView>

    <asp:TextBox runat="server" ID="TextBoxAddPost" />
    <asp:Button Text="Add post" ID="ButtonAddNewPost" OnClick="ButtonAddNewPost_Click" runat="server" />
</asp:Content>
