using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issues_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                fillAuthorPublisherValues();
            }
           
            GridView1.DataBind();
            
        }

        //Go button blue
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            getBookById();
        }

        //ADD button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(checkIfBookExists())
            {
                Response.Write("<script>alert('Book with the Id:'"+TextBox2.Text.Trim()+"' Already exists');</script>");
            }
            else
            {
                addNewBook();
            }
        }


        //update button
        protected void Button1_Click(object sender, EventArgs e)
        {
            updateBookByID();
        }

        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {
            deleteBookById();
        }

        //user defined functions

            void deleteBookById()
          {

            if (checkIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();

                    }

                    SqlCommand cmd = new SqlCommand("DELETE from book_master_tbl WHERE book_id='" + TextBox2.Text.Trim() + "'", con);



                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted Sucessfully!!');</script>");
                   // clear();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID!!');</script>");
            }
        }
        void updateBookByID()
        {
            if (checkIfBookExists())
            {
                try
                {
                    // bussiness logic for actul stock connversion
                    int actual_stock = Convert.ToInt32(TextBox7.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox9.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issues_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issues_books;
                            TextBox9.Text = "" + current_stock;
                        }
                    }
                    //actual stock logic end here

                    //genres logic
                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }

                    //removes extra , appened at last og genres string
                    genres = genres.Remove(genres.Length - 1);

                    //genre logic end here

                    //filapth check logic
                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                        filepath = "~/book_inventory/" + filename;
                    } // file path check logic ends here

                    using (SqlConnection con = new SqlConnection(strcon))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("UPDATE book_master_tbl SET " +
                            "book_name=@book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name," +
                            "publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost," +
                            "no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@actual_stock," +
                            "current_stock=@current_stock,book_img_link=@book_img_link WHERE book_id='"+TextBox2.Text.Trim()+"'", con);

                        
                        cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@genre", genres);
                        cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@publish_date", TextBox6.Text.Trim());
                        cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                        cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                        cmd.Parameters.AddWithValue("@book_description", TextBox5.Text.Trim());
                        cmd.Parameters.AddWithValue("@actual_stock",actual_stock.ToString());
                        cmd.Parameters.AddWithValue("@current_stock",current_stock.ToString());
                        cmd.Parameters.AddWithValue("@book_img_link", filepath);

                        cmd.ExecuteNonQuery();
                        GridView1.DataBind();
                        con.Close();

                        Response.Write("<script>alert('Book updated!! Sucessfully');</script>");


                    }

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID!!');</script>");
            }
        }
         void getBookById()
         {
            try
            {
                

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //author_name droplist

                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl WHERE book_id='"+TextBox2.Text.Trim()+"' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >=1)
                {
                    TextBox1.Text = dt.Rows[0]["book_name"].ToString();
                    DropDownList1.SelectedValue= dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox3.Text = dt.Rows[0]["edition"].ToString();
                    TextBox4.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox8.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox7.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox10.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString())
                        - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox5.Text = dt.Rows[0]["book_description"].ToString();

                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    for(int i=0;i< genre.Length;i++)
                    {
                        for(int j=0;j<ListBox1.Items.Count;j++)
                        {
                            if(ListBox1.Items[j].ToString()==genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                            
                        }
                    }

                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock= Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issues_books = global_actual_stock - global_current_stock;


                }
                else
                {
                    Response.Write("<script>alert('Book with the ID '"+TextBox2.Text.Trim()+"' is not present!!');</script>");
                }
    
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void fillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }

                //author_name droplist

                SqlCommand cmd = new SqlCommand("SELECT author_name from author_master_tbl", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                //publisher_name droplist

                cmd = new SqlCommand("SELECT publisher_name from publisher_master_tbl", con);
                 da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }
        bool checkIfBookExists()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl where book_id='" + TextBox2.Text.Trim() + "' OR book_name='"+TextBox1.Text.Trim()+"';", con);
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
        //check if book exists




        //add new book
        void addNewBook()
        {
            try
            {
                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }

                //removes extra , appened at last og genres string
                genres = genres.Remove(genres.Length - 1);

                //filepath code
                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date," +
                    "language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) " +
                    "values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost," +
                    "@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);

                 cmd.Parameters.AddWithValue("@book_id", TextBox2.Text.Trim());
                 cmd.Parameters.AddWithValue("@book_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);
                 cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                 cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                 cmd.Parameters.AddWithValue("@publish_date", TextBox6.Text.Trim());
                 cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                 cmd.Parameters.AddWithValue("@edition", TextBox3.Text.Trim());
                 cmd.Parameters.AddWithValue("@book_cost", TextBox4.Text.Trim());
                 cmd.Parameters.AddWithValue("@no_of_pages", TextBox8.Text.Trim());
                 cmd.Parameters.AddWithValue("@book_description", TextBox5.Text.Trim());
                 cmd.Parameters.AddWithValue("@actual_stock", TextBox7.Text.Trim());
                 cmd.Parameters.AddWithValue("@current_stock", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book added successfully.');</script>");
                GridView1.DataBind();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
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

            ListBox1.Items.Clear();
        }
    }
}