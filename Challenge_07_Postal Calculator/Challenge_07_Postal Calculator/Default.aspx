﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Challenge_07_Postal_Calculator.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Postal Calculator<br />
        <br />
        Width:
        <asp:TextBox ID="widthTextBox" runat="server" AutoPostBack="True"></asp:TextBox>
        <br />
        Height:
        <asp:TextBox ID="heightTextBox" runat="server" AutoPostBack="True"></asp:TextBox>
        <br />
        Length:
        <asp:TextBox ID="lengthTextBox" runat="server" AutoPostBack="True"></asp:TextBox>
        <br />
        <br />
        <asp:RadioButton ID="groundRadioButton" runat="server" AutoPostBack="True" GroupName="Shipping" OnCheckedChanged="groundRadioButton_CheckedChanged" Text="Ground" />
        <br />
        <asp:RadioButton ID="airRadioButton" runat="server" AutoPostBack="True" GroupName="Shipping" OnCheckedChanged="airRadioButton_CheckedChanged" Text="Air" />
        <br />
        <asp:RadioButton ID="nextDayRadioButton" runat="server" AutoPostBack="True" GroupName="Shipping" OnCheckedChanged="nextDayRadioButton_CheckedChanged" Text="Next Day" />
        <br />
        <br />
        <asp:Label ID="resultLabel" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
