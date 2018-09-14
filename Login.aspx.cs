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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Registration_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration");
        }

        protected void _Login_Click(object sender, EventArgs e)
        {
            //function to login
			string result ="";
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            //if the Username and Password are not complete
			if (_userName.Text == "" || _Password.Text == "")
            {
                LabelMessage.Visible = true;
                LabelMessage.Text = "Please input Username and Password";
            }

            else
            {
                //connection to the database
				LabelMessage.Visible = false;
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "select * from [User] where C_Name='" + _userName.Text + "' and [Password]='" + _Password.Text + "'";
                OleDbDataReader dr = cmd.ExecuteReader();
                try
                {
                    while (dr.Read())
                    {
                        result = dr["Identity"].ToString();
                        Response.Write(result);

                    }
					//if username is not correspond to the password
                    if (result == "")
                    {
                        LabelMessage.Visible = true;
                        LabelMessage.Text = "Invalid username or password";
                        con.Close();
                    }
					//go to welcome page
                    else
                    {
                        Session["Name"] = _userName.Text;
                        con.Close();
                        Response.Redirect("welcome");
                    }
                }
				//exception
                catch {
                    LabelMessage.Visible = true;
                    LabelMessage.Text = "Invalid username or password";
                    con.Close();
                }
                

            }
        }
    }
}