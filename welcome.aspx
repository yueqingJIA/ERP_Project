<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="ERP.welcome" %>

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
        <br />
    
        Hello
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        , Welcome to OH Logistics Limited ERP system!<br />
        Your Identity:
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    
    </div>
        <br />
        <asp:Button ID="T_Account" runat="server" OnClick="T_Account_Click" style="height: 21px" Text="T Account" />
      
        <p>
            <asp:Button ID="Cash_Flow_Statement" runat="server" Text="Cash Flow Statement" Visible="False" OnClick="Cash_Flow_Statement_Click"/>
        </p>
        <asp:Button ID="Basic_Analysis" runat="server" Text="Basic Financial Analysis " Visible="False" OnClick="Basic_Analysis_Click"/>
        <p>
            <asp:Button ID="Income_Statement" runat="server" Text="Income Statement" Visible="False" OnClick="Income_Statement_Click"/>
        </p>
        <p>
            <asp:Button ID="Invoice" runat="server" Text="Draft Invoice" OnClick="Invoice_Click" />
        </p>
        <p>
            <asp:Button ID="BS" runat="server" Text="Statement of Financial Position" OnClick="BS_Click" Visible="False" />
        </p>
        <p>
            <asp:Button ID="EL" runat="server" Text="Edit List" OnClick="EL_Click" Visible="False" />
        </p>
    <p>
        <asp:Button ID="Currency" runat="server" Text="Change Currency" OnClick="Currency_Click" Visible="False" />
        </p>
        <p>
            &nbsp;</p>
    </form>
    </body>
</html>
