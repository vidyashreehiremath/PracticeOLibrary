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
    public partial class adminbookissuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //Go button
        protected void Button1_Click(object sender, EventArgs e)
        {
            getNames();
        }

        //Issue book
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkIfBookExists() && checkIfMemberExists())
            {
                if(checkIfIssueExists())
                {
                    Response.Write("<script>alert('This BOOk has been already issued to the current member!!');</script>");
                }
                else
                {
                    issueBook();
                }
                
            }
            else
            {
                Response.Write("<script>alert('BOOKID OR MEMBER ID DOES NOT EXISTS!!!');</script>");
            }
        }

        //Return Book
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfBookExists() && checkIfMemberExists())
            {
                if (checkIfIssueExists())
                {
                    returnBook();
                }
                else
                {
                    Response.Write("<script>alert('This entry does not exists!!!');</script>");

                }

            }
            else
            {
                Response.Write("<script>alert('BOOKID OR MEMBER ID DOES NOT EXISTS!!!');</script>");
            }
        }

        //user defined functions


        void returnBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE member_id=@member_id AND book_id=@book_id", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
               
                int result=cmd.ExecuteNonQuery();
                con.Close();

                if (result > 0)
                {

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }
                    cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock+1 WHERE book_id=@book_id", con);
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Book Returned!!');</script>");
                    con.Close();
                    
                    // clear();
                    GridView1.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Credentails!!');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }


        void issueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);
                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock=current_stock-1 WHERE book_id=@book_id", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Book Issued!!');</script>");

                clear();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkIfIssueExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl where member_id=@member_id AND book_id=@book_id", con);
                    cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());

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
        bool checkIfMemberExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl where member_id='" + TextBox2.Text.Trim() + "';", con);
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
          bool checkIfBookExists()
          {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl where book_id='" + TextBox1.Text.Trim() + "' AND current_stock > 0", con);
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

        void getNames()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }

                SqlCommand cmd = new SqlCommand("SELECT book_name from book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["book_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong BOOK ID entered!!!');</script>");
                }

                cmd = new SqlCommand("SELECT full_name from member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' ", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong Member ID entered!!!');</script>");
                }
            }
            catch(Exception ex)
            {

            }
        }

        void clear()
        {
            TextBox2.Text = "";
            TextBox4.Text = "";
            TextBox1.Text = "";
            TextBox3.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }

                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}