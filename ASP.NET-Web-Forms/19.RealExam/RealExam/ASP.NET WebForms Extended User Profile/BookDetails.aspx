<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDetails.aspx.cs" Inherits="WebFormsTemplate.BookDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br /><br />
    <h2>Book Details</h2>

    <asp:FormView ID="FormViewBook" runat="server" 
        ItemType="WebFormsTemplate.Models.Book" 
        SelectMethod="FormViewBook_GetItem" 
        CssClass="table table-striped table-bordered table-condensed">
            <ItemTemplate>
                <div class="well"><%#: Item.Title %> <br /></div>
                by <%#: Item.Author %> <br />
                ISBN: <%#: Item.ISBN %> <br />
                Web Site: <a href="<%#: Item.WebSite %>"><%#: Item.WebSite %></a>  <br />
                <%#: Item.Description %> <br />
            </ItemTemplate>
        </asp:FormView>

    <asp:HyperLink NavigateUrl="~/" runat="server" />

    <br />
    <asp:LinkButton Text="Back to books" PostBackUrl="~/Default.aspx" runat="server" />
</asp:Content>
