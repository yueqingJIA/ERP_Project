<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_ViewTaccount.aspx.cs" Inherits="ERP._ViewTaccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 493px;
        }
        .auto-style2 {
            width: 253px;
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
    
    </div>
        <asp:TextBox ID="_TAccount" runat="server" Height="16px"></asp:TextBox>
        <asp:Button ID="_View" runat="server" Text="View TAccount" OnClick="_View_Click" />
        <br />
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
        <p>
            &nbsp;</p>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">Debit</td>
                <td>Credit</td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
                </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                        <AlternatingRowStyle BackColor="White" />
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle BackColor="#F7F7DE" />
                        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FBFBF2" />
                        <SortedAscendingHeaderStyle BackColor="#848384" />
                        <SortedDescendingCellStyle BackColor="#EAEAD3" />
                        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">TOTAL:
                    <asp:TextBox ID="_Total" runat="server" Visible="False"></asp:TextBox>
                </td>
                <td></td>
            </tr>
        </table>
    </form>
</body>
</html>
