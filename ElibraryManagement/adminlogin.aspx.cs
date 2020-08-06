using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl where username='" + TextBox1.Text.Trim() + "' and password='" + TextBox2.Text.Trim() + "'", con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            //  Response.Write("<script>alert('" + rd.GetValue(0).ToString() + "');</script>");
                            Session["username"] = rd.GetValue(0).ToString();
                            Session["fullname"] = rd.GetValue(2).ToString();
                            Session["role"] = "admin";
                           // Session["status"] = rd.GetValue(10).ToString();

                        }
                        Response.Redirect("homepage.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Credentrials');</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}