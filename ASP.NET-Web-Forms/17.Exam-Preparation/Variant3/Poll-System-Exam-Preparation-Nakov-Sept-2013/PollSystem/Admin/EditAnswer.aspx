<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditAnswer.aspx.cs" 
    Inherits="PollSystem.Admin.EditAnswer" %>

<asp:Content ID="ContentEditAnswer" 
    ContentPlaceHolderID="MainContent" runat="server">

    <h1>Edit Answer</h1>

    Answer Text:
    <asp:TextBox ID="TextBoxAnswerText" runat="server" /> 
    <br />
    Votes:
    <asp:TextBox ID="TextBoxVotes" runat="server" /> 
    <br/>
    <asp:LinkButton ID="LinkButtonSave" runat="server" 
        Text="Save" OnClick="LinkButtonSave_Click"/>

</asp:Content>
