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
    public partial class _banlance_sheet : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
			//current assets: 0__
			//non current assets : 1__
			//current liability : 2__
			//non current liability 3__
			//capital: 4__
            int res1 = Calculate("0__") + Calculate("1__");
            Label1.Text = Calculate("0__").ToString();
            Label2.Text = Calculate("1__").ToString();
            Label3.Text = res1.ToString();
            Label4.Text = Calculate("2__").ToString();
            Label5.Text = Calculate("3__").ToString();
            Label6.Text = Calculate("4__").ToString();
            res1 = Calculate("2__") + Calculate("3__") + Calculate("4__");
            Label7.Text = res1.ToString();


        }

        public int SqlExecute(string type)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            OleDbCommand cmd1 = new OleDbCommand();
            con.Open();
            cmd1.CommandText = type;
            cmd1.Connection = con;
            OleDbDataReader _debit = cmd1.ExecuteReader();
            int result = 0;
            try
            {
                while (_debit.Read())
                {
                    result = Convert.ToInt32(_debit["res"].ToString());
                }
            }
            catch { result = 0; }
            return result;
        }
        public int Calculate(string type)
        {
			//function to calculate credit - debit for a type given
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            int _sum_debit = 0;
            int _sum_credit = 0;

            OleDbCommand cmd1 = new OleDbCommand();
            con.Open();
            cmd1.CommandText = "SELECT SUM(User_Activity.[_Amount]) AS debit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] LIKE '" + type + "')";
            cmd1.Connection = con;
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
            cmd2.Connection = con;
            cmd2.CommandText = "SELECT  SUM(User_Activity.[_Amount]) AS credit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Credit] LIKE '" + type + "')";
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
            int result = _sum_debit - _sum_credit;
            if (result < 0)
            {
                result = result * (-1);
            }
            return result;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}