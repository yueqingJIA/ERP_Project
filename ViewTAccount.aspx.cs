using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
//NOT USED!!!!! 
namespace ERP
{
    public partial class ViewTAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int _sum_debit = 0;
            int _sum_credit = 0;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            OleDbCommand cmd1 = new OleDbCommand();
            cmd1.Connection = con;
            con.Open();
            cmd1.CommandText = "SELECT SUM(User_Activity.[_Amount]) AS debit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] = '001')";
            OleDbDataReader _debit = cmd1.ExecuteReader();
            try
            {
                while (_debit.Read())
                {
                    _sum_debit = Convert.ToInt32(_debit["debit"].ToString());
                }
            }
            catch { _sum_debit = 0; }
            con.Close();
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.Connection = con;
            con.Open();
            cmd2.CommandText = "SELECT  SUM(User_Activity.[_Amount]) AS credit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Credit] = '001')";
            OleDbDataReader _credit = cmd2.ExecuteReader();
            try
            {
                while (_credit.Read())
                {
                    _sum_credit = Convert.ToInt32(_credit["credit"].ToString());
                }
            }
            catch { _sum_credit = 0; }
            con.Close();
            string total = (_sum_debit - _sum_credit).ToString();
            _Total.Text = total;
        }
    }
}

