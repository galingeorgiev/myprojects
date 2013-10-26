<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModeratorPosts.aspx.cs" Inherits="WebFormsTemplate.ModeratorPosts" %>

<asp:Content ID="BodyContentModerator" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Moderator</h1>
    <asp:GridView 
        ID="GridViewPosts" 
        runat="server" 
        ItemType="WebFormsTemplate.Models.Post" 
        AutoGenerateColumns="false" 
        DataKeyNames="Id"
        OnSelectedIndexChanging="GridViewPosts_SelectedIndexChanging" 
        OnRowDataBound="GridViewPosts_RowDataBound">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/EditPost.aspx?PostId={0}" Text="Edit" />
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="PostText" HeaderText="Post Text" />
        </Columns>
        </asp:GridView>

    <asp:TextBox runat="server" ID="TextBoxAddPost" />
    <asp:Button Text="Add post" ID="ButtonAddNewPost" OnClick="ButtonAddNewPost_Click" runat="server" />
</asp:Content>
