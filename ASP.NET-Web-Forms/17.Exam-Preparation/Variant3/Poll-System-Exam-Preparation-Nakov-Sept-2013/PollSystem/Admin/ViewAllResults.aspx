<%@ Page Title="View Questions and Results" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="ViewAllResults.aspx.cs" 
    Inherits="PollSystem.ViewAllResults" %>

<asp:Content ID="ContentViewAllResults" ContentPlaceHolderID="MainContent" 
    runat="server">

    <asp:GridView ID="GridViewQuestions" runat="server"
        AutoGenerateColumns="False" DataKeyNames="QuestionId"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        SelectMethod="GridViewQuestions_GetData"
        OnSelectedIndexChanged="GridViewQuestions_SelectedIndexChanged">
        <Columns>            
            <asp:BoundField DataField="QuestionText" HeaderText="Question"
                SortExpression="QuestionText" />            
            <asp:CommandField ShowSelectButton="True" SelectText="Details..." HeaderText="Action" />
        </Columns>
    </asp:GridView>

    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server"
            ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %> --> <%#: Item.Votes %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

</asp:Content>
