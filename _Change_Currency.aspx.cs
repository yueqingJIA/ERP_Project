using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace ERP
{
    public partial class _Change_Currency : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void _update_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
			//if information is not complete
            if (_ratio.Text == ""  || _date.Text == "")
            {
                LbMessage.Visible = true;
                LbMessage.Text = "Please input all the information";
            }
			//change currency in the database
            else
            {
                LbMessage.Visible = false;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "UPDATE [Currency] SET _ratio = @ratio, _date = @date WHERE [_currency] = @Currency";


                cmd.Parameters.AddWithValue("@ratio", _ratio.Text);
                cmd.Parameters.AddWithValue("@date", _date.Text);
                cmd.Parameters.AddWithValue("@Currency", _Currency.SelectedValue);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LbMessage.Visible = true;
                LbMessage.Text = "New currency has been registered.";

                _ratio.Text = null;
                _date.Text = null;

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}