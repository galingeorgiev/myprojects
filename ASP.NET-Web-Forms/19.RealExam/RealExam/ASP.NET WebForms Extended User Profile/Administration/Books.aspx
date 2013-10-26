<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="WebFormsTemplate.Administration.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Books</h1>
    <asp:GridView
        runat="server"
        ID="GridViewBooks"
        ItemType="WebFormsTemplate.Models.Book"
        AutoGenerateColumns="false"
        DataKeyNames="Id"
        AllowSorting="true"
        SelectMethod="GridViewBooks_GetData"
        AllowPaging="true"
        PageSize="5"
        ShowFooter="false"
        CssClass="table table-striped table-bordered table-condensed">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: Item.Title %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Author" SortExpression="Author">
                <ItemTemplate>
                    <%#: Item.Author %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ISBN" SortExpression="ISBN">
                <ItemTemplate>
                    <%#: Item.ISBN %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Web Site" SortExpression="WebSite">
                <ItemTemplate>
                    <%#: Item.WebSite %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category" SortExpression="Category">
                <ItemTemplate>
                    <%#: Item.Category %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button
                        Text="Edit"
                        ID="ButtonEdin"
                        CommandName="EditBook"
                        CommandArgument="<%#: Item.Id %>"
                        OnCommand="ButtonEdin_Command"
                        CssClass="btn btn-primary"
                        runat="server" />
                    <asp:Button
                        Text="Delete"
                        ID="ButtonDelete"
                        CommandName="DeleteBook"
                        CommandArgument="<%#: Item.Id %>"
                        OnCommand="ButtonDelete_Command"
                        CssClass="btn btn-primary"
                        runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            <div class="well">
                <p class="text-warning span6">Currently no books found.</p>
            </div>
        </EmptyDataTemplate>

    </asp:GridView>

    <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-warning" DisplayMode="SingleParagraph" />

    <asp:Button Text="CreateNew" ID="ButtonCreateNewBookPanel" OnClick="ButtonCreateNewBookPanel_Click" CssClass="btn btn-primary" runat="server" />



    <asp:Panel ID="PanelCreateNewBook" runat="server">
        <div class="well">
            <h3 class="h3">Create New Book</h3>
        </div>

        <asp:Label Text="Title: " runat="server" />
        <asp:TextBox ID="TextBoxBookTitle" Text="" runat="server" />
        <br />
        <asp:Label Text="Author(s): " runat="server" />
        <asp:TextBox ID="TextBoxBookAuthor" Text="" runat="server" />
        <br />
        <asp:Label Text="ISBN: " runat="server" />
        <asp:TextBox ID="TextBoxBookISBN" Text="" runat="server" />
        <br />
        <asp:Label Text="Web site: " runat="server" />
        <asp:TextBox ID="TextBoxBookWebSite" Text="" runat="server" />
        <br />
        <asp:Label Text="Description: " runat="server" />
        <asp:TextBox ID="TextBoxBookDescription" Text="" runat="server" />
        <br />
        <asp:Label Text="Category: " runat="server" />
        <asp:DropDownList runat="server"
            ID="DropDownListCategories"
            AutoPostBack="false"
            AppendDataBoundItems="true" DataTextField="Name" DataValueField="Id"
            SelectMethod="DropDownListCategories_GetData">
            <asp:ListItem Text="--Select start point--" Value="" />
        </asp:DropDownList>
        <br />
        <asp:Button Text="Create" runat="server" ID="ButtonCreateBook" OnClick="ButtonCreateBook_Click" CssClass="btn btn-primary" />
        <asp:Button Text="Cancel" runat="server" ID="ButtonCancelCreateBook" OnClick="ButtonCancelCreateBook_Click" CssClass="btn btn-primary" />
    </asp:Panel>

    <asp:Panel ID="PanelEditBook" runat="server">
        <div class="well">
            <h3 class="h3">Create New Book</h3>
        </div>

        <asp:Label Text="Title: " runat="server" />
        <asp:TextBox ID="TextBoxEditBookTitle" Text="" runat="server" />
        <br />
        <asp:Label Text="Author(s): " runat="server" />
        <asp:TextBox ID="TextBoxEditBookAuthor" Text="" runat="server" />
        <br />
        <asp:Label Text="ISBN: " runat="server" />
        <asp:TextBox ID="TextBoxEditBookISBN" Text="" runat="server" />
        <br />
        <asp:Label Text="Web site: " runat="server" />
        <asp:TextBox ID="TextBoxEditBookSite" Text="" runat="server" />
        <br />
        <asp:Label Text="Description: " runat="server" />
        <asp:TextBox ID="TextBoxEditBookDescription" Text="" runat="server" />
        <br />
        <asp:Label Text="Category: " runat="server" />
        <asp:DropDownList runat="server"
            ID="DropDownListEditBookCategory"
            AutoPostBack="false"
            AppendDataBoundItems="true"
            DataTextField="Name"
            DataValueField="Id"
            SelectMethod="DropDownListCategories_GetData">
            <asp:ListItem Text="--Select start point--" Value="" />
        </asp:DropDownList>
        <br />
        <asp:Button Text="Save" runat="server" ID="ButtonEditSave" OnClick="ButtonEditSave_Click" CssClass="btn btn-primary" />
        <asp:Button Text="Cancel" runat="server" ID="ButtonEditCancel" OnClick="ButtonEditCancel_Click" CssClass="btn btn-primary" />
    </asp:Panel>

    <asp:Panel ID="PanelDeleteBook" runat="server">
        <div class="well">
            <h3 class="h3">Confirm book deletion?</h3>
        </div>

        <asp:Label Text="Title: " runat="server" />
        <asp:TextBox ID="TextBoxDeleteBookTitle" Text="" runat="server" />
        <br />
        <asp:Button Text="Yes" runat="server" ID="ButtonDeleteBookYes" OnClick="ButtonDeleteBookYes_Click" CssClass="btn btn-primary" />
        <asp:Button Text="No" runat="server" ID="ButtonDeleteBookNo" OnClick="ButtonDeleteBookNo_Click" CssClass="btn btn-primary" />
    </asp:Panel>

    <br /><br />
    <asp:LinkButton Text="Back to books" PostBackUrl="~/Default.aspx" runat="server" />
    <asp:Label Text="" Visible="false" ID="CurrentBook" runat="server" />

</asp:Content>
