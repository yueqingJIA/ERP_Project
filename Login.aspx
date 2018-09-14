<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ERP.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        body{
            background-color: lightgray;
            font-family: Garamond, Helvetica, sans-serif;
        }
        h1{
            color: dodgerblue;
        }
        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <title></title>
    <style type="text/css">

        .auto-style1 {
            width: 600px;
        }
        .auto-style2 {
            text-align: right;
        }
        .auto-style3 {
            text-align: right;
        }
    </style>
    <form id="form2" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td colspan="2" style="text-align: center">
                        <h1>OH Accounting Premium Pro</h1>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">User Name:</td>
                    <td>
                        <asp:TextBox ID="_userName" runat="server" style="width: 150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">Password:</td>
                    <td>
                        <asp:TextBox ID="_Password" runat="server" TextMode="Password" style="width: 150px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <asp:Button ID="_Login" runat="server" style="text-align: right" Text="Login" OnClick="_Login_Click" />
                    </td>
                    <td class="auto-style3">&nbsp;</td>
                </tr>
            </table>
            <br />
            <asp:Label ID="LabelMessage" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
