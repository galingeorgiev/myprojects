<%@ Page Title="View Questions and Results" Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="EditQuestions.aspx.cs" 
    Inherits="PollSystem.EditQuestions" %>

<asp:Content ID="ContentViewAllResults" ContentPlaceHolderID="MainContent" 
    runat="server">

    <asp:GridView ID="GridViewQuestions" runat="server"
        AutoGenerateColumns="False" DataKeyNames="QuestionId"
        PageSize="3" AllowPaging="true" AllowSorting="true"
        ItemType="PollSystem.Models.Question"
        SelectMethod="GridViewQuestions_GetData"
        DeleteMethod="GridViewQuestions_DeleteItem"
        >
        <Columns>            
            <asp:BoundField DataField="QuestionText" HeaderText="Question"
                SortExpression="QuestionText" />            
            <asp:HyperLinkField Text="Edit..." HeaderText="Action" 
                DataNavigateUrlFields="QuestionId" 
                DataNavigateUrlFormatString="EditQuestion.aspx?questionId={0}" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButtonDeleteQUestion" runat="server" 
                        CommandName="Delete" 
                        CommandArgument="<%# Item.QuestionId %>"
                        OnClientClick = "return confirm('Do you want to cancel ?');"
                        Text="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <a href="EditQuestion.aspx">Create New Question</a>

</asp:Content>
