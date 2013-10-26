<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuControlExample.aspx.cs" Inherits="MenuUserControl.MenuControlExample" %>
<%@ Register tagprefix="userControls" Assembly="UserControl" Namespace="MenuUserControl"%>
<%@ Register TagPrefix="userControls" src="LinksMenu.ascx" TagName="LinksMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <usercontrols:LinksMenu runat="server" id="linkMenu">
                    <Items>
                        <userControls:MenuItem Title="Nakov" Href="http://www.nakov.com/" runat="server" />
                        <userControls:MenuItem Title="Doncho" Href="http://www.minkov.it/" runat="server" />
                        <userControls:MenuItem Title="Joro" Href="http://www.itgeorge.net/" runat="server" />
                    </Items>
                </usercontrols:LinksMenu>
        </div>
    </form>
</body>
</html>
