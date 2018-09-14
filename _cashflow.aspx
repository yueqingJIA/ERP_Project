<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_cashflow.aspx.cs" Inherits="ERP._cashflow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style type="text/css">
    body{
            background-color: lightgray;
            font-family: Garamond, Helvetica, sans-serif;
        }
        h2{
            color: dodgerblue;
        }
        
        </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2>OH Logistics Limited ERP System</h2>
        <h2>Statement of Cash Flows<br />
            for the year ended December 31, 2018</h2>
        <br />
        <br />
        Cash Flows from Operating Activities<br />
&nbsp;&nbsp;&nbsp; Receipts from customers --------------------
        <asp:Label ID="_RFC" runat="server" Text=""></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; Payments to suppliers---------<asp:Label ID="_PSE" runat="server" Text=""></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; Total Cash Flows from Operating Activities---<asp:Label ID="_TCFOA" runat="server" Text=""></asp:Label>
        <br />
        <br />
        Cash Flows from Investing Activities<br />
&nbsp;&nbsp;&nbsp; Other Cash items from investing activities---<asp:Label ID="_OCFIA" runat="server" Text=""></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp; Total Cash Flows from Investing Activities ---<asp:Label ID="_TCFFIA" runat="server" Text=""></asp:Label>
        <br />
        <br />
        Net Cash Flow-----------------------<asp:Label ID="_NCF" runat="server" Text=""></asp:Label>
    
        <br />
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    
    </div>
    </form>
</body>
</html>
