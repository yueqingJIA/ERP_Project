<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Taccount.aspx.cs" Inherits="ERP.New_Taccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 600px;
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
        <h1>Create new T account</h1>
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td>Account ID:</td>
                <td>
                    <asp:TextBox ID="_ac_ID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Account Name:</td>
                <td>
                    <asp:TextBox ID="_ac_name" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LbMessage" runat="server" Visible="False"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="_add" runat="server" Text="Add" OnClick="_add_Click" />
                </td>
            </tr>
        </table>
    
    </div>
        <br />
        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
    </form>
    
    
</body>
</html>
