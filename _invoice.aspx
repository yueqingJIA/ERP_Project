<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_invoice.aspx.cs" Inherits="ERP._invoice" %>

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
    
        Enter the account name: <br />
        <asp:TextBox ID="_id" runat="server" Width="151px"></asp:TextBox>
        <asp:Button ID="_generate" runat="server" Text="Generate" OnClick="_generate_Click" />
        <br />
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
        <h2>&nbsp;</h2>
        <h2><asp:Label ID="Label1" runat="server" Text="Invoice" Visible="False"></asp:Label>
        </h2>
        <asp:Label ID="Label2" runat="server" Text="CS3372 City University of Hong Kong" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label3" runat="server" Text="invoice@cityu.hk" Visible="False"></asp:Label>
        <br />
        <br />

    </div>
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
        <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Notice: A finance charge of 1.5% will be made on unpaid balances after 30 days." Visible="False"></asp:Label>
        <br />
        <br />
        </form>
</body>
</html>
