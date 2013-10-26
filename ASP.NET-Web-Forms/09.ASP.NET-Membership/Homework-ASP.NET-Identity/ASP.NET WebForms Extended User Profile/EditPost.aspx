<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditPost.aspx.cs" Inherits="WebFormsTemplate.EditPost" %>

<asp:Content ID="ContentEditPage" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label Text="" ID="LabelAuthor" runat="server" />
    <asp:Label Text="Post Text" ID="LabelPostText" runat="server" />
    <asp:TextBox runat="server" ID="TextBoxPost" />
    <asp:Button Text="Save changes" runat="server" ID="ButtonSaveChanges" OnClick="ButtonSaveChanges_Click" />
</asp:Content>
