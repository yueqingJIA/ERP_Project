<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_banlance_sheet.aspx.cs" Inherits="ERP._banlance_sheet" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
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
        <h2>Statement of Financial Position as at 31 December 2018</h2>
        <table class="auto-style1">
            <tr>
                <td>Current assets</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Non-current assets</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total assets</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Current liabilities</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Non-current liabilities</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Capital</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td>Total Capital and liabilities</td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
        <p>
            <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
        </p>
    
    </div>
    </form>
</body>
</html>
