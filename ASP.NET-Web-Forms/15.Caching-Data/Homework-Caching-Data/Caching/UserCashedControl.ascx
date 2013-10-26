<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserCashedControl.ascx.cs" Inherits="Caching.UserCashedControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" Shared="true" %>

<h2>I am a cachable user control. I am cashed for 3600 seconds.</h2>
<h2>My time is: <%= DateTime.Now.ToString() %></h2>