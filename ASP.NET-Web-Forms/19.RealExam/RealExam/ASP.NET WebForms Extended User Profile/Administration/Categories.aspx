<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebFormsTemplate.Administration.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Categories</h1>

            <asp:GridView
                runat="server"
                ID="GridViewCategories"
                ItemType="WebFormsTemplate.Models.Category"
                AutoGenerateColumns="false"
                DataKeyNames="Id"
                AllowSorting="true"
                SelectMethod="GridViewCategories_GetData"
                AllowPaging="true"
                PageSize="5"
                ShowFooter="false"
                CssClass="table table-striped table-bordered table-condensed">
                <Columns>
                    <asp:TemplateField HeaderText="Category Name" SortExpression="Name">
                        <ItemTemplate>
                            <%#: Item.Name %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button Text="Edit" 
                                ID="ButtonEdin" 
                                CommandName="EditCategory" 
                                CommandArgument="<%#: Item.Id %>" 
                                OnCommand="ButtonEdin_Command" 
                                CssClass="btn btn-primary" 
                                runat="server" />
                            <asp:Button Text="Delete" 
                                ID="ButtonDelete" 
                                CommandName="DeleteCategory" 
                                CommandArgument="<%#: Item.Id %>" 
                                OnCommand="ButtonDelete_Command"
                                CssClass="btn btn-primary" 
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <asp:ValidationSummary runat="server" ShowModelStateErrors="true" CssClass="text-warning" DisplayMode="SingleParagraph" />

    <asp:Button Text="Create New" ID="ButtonShowCreateNewForm" OnClick="ButtonShowCreateNewForm_Click" runat="server" CssClass="btn btn-primary" />
    <br /><br />

    <asp:Panel runat="server" ID="PanelCreateNewCategory">
        <div class="table table-hovered table-bordered table-condensed">
            <div class="well">
                <h3 class="h3">Create New Category</h3>
            </div>
            <asp:Label Text="Category" runat="server" />
            <asp:TextBox ID="TextBoxCategoryName" Text="" runat="server" />
            <br />
            <asp:Button Text="Create" runat="server" ID="ButtonCreateCategory" OnClick="ButtonCreateCategory_Click" CssClass="btn btn-primary" />
            <asp:Button Text="Cancel" runat="server" ID="ButtonCancelCreate" OnClick="ButtonCancelCreate_Click" CssClass="btn btn-primary" />
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelUpdateCategory">
        <div class="table table-hovered table-bordered table-condensed">
            <div class="well">
                <h3 class="h3">Edit Category</h3>
            </div>
            <asp:Label Text="Category" runat="server" />
            <asp:TextBox ID="TextBoxUpdateCategory" Text="" runat="server" />
            <br />
            <asp:Button Text="Update" runat="server" ID="ButtonUpdateCategory" OnClick="ButtonUpdateCategory_Click" CssClass="btn btn-primary" />
            <asp:Button Text="Cancel" runat="server" ID="ButtonCancelUpdate" OnClick="ButtonCancelUpdate_Click" CssClass="btn btn-primary" />
        </div>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelDelete">
        <div class="table table-hovered table-bordered table-condensed">
            <div class="well">
                <h3 class="h3">Confirm Category Deletion?</h3>
            </div>
            <asp:Label Text="Category" runat="server" />
            <asp:TextBox ID="TextBoxCategoryDelete" Text="" runat="server" />
            <br />
            <asp:Button Text="Yes" runat="server" ID="ButtonYesDelete" OnClick="ButtonYesDelete_Click" CssClass="btn btn-primary" />
            <asp:Button Text="No" runat="server" ID="ButtonNoDelete" OnClick="ButtonNoDelete_Click" CssClass="btn btn-primary" />
        </div>
    </asp:Panel>

    <br />
    <asp:LinkButton Text="Back to books" PostBackUrl="~/Default.aspx" runat="server" />
    <asp:Label Text="" Visible="false" ID="CurrentCategory" runat="server" />

</asp:Content>
