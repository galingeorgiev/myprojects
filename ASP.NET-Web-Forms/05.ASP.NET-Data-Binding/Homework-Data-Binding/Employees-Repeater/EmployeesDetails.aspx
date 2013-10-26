<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeesDetails.aspx.cs" Inherits="Employees_Repeater.EmployeesDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RepeaterEmployees" runat="server" ItemType="Northwind.Data.Employee">
                <ItemTemplate>
                    <tr>
                        <td><%#: Item.FirstName + " " + Item.LastName %></td>
                        <td><%#: Item.City %></td>
                        <td><%#: Item.Country %></td>
                        <td><%#: Item.Address %></td>
                        <td><%#: Item.PostalCode %></td>
                        <td><%#: Item.BirthDate %></td>
                    </tr>
                </ItemTemplate>

                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <td>Full name</td>
                                <td>City</td>
                                <td>Country</td>
                                <td>Address</td>
                                <td>Postal code</td>
                                <td>Birth date</td>
                            </tr>
                        </thead>
                </HeaderTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
