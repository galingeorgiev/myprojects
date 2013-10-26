<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeView.aspx.cs" Inherits="TreeView.TreeView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tree view</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:XmlDataSource ID="BooksCatalog" runat="server" DataFile="BooksCatalog.xml"></asp:XmlDataSource>
        <asp:TreeView ID="TreeViewBooksCatalog" runat="server" DataSourceID="BooksCatalog" ShowCheckBoxes="Leaf" ImageSet="Arrows">
            <DataBindings>
                <asp:TreeNodeBinding DataMember="Catalog" Text="Catalog" />
            </DataBindings>
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
        <br />
        <asp:Button ID="ShowResult" runat="server" Text="Show Result" OnClick="ShowResult_Click" />
        <asp:Literal ID="CheckedNodeInfo" runat="server" Mode="Encode">
        </asp:Literal>
    </form>
</body>
</html>
