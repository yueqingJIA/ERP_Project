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
    public partial class _invoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _generate_Click(object sender, EventArgs e)
        {
            //print invoice
			string connetionString = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter oledbAdapter1;
            DataSet ds1 = new DataSet();
            string sql = null;
            connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            sql = "SELECT User_Activity.[ID], User_Activity.[_Date] AS ActivityDate, Account_Sum.[_Ac_Name] AS Product, User_Activity.[_Amount] AS Price FROM (User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE (User_Activity.[_Debit] = '" + _id.Text + "')";
            oledbCnn = new OleDbConnection(connetionString);
            oledbCnn.Open();
            try
            {
                oledbAdapter1 = new OleDbDataAdapter(sql, oledbCnn);
                oledbAdapter1.Fill(ds1);
                GridView1.DataSource = ds1;
                GridView1.DataBind();
                Label1.Visible = true;
                Label2.Visible = true;
                Label3.Visible = true;
                Label4.Visible = true;
                Label5.Visible = true;
            }
            catch { }
            oledbCnn.Close();

            //calculate total
            int _total = 0;
            OleDbCommand cmd1 = new OleDbCommand();
            oledbCnn.Open();
            cmd1.CommandText = "SELECT SUM(User_Activity.[_Amount]) AS Total FROM (User_Activity INNER JOIN Account_Sum ON Account_Sum.ID = User_Activity.[_Credit]) WHERE (User_Activity.[_Debit] = '" + _id.Text + "')";
            cmd1.Connection = oledbCnn;
            OleDbDataReader _debit = cmd1.ExecuteReader();

            try
            {
                while (_debit.Read())
                {
                    _total = Convert.ToInt32(_debit["Total"].ToString());
                }
            }
            catch { _total = 0; }
            Label5.Text ="Total: "+ _total.ToString();
            oledbCnn.Close();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}