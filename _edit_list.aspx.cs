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
    public partial class _edit_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            OleDbConnection oledbCnn;
            OleDbDataAdapter oledbAdapter1;
            OleDbDataAdapter oledbAdapter2;
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string sql = null;
            connetionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\JYQ\Desktop\ERP\Database.mdb";
            //print table User_Activity
			sql = "SELECT * FROM [User_Activity]";
            oledbCnn = new OleDbConnection(connetionString);
            oledbCnn.Open();
            oledbAdapter1 = new OleDbDataAdapter(sql, oledbCnn);
            oledbAdapter1.Fill(ds1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
			//print table Account_Sum
            sql = "SELECT * FROM [Account_Sum]";
            oledbAdapter2 = new OleDbDataAdapter(sql, oledbCnn);
            oledbAdapter2.Fill(ds2);
            GridView2.DataSource = ds2;
            GridView2.DataBind();
            oledbCnn.Close();
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("welcome");
        }
    }
}