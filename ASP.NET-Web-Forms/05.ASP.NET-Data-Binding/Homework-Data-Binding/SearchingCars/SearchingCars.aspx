<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchingCars.aspx.cs" Inherits="SearchingCars.SearchingCars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <fieldset id="FormContainer" runat="server">
            <legend>Choose car</legend>
            <asp:DropDownList runat="server" ID="DropDownProducers" OnSelectedIndexChanged="Producer_IndexChanged" AutoPostBack="true">
            </asp:DropDownList>

            <asp:DropDownList runat="server" ID="DropDownModels" AutoPostBack="true">
            </asp:DropDownList>

            <asp:CheckBoxList runat="server" ID="ListOfExtas">
            </asp:CheckBoxList>

            <asp:RadioButtonList runat="server" ID="ListOfEngines">
            </asp:RadioButtonList>

            <asp:Button Text="Find car" runat="server" OnClick="FoundCar_Click" />
        </fieldset>
        <br />
        <asp:Literal Text="" ID="SearchResult" runat="server" />
    </form>
</body>
</html>
