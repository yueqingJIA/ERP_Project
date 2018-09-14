<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="T_Account.aspx.cs" Inherits="ERP.T_Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 790px;
        }
        #Select1 {
            width: 145px;
        }
        #Select2 {
            width: 144px;
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
    <h2>
        <br />
        OH Logistics Limited ERP System</h2>
    <form id="form1" runat="server">
        <div>
            <h1>T Account</h1>
            <br />
            <table class="auto-style1">
                <tr>
                    <td>Debit</td>
                    <td>
                        <asp:TextBox ID="Debit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Credit</td>
                    <td>
                        <asp:TextBox ID="Credit" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Amount</td>
                    <td>
                        <asp:TextBox ID="Amount" runat="server"></asp:TextBox>
                    &nbsp; Currency
                        <asp:DropDownList ID="_Currency" runat="server" AutoPostBack="true">
                            <asp:ListItem>HKD</asp:ListItem>
                            <asp:ListItem>RMB</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                            <asp:ListItem>EUR</asp:ListItem>
                            <asp:ListItem>GBP</asp:ListItem>
                        </asp:DropDownList>&nbsp;<asp:Button ID="_ViewCurrency" runat="server" Text="View Currency rate" OnClick="_ViewCurrency_Click" />
&nbsp;&nbsp;
                        <asp:Label ID="Lbl_currency" runat="server" Text="" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                       
                        Date</td>
                    <td>
                        <asp:TextBox ID="Date" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                    </td>
                </tr>
            </table>

        </div>
        <p>
            <asp:Button ID="Add" runat="server" Height="24px" OnClick="Add_Click" Text="Add" Width="144px" />
                        <asp:Label ID="LbMessage" runat="server" Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Button ID="_View" runat="server" Text="View T Account" OnClick="_View_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Add_Taccount" runat="server" Text="Add new Taccount" OnClick="Add_Taccount_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
        </p>
    </form>
</body>
</html>
