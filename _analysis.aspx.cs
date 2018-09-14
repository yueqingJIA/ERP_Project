using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

			//current assets: 0__
			//non current assets : 1__
			//current liability : 2__
			//non current liability 3__
			//capital: 4__
namespace ERP
{
    public partial class _analysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
  
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
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            int _sum_debit = 0;
            int _sum_credit = 0;
            
            OleDbCommand cmd1 = new OleDbCommand();
            con.Open();
            cmd1.CommandText = "SELECT SUM(User_Activity.[_Amount]) AS debit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] LIKE '"+type +"')";
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
            cmd2.CommandText = "SELECT  SUM(User_Activity.[_Amount]) AS credit FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Credit] LIKE '"+type+"')";
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

        protected void _WC_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Working Capital";
            _formula.Text = "Current Assets - Current Liabilities";
            //calculate Working Capital
            _result.Text = (Calculate("0__") - Calculate("2__")).ToString();
        }

        protected void _CR_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Current Ratio";
            _formula.Text = "Current Assets / Current Liabilities";
            //calculate Current Ratio
            _result.Text = (Calculate("0__")/Calculate("2__")).ToString() + " : 1";
        }

        protected void _ATR_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Acid-test Ratio";
            _formula.Text = "(Current Assets - inventories)/ Current Liabilities :1";
            //calculate inventories
            int _inventories = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] = '003')");
            //calculate asset
            int _asset = Calculate("0__");
            //calculate current liabilities
            int _cl = Calculate("2__");
            _result.Text = ((_asset - _inventories) / _cl).ToString();
        }

        protected void _TRT_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Trade Receivable Turnover (Times)";
            _formula.Text = "Credit Sales / Average Trade Receivables";
            //calculate credit sales
            int cs = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Credit] LIKE '701')");
            //calculate Average Trade Receivable
            int atr1 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Receivable%')");
            int atr2 = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Receivable%')");
            int temp = atr2 - atr1;
            temp /= 4;
            double temp2 = cs / (double)temp;
            _result.Text = temp2.ToString();
        }

        protected void _ATRCP_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Average Trade Receivables Collection Period";
            _formula.Text = "365 / Trade Receivable Turnover (Times)";
            //calculate credit sales
            int cs = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(User_Activity.[_Credit] LIKE '701')");
            //calculate Average Trade Receivable
            int atr1 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Receivable%')");
            int atr2 = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Receivable%')");
            int temp = atr2 - atr1;
            temp /= 4;
            double temp2 = cs / (double)temp;
            temp2 = 365 / temp2;
            _result.Text = temp2.ToString();
        }

        protected void _TPT_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Trade Payables Turnover (Times)";
            _formula.Text = "Credit Purchase / Average Trade Payables";
            //calculate Credit Purchase
            int cs = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] LIKE '700')");
            //calculate Average Trade Receivable
            int atr1 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Payable%')");
            int atr2 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Payable%')");
            int temp = atr1 - atr2;
            temp /= 4;
            double temp2 = cs / (double)temp;
            _result.Text = temp2.ToString();
        }

        protected void _ATPRP_Click(object sender, EventArgs e)
        {
            _ratio.Visible = true;
            _formula.Visible = true;
            _result.Visible = true;
            _ratio.Text = "Average Trade Payables Repayment Period";
            _formula.Text = "365 / Trade Payables Turnover (Times)";
            //calculate Credit Purchase
            int cs = SqlExecute("SELECT  SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(User_Activity.[_Debit] LIKE '700')");
            //calculate Average Trade Receivable
            int atr1 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Payable%')");
            int atr2 = SqlExecute("SELECT SUM(User_Activity.[_Amount]) AS res FROM(User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Debit]) WHERE(Account_Sum.[_Ac_Name] LIKE '%Account Payable%')");
            int temp = atr1 - atr2;
            temp /= 4;
            double temp2 = cs / (double)temp;
            temp2 = 365 / temp2;
            _result.Text = temp2.ToString();
        }

        protected void _back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}