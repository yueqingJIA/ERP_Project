<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_income_statement.aspx.cs" Inherits="ERP._income_statement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
    <style type="text/css">
    body{
            background-color: lightgray;
            font-family: Garamond, Helvetica, sans-serif;
        }
        h2{
            color: dodgerblue;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h2>OH Logistics Limited ERP System</h2>
        <h2>Income Statement<br />
            For the year ended December 31, 2018</h2>
        <p>
            Sales-----------------<asp:Label ID="_sales" runat="server" Text=""></asp:Label>
        </p>
        <p>
            Cost of goods sold---<asp:Label ID="_COGS" runat="server" Text=""></asp:Label>
        </p>
        <p class="auto-style1">
            Gross profit----<asp:Label ID="_GP" runat="server" Text=""></asp:Label>
        </p>
        <p>
            Other income---<asp:Label ID="_OI" runat="server" Text=""></asp:Label>
        </p>
        <p>
            Other expenses-----<asp:Label ID="_OE" runat="server" Text=""></asp:Label>
        </p>
        <p>
            Net income-------<asp:Label ID="_NI" runat="server" Text=""></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
   
    </form>
    
     
</body>
</html>
