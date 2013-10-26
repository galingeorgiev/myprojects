<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees_SinglePage.Emploees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FormView ID="FormViewEmployee" runat="server" AllowPaging="True" OnPageIndexChanging="FormViewEmployee_PageIndexChanging" >
            <ItemTemplate>
                <h3><%# Eval("FirstName") + " " + Eval("LastName") %></h3>
                <table border="0">
                    <tr>
                        <td>City:</td>
                        <td><%# Eval("City")%></td>
                    </tr>
                    <tr>
                        <td>HomePhone:</td>
                        <td><%# Eval("HomePhone")%></td>
                    </tr>
                </table>
                <hr />
            </ItemTemplate>
        </asp:FormView>
        </div>
    </form>
</body>
</html>
