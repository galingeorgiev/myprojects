<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPosts.aspx.cs" Inherits="WebFormsTemplate.AdminPosts" %>

<asp:Content ID="BodyContentAdmin" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Admin</h1>
    <asp:GridView 
        ID="GridViewPosts" 
        runat="server" 
        ItemType="WebFormsTemplate.Models.Post" 
        AutoGenerateColumns="false" 
        DataKeyNames="Id" >
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="~/EditPost.aspx?PostId={0}" Text="Edit" />
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton 
                            ID="ButtonDelete" 
                            runat="server" 
                            CommandName="DeletePost" 
                            CommandArgument='<%# Eval("Id") %>' 
                            OnCommand="ButtonDelete_Command"
                            Text="Delete" />
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="PostText" HeaderText="Post Text" />
        </Columns>
        </asp:GridView>

    <asp:TextBox runat="server" ID="TextBoxAddPost" />
    <asp:Button Text="Add post" ID="ButtonAddNewPost" OnClick="ButtonAddNewPost_Click" runat="server" />
     
</asp:Content>
