<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="Employees.Employees" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView 
                runat="server" 
                ID="GridViewEpmloyees" 
                AutoGenerateColumns="false" 
                AllowPaging="true" >
                <Columns>
                    <asp:HyperLinkField 
                        DataNavigateUrlFields="Id" 
                        DataNavigateUrlFormatString="EmpDetails.aspx?id={0}" 
                        DataTextField="FullName" 
                        HeaderText="Employee Full Name"/>
                </Columns>  
            </asp:GridView>
        </div>
    </form>
</body>
</html>
