using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

namespace ERP
{
    public partial class _ViewTaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _View_Click(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter oledbAdapter1;
            OleDbDataAdapter oledbAdapter2;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string sql = null;
			//table of credit
            connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            sql = "SELECT Account_Sum.[_Ac_Name], User_Activity.[_Amount] FROM (User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE (User_Activity.[_Debit] = '"+ _TAccount.Text+ "')";
            oledbCnn = new OleDbConnection(connetionString);
            oledbCnn.Open();
            oledbAdapter1 = new OleDbDataAdapter(sql, oledbCnn);
            oledbAdapter1.Fill(ds1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
			//table of debit
            sql = "SELECT Account_Sum.[_Ac_Name], User_Activity.[_Amount] FROM (User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE (User_Activity.[_Credit] = '" + _TAccount.Text + "')";
            oledbAdapter2 = new OleDbDataAdapter(sql, oledbCnn);
            oledbAdapter2.Fill(ds2);
            GridView2.DataSource = ds2;
            GridView2.DataBind();
            oledbCnn.Close();

            //total: credit - debit
            int _sum_debit = 0;
            int _sum_credit = 0;
            OleDbCommand cmd1 = new OleDbCommand();
            oledbCnn.Open();
            cmd1.CommandText = "SELECT SUM(User_Activity.[_Amount]) AS debit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] = '" + _TAccount.Text + "')";
            cmd1.Connection = oledbCnn;
            OleDbDataReader _debit = cmd1.ExecuteReader();

            try
            {
                while (_debit.Read())
                {
                    _sum_debit = Convert.ToInt32(_debit["debit"].ToString());
                }
            }
            catch { _sum_debit = 0; }
            OleDbCommand cmd2 = new OleDbCommand();
            cmd2.Connection = oledbCnn;
            cmd2.CommandText = "SELECT  SUM(User_Activity.[_Amount]) AS credit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Credit] = '" + _TAccount.Text + "')";
            OleDbDataReader _credit = cmd2.ExecuteReader();
            try
            {
                while (_credit.Read())
                {
                    _sum_credit = Convert.ToInt32(_credit["credit"].ToString());
                }
            }
            catch { _sum_credit = 0; }
            oledbCnn.Close();
            string total = (_sum_debit - _sum_credit).ToString();
            _Total.Visible = true;
            _Total.Text = total;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("T_Account");
        }
    }
}