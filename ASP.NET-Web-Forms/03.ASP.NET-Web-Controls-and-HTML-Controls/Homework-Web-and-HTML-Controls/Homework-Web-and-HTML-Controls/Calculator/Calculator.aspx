<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Calculator.aspx.cs" Inherits="Calculator.Calculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculator</title>
    <style>
        input[type="submit"]{
            width: 60px;
        }

        input[type="text"]{
            width: 248px;
        }

        #ButtonEqual{
            width:252px;
        }

        #CalculatorContainer{
            width: 260px;
            margin: 0 auto;
            padding:15px;
            border: 1px solid black;
        }
    </style>
</head>
<body>
    <form id="Calculator" runat="server">
    <div id="CalculatorContainer">
        <asp:TextBox ID="TextBoxNums" runat="server" />
        <br />
        <asp:Button ID="ButtonOne" OnClick="ButtonOne_Click" Text="1" runat="server" />
        <asp:Button ID="ButtonTwo" OnClick="ButtonTwo_Click" Text="2" runat="server" />
        <asp:Button ID="ButtonThree" OnClick="ButtonThree_Click" Text="3" runat="server" />
        <asp:Button ID="ButtonPlus" OnClick="ButtonPlus_Click" Text="+" runat="server" />
        <br />
        <asp:Button ID="ButtonFour" OnClick="ButtonFour_Click" Text="4" runat="server" />
        <asp:Button ID="ButtonFive" OnClick="ButtonFive_Click" Text="5" runat="server" />
        <asp:Button ID="ButtonSix" OnClick="ButtonSix_Click" Text="6" runat="server" />
        <asp:Button ID="ButtonMinus" OnClick="ButtonMinus_Click" Text="-" runat="server" />
        <br />
        <asp:Button ID="ButtonSeven" OnClick="ButtonSeven_Click" Text="7" runat="server" />
        <asp:Button ID="ButtonEight" OnClick="ButtonEight_Click" Text="8" runat="server" />
        <asp:Button ID="ButtonNine" OnClick="ButtonNine_Click" Text="9" runat="server" />
        <asp:Button ID="ButtonMultiplication" OnClick="ButtonMultiplication_Click" Text="x" runat="server" />
        <br />
        <asp:Button ID="ButtonClear" OnClick="ButtonClear_Click" Text="Clear" runat="server" />
        <asp:Button ID="ButtonZero" OnClick="ButtonZero_Click" Text="0" runat="server" />
        <asp:Button ID="ButtonDivision" OnClick="ButtonDivision_Click" Text="/" runat="server" />
        <asp:Button ID="ButtonSquareRoot" OnClick="ButtonSquareRoot_Click" Text="&#8730;" runat="server" />
        <br />
        <asp:Button ID="ButtonEqual" OnClick="ButtonEqual_Click" Text="=" runat="server" />
    </div>
    </form>
</body>
</html>
