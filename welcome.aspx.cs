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
    public partial class welcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //print user information
			string _name = (string) Session["Name"];
            Label1.Text = _name;
            string _identity = "";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "select Identity from [User] where C_Name='" + _name + "'";
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                _identity = dr["Identity"].ToString();
            }
			//access control
            if(_identity == "admin" || _identity == "senior staff")
            {
                Cash_Flow_Statement.Visible = true;
                Basic_Analysis.Visible = true;
                Income_Statement.Visible = true;
                BS.Visible = true;
                EL.Visible = true;
                Currency.Visible = true;
                Label2.Text = _identity;
            }
            if(_identity == "junior staff")
                Label2.Text = _identity;
        }

        protected void T_Account_Click(object sender, EventArgs e)
        {
            Response.Redirect("T_Account");
        }

        protected void Basic_Analysis_Click(object sender, EventArgs e)
        {
            Response.Redirect("_analysis");
        }

        protected void Cash_Flow_Statement_Click(object sender, EventArgs e)
        {
            Response.Redirect("_cashflow");
        }

        protected void Income_Statement_Click(object sender, EventArgs e)
        {
            Response.Redirect("_income_statement");
        }

        protected void Invoice_Click(object sender, EventArgs e)
        {
            Response.Redirect("_invoice");
        }

        protected void Currency_Click(object sender, EventArgs e)
        {
            Response.Redirect("_Change_Currency");
        }

        protected void EL_Click(object sender, EventArgs e)
        {
            Response.Redirect("_edit_list");
        }

        protected void BS_Click(object sender, EventArgs e)
        {
            Response.Redirect("_banlance_sheet");
        }
    }
}