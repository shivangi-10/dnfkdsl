﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace library_ms.student
{
    public partial class load_new_messages : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SHIVANGI LAD\source\repos\library_ms\App_Data\lms.mdf;Integrated Security=True");
        string username = "";
        string msg = "";
        int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();


            if (Session["student"] == null)
            {
                Response.Redirect("student_login.aspx");
            }

            username = Session["student"].ToString();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from messages where dusername= '" + username.ToString() + "' and placed='no'";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                count = count + 1;
                if (count == 1)
                {
                    msg = dr["susername"].ToString() + ":" + dr["msg"].ToString();

                }
                else
                {
                    msg = msg + "||abcd||" + dr["susername"].ToString() + ":" + dr["msg"].ToString();

                }
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "update messages set placed = 'yes' where id=" + dr["id"].ToString() + "";
                cmd1.ExecuteNonQuery();
            }
            if (count == 0)
            {
                Response.Write("0");

            }
            else
            {
                Response.Write(msg.ToString());
            }
        }
    }
}