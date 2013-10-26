<%@ Page Title="Edit Question" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs"
    Inherits="PollSystem.Admin.EditQuestion" %>

<asp:Content ID="ContentEditQuestion" ContentPlaceHolderID="MainContent"
    runat="server">

    <h1>Edit Question</h1>

    Question Text:
    <asp:TextBox ID="TextBoxQuestionText" runat="server" /> 
    <asp:LinkButton ID="LinkButtonSaveQuestion" runat="server" 
        Text="Save" OnClick="LinkButtonSaveQuestion_Click"/>

    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server"
            ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %> --> <%#: Item.Votes %>
                    <a href="EditAnswer.aspx?answerId=<%# Item.AnswerId %>">Edit...</a>
                    <asp:LinkButton Text="Delete" runat="server" 
                        CommandName="Delete" CommandArgument="<%# Item.AnswerId %>"
                        OnClientClick = "return confirm('Do you want to cancel ?');"
                        OnCommand="Delete_Command" />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:LinkButton ID="LinkButtonCreateNewAnswer" runat="server"
        Text="Create New Answer" Visible="false"
        OnClick="LinkButtonCreateNewAnswer_Click" />

</asp:Content>
