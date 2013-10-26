<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees_ListView.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListView ID="ListViewEmployees" runat="server" ItemType="Northwind.Data.Employee">
            <LayoutTemplate>
                <h3>Employees</h3>
                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
            </LayoutTemplate>

            <ItemSeparatorTemplate>
                <hr />
            </ItemSeparatorTemplate>

            <ItemTemplate>
                <h4><%#: Item.FirstName + "" + Item.LastName %></h4>
                Country: <%#: Item.Country %>
                <br />
                City: <%#: Item.City %>
                <br />
                Address: <%#: Item.Address %>
                <br />
                Postal code: <%#: Item.PostalCode %>
            </ItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
