<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RandomNumberInRange.aspx.cs" Inherits="RandomNumberInRange.RandomNumberInRange" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Generate random number</title>
    <style>
        #InputResultNumber{
            width:300px;
        }
    </style>
</head>
<body>
    <form id="randomNumberInRange" runat="server">
    <div>
        <label for="InputFirstValue">Enter first number</label>
        <input runat="server" id="InputFirstValue" type="text" name="firstValue" value=" " placeholder="From" />
        <label for="InputSecondValue">Enter second number</label>
        <input runat="server" id="InputSecondValue" type="text" name="secondValue" value=" " placeholder="To" />
        <input runat="server" type="button" id="ButtonGenerateRandomNumber" onserverclick="ButtonGenerateRandomNumber_Click" value="Generate" />
        <input runat="server" type="text" id="InputResultNumber" name="name" value=" " readonly="true" />
    </div>
    </form>
</body>
</html>
