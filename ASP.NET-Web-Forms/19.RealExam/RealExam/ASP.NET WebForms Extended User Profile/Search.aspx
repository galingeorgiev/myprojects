<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="WebFormsTemplate.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <asp:Label Text="text" CssClass="search-header" ID="labelHeaderText" runat="server" />
    <br />
    <br />
    <asp:ListView runat="server"
        SelectMethod="ListViewSearchResults_GetData"
        ItemType="WebFormsTemplate.Models.Book">

        <LayoutTemplate>
            <div runat="server" id="itemPlaceholder" />
        </LayoutTemplate>

        <ItemTemplate>
            <div>
                <asp:HyperLink
                    ID="HyperLinkBook"
                    NavigateUrl='<%#: Eval("Id", "~/BookDetails.aspx?id={0}") %>'
                    Text='<%#: Item.Title + " by " + Item.Author %>'
                    runat="server" />
                <span><%#: "(Category: " + Item.Category + ")" %></span>
            </div>
        </ItemTemplate>
    </asp:ListView>

    <br />
    <asp:LinkButton Text="Back to books" PostBackUrl="~/Default.aspx" runat="server" />
</asp:Content>
