<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="Offices.aspx.cs" 
    Inherits="Navigation.Offices" 
    MasterPageFile="~/Site.Master" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Offices</h1>
    <p>Our offices:</p>
    <asp:Menu ID="NavigationMenu" runat="server" CssClass="verticalMenu" 
        EnableViewState="False" IncludeStyleBlock="False" SkipLinkText=""
        DataSourceID="SiteMapDataSource" MaximumDynamicDisplayLevels="0">
    </asp:Menu>
    <asp:SiteMapDataSource ID="SiteMapDataSource" runat="server" 
        ShowStartingNode="False" StartingNodeOffset="1" />
</asp:Content>
