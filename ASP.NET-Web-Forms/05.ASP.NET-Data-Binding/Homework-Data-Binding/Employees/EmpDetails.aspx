<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpDetails.aspx.cs" Inherits="Employees.EmpDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HyperLink NavigateUrl="Employees.aspx" runat="server" Text="Back" />
        <div>
            <asp:DetailsView runat="server" ID="EmployeeDetails" AutoGenerateRows="true" CellPadding="4" />
        </div>
    </form>
</body>
</html>
