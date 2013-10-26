<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="EmployeesAndOrders.aspx.cs"
    Inherits="EmployeesAndOrders.EmployeesAndOrders" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" />

        <asp:UpdatePanel runat="server" ID="UpdatePanelEmployees">
            <ContentTemplate>
                <asp:GridView
                    runat="server"
                    AutoGenerateColumns="false"
                    AllowPaging="true"
                    PageSize="5"
                    ID="GridViewEmployees"
                    ItemType="EmployeesAndOrders.Employee"
                    DataKeyNames="EmployeeID"
                    SelectMethod="GridViewEmployees_GetData" 
                    AllowSorting="true">
                    <Columns>
                        <asp:BoundField HeaderText="First name" DataField="FirstName" SortExpression="FirstName" />
                        <asp:BoundField HeaderText="Last name" DataField="LastName" />
                        <asp:BoundField HeaderText="Job title" DataField="Title" />
                        <asp:BoundField HeaderText="Country" DataField="Country" />
                        <asp:BoundField HeaderText="City" DataField="City" />
                        <asp:CommandField ButtonType="Link" ShowSelectButton="true" SelectText="View Orders" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

        <asp:UpdateProgress runat="server" ID="UpdateProgressOrders">
            <ProgressTemplate>
                <img src="Images/updating.png" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel runat="server" ID="UpdatePanelOrders">
            <ContentTemplate>
                <asp:GridView
                    AutoGenerateColumns="false"
                    ID="GridViewOrders"
                    ItemType="EmployeesAndOrders.Order"
                    AllowPaging="true"
                    PageSize="5"
                    DataKeyNames="OrderID"
                    runat="server"
                    SelectMethod="GridViewOrders_GetData">
                    <Columns>
                        <asp:BoundField HeaderText="Ship name" DataField="ShipName" />
                        <asp:BoundField HeaderText="Ship Country" DataField="ShipCountry" />
                        <asp:BoundField HeaderText="Ship Address" DataField="ShipAddress" />
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>

    </form>
</body>
</html>
