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
    public partial class _cashflow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //find all Account Receivable
			int result1 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Receivable%')");
            _RFC.Text = result1.ToString();
			//find all Account Payable
            int result2 = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Payable%')");
            _PSE.Text = result2.ToString();
            int total = result1 - result2;
            _TCFOA.Text = total.ToString();
			//find all Other revenue
            result1 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Credit] LIKE '5__')");
            _OCFIA.Text = result1.ToString();
            _TCFFIA.Text = result1.ToString();

            _NCF.Text = (total + result1).ToString();
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

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}