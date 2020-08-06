using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //Go button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getMemberById();
        }

        //active green button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                updateMemberStatusById("active");
            }
            else
            {
                Response.Write("<script>alert('MemberID not entered !!');</script>");
            }
        }

        //yellown pending button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                updateMemberStatusById("pending");
            }
            else
            {
                Response.Write("<script>alert('MemberID not entered !!');</script>");
            }
        }

        //Deactive red button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                updateMemberStatusById("deactive");
            }
            else
            {
                Response.Write("<script>alert('MemberID not entered !!');</script>");
            }
        }

        //Delete user
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (checkIfMemberExists())
            {
                deleteMemberById();
            }
            else
            {
                Response.Write("<script>alert('Member Does not exists !!');</script>");
            }
           
        }

        //userdefied function

        void getMemberById()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + TextBox2.Text.Trim() + "'", con);
                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            TextBox1.Text = rd.GetValue(0).ToString();//full name
                            TextBox7.Text = rd.GetValue(10).ToString();//account status
                            TextBox3.Text = rd.GetValue(1).ToString();//DOB
                            TextBox4.Text = rd.GetValue(2).ToString();//contact
                            TextBox8.Text = rd.GetValue(3).ToString();//email
                            TextBox9.Text = rd.GetValue(4).ToString();//state
                            TextBox10.Text = rd.GetValue(5).ToString();//city
                            TextBox11.Text = rd.GetValue(6).ToString();//pin code
                            TextBox5.Text = rd.GetValue(7).ToString();//full address

                        }
              
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Member Id');</script>");
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void updateMemberStatusById(string status)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='"+status+"' where member_id='" + TextBox2.Text.Trim() + "'", con);
                
                    cmd.ExecuteNonQuery();
                    GridView1.DataBind();

                    Response.Write("<script>alert('Member status updated!!');</script>");

                   
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void deleteMemberById()
        {
            if (checkIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }

                    SqlCommand cmd = new SqlCommand("DELETE from member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);



                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted Sucessfully!!');</script>");
                    clear();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID!!');</script>");
            }
        }

        bool checkIfMemberExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl where member_id='" + TextBox2.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void clear()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox9.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
           
        }
    }
}