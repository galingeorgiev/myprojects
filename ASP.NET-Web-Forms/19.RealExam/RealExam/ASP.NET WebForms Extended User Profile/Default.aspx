<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsTemplate._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <br />

    <h1>Books</h1>

    <asp:TextBox runat="server" ID="TextBoxSearch" />
    <asp:Button Text="Search" runat="server" ID="ButtonSearch" OnClick="ButtonSearch_Click" />

    <br /><br />

    <asp:ListView runat="server"
        ID="ListViewCategories"
        ItemType="WebFormsTemplate.Models.Category"
        DataKeyNames="Id"
        SelectMethod="ListViewCategories_GetData">

        <LayoutTemplate>
            <div runat="server" id="itemPlaceholder" />
        </LayoutTemplate>

        <ItemTemplate>
            <div class="book-list">
                <h2><%#: Item.Name %></h2>
                <asp:Repeater runat="server"
                    ItemType="WebFormsTemplate.Models.Book"
                    DataSource="<%# Item.Books %>">
                    <ItemTemplate>
                        <asp:HyperLink
                            ID="HyperLinkBook"
                            NavigateUrl='<%#: Eval("Id", "~/BookDetails.aspx?id={0}") %>'
                            Text='<%#: Item.Title + " by " + Item.Author %>'
                            runat="server" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <%--<br />
    <asp:LinkButton Text="Back to books" PostBackUrl="~/Default.aspx" runat="server" />--%>

</asp:Content>
