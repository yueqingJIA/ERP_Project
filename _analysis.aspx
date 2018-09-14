<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_analysis.aspx.cs" Inherits="ERP._analysis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style type="text/css">
    body{
            background-color: lightgray;
            font-family: Garamond, Helvetica, sans-serif;
        }
        h1{
            color: dodgerblue;
        }
        
        </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h1>OH Logistics Limited ERP System</h1>
        <p>
            <asp:Button ID="_WC" runat="server" Text="Working Capital" OnClick="_WC_Click" Width="450px" />
&nbsp;&nbsp;
            </p>
        <p>
            <asp:Button ID="_CR" runat="server" Text="Current Ratio" OnClick="_CR_Click" Width="450px" />
        </p>
        <p>
            <asp:Button ID="_ATR" runat="server" Text="Acid-test Ratio" OnClick="_ATR_Click" Width="450px" />
&nbsp;</p>
        <p>
            <asp:Button ID="_TRT" runat="server" Text="Trade Receivables Turnover" OnClick="_TRT_Click" Width="450px" />
&nbsp;</p>
        <p>
            <asp:Button ID="_ATRCP" runat="server" Text="Average Trade Receivables Collection Period" OnClick="_ATRCP_Click" Width="450px" />
&nbsp;</p>
        <p>
            <asp:Button ID="_TPT" runat="server" Text="Trade Payables Turnover" OnClick="_TPT_Click" Width="450px" />
&nbsp;&nbsp;
            </p>
        <p>
            <asp:Button ID="_ATPRP" runat="server" Text="Average Trade Payables Repayment Period" OnClick="_ATPRP_Click" Width="450px" />
        </p>
    
    </div>
        <asp:Label ID="_ratio" runat="server" Text="Ratio" Visible="False" Font-Size="Large"></asp:Label>
        <br />
        <asp:Label ID="_formula" runat="server" Visible="False" Font-Size="Large"></asp:Label>
        <br />
        <asp:Label ID="_result" runat="server" Visible="False" Font-Size="Large"></asp:Label>
        <p>
            <asp:Button ID="_back" runat="server" Text="Back" OnClick="_back_Click" />
        </p>
    </form>
</body>
</html>
