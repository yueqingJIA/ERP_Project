<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Change_Currency.aspx.cs" Inherits="ERP._Change_Currency" %>

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
        
        .auto-style1 {
            width: 600px;
        }
        
        </style>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <h2>OH Logistics Limited ERP System</h2>
        <div>
    
        &nbsp;</div>
        &nbsp;<table class="auto-style1">
            <tr>
                <td>Select your currecy:</td>
                <td>
         <asp:DropDownList ID="_Currency" runat="server" AutoPostBack="true">
                            <asp:ListItem>RMB</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                            <asp:ListItem>EUR</asp:ListItem>
                            <asp:ListItem>GBP</asp:ListItem>
                        </asp:DropDownList></td>
            </tr>
            <tr>
                <td>New rate:</td>
                <td>
        <asp:TextBox ID="_ratio" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Date:</td>
                <td>
        <asp:TextBox ID="_date" runat="server" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="_update" runat="server" Text="Update" OnClick="_update_Click" />
                </td>
                <td>
        <asp:Label ID="LbMessage" runat="server" Text="" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
&nbsp;<br />
        &nbsp;
        <br />

         <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    </form>
   
</body>
</html>
