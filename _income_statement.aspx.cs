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
    public partial class _income_statement : System.Web.UI.Page
    {
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
        protected void Page_Load(object sender, EventArgs e)
        {
            int sales = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Credit] LIKE '701')");
            _sales.Text = sales.ToString();

            int purchase = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Debit] LIKE '700')");
            int inventory = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Debit] LIKE '003')");
            int COGS = purchase - inventory;
            _COGS.Text = COGS.ToString();
            int GP = sales - COGS;
            _GP.Text = GP.ToString();

            int OI = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Credit] LIKE '5__')");
            _OI.Text = OI.ToString();
            int OE = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Debit] LIKE '6__')");
            _OE.Text = OE.ToString();

            int NI = GP + OI - OE;
            _NI.Text = NI.ToString();

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}