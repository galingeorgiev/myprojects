<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Caching.About" %>
<%@ OutputCache Duration="3600" VaryByParam="none" Location="Any" %>
<%@ Register Src="~/UserCashedControl.ascx" TagPrefix="my" TagName="UserCashedControl" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <my:UserCashedControl runat="server" />

</asp:Content>
