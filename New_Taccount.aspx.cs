using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace ERP
{
    public partial class New_Taccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _add_Click(object sender, EventArgs e)
        {
			//function to add a new account in the database
		   OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";

            if (_ac_name.Text == "" || _ac_ID.Text == "")
            {
                LbMessage.Visible = true;
                LbMessage.Text = "Please input all the information";
            }
            else
            {
                LbMessage.Visible = false;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "insert into[Account_Sum](ID, _Ac_Name) values(@ID, @_Ac_Name)";
                cmd.Parameters.AddWithValue("@ID", _ac_ID.Text);
                cmd.Parameters.AddWithValue("@_Ac_Name", _ac_name.Text);
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LbMessage.Visible = true;
                LbMessage.Text = "New account has been created.";

                _ac_ID.Text = null;
                _ac_name.Text = null;
                
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("T_Account");
        }
    }
}