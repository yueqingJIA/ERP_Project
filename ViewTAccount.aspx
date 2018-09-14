<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewTAccount.aspx.cs" Inherits="ERP.ViewTAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 196px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
        .auto-style3 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>
            OH Logistics Limited ERP System</h2>
        <h2>
        <asp:Label ID="Title" runat="server" Text="Bank"></asp:Label>
        </h2>
    <div>
    
    </div>
        <asp:SqlDataSource ID="TAccount" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString %>" ProviderName="<%$ ConnectionStrings:DatabaseConnectionString.ProviderName %>" SelectCommand="SELECT Account_Sum.[_Ac_Name], User_Activity.[_Amount] FROM (User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE (User_Activity.[_Credit] = '1')"></asp:SqlDataSource>
        <table class="auto-style3">
            <tr>
                <td class="auto-style1">
                    <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="Debit">
            <Columns>
                <asp:BoundField DataField="_Ac_Name" HeaderText="_Ac_Name" SortExpression="_Ac_Name" />
                <asp:BoundField DataField="_Amount" HeaderText="_Amount" SortExpression="_Amount" />
            </Columns>
        </asp:GridView>
                    <asp:SqlDataSource ID="Debit" runat="server" ConnectionString="<%$ ConnectionStrings:DatabaseConnectionString %>" ProviderName="<%$ ConnectionStrings:DatabaseConnectionString.ProviderName %>" SelectCommand="SELECT Account_Sum.[_Ac_Name], User_Activity.[_Amount] FROM (User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE (User_Activity.[_Debit] = '1')"></asp:SqlDataSource>
                </td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CssClass="auto-style2" DataSourceID="TAccount">
                        <Columns>
                            <asp:BoundField DataField="_Ac_Name" HeaderText="_Ac_Name" SortExpression="_Ac_Name" />
                            <asp:BoundField DataField="_Amount" HeaderText="_Amount" SortExpression="_Amount" />
                        </Columns>
                    </asp:GridView>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1"><strong>Total: </strong>
                    <asp:Label ID="_Total" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:FormView ID="FormView1" runat="server" DataSourceID="test">
                    </asp:FormView>
                    <asp:SqlDataSource ID="test" runat="server"></asp:SqlDataSource>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
