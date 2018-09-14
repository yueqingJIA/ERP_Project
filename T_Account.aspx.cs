using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace ERP
{
    public partial class T_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public double SqlExecute(string type)
        {
			//function for executing a sql selection command
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            OleDbCommand cmd1 = new OleDbCommand();
            con.Open();
            cmd1.CommandText = type;
            cmd1.Connection = con;
            OleDbDataReader _debit = cmd1.ExecuteReader();
            double result = 0;
            try
            {
                while (_debit.Read())
                {
                    result = Convert.ToDouble(_debit["_ratio"].ToString());
                }
            }
            catch { result = 0; }
            return result;
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
			
			//If user has not filled all the information 
            if (Debit.Text == "" || Credit.Text == "" || Amount.Text == "" || Date.Text == "")
            {
                LbMessage.Visible = true;
                LbMessage.Text = "Please input all the information";
            }
            else
            {
				//calculate of currency
                double temp = Convert.ToDouble(Amount.Text);
                double currency = 0;
                try {
                    currency = SqlExecute("SELECT * FROM[Currency] WHERE(Currency.[_currency] = '"+ _Currency.SelectedValue + "')");
                    temp = temp * currency;
                }
                catch { temp = temp * 1; }
                int temp2 = (int)temp;
                Amount.Text = temp2.ToString();
				
				//Insert T_account in the database
                LbMessage.Visible = false;
                        OleDbCommand cmd = new OleDbCommand();
                        cmd.CommandText = "insert into[User_Activity](_Date, _Debit, _Credit, _Amount) values(@_Date, @_Debit, @_Credit, @_Amount)";
                        cmd.Parameters.AddWithValue("@_Date", Date.Text);
                        cmd.Parameters.AddWithValue("@_Debit", Debit.Text);
                        cmd.Parameters.AddWithValue("@_Credit", Credit.Text);
                        cmd.Parameters.AddWithValue("@_Amount", Amount.Text);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        LbMessage.Visible = true;
                        LbMessage.Text = "Transaction has been recorded.";

                        Date.Text = null;
                        Debit.Text = null;
                        Credit.Text = null;
                        Amount.Text = null;
            }
        }

        protected void _View_Click(object sender, EventArgs e)
        {
            Response.Redirect("_ViewTAccount");
        }

        protected void Add_Taccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("New_Taccount");
        }

        protected void _ViewCurrency_Click(object sender, EventArgs e)
        {
            //view realtime currency
			if(_Currency.SelectedValue == "HKD")
            {
                Lbl_currency.Visible = true;
                Lbl_currency.Text = "This is the default currency!";
            }

            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
                OleDbCommand cmd1 = new OleDbCommand();
                cmd1.Connection = con;
                con.Open();
                cmd1.CommandText = "SELECT * FROM[Currency] WHERE(Currency.[_currency] = '" + _Currency.SelectedValue + "')";
                OleDbDataReader _res = cmd1.ExecuteReader();
                Lbl_currency.Visible = true;
                while (_res.Read())
                    {
                    Lbl_currency.Text = (_res["_ratio"].ToString()) + " "+ (_res["_date"].ToString());
                    }          
                con.Close();
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}