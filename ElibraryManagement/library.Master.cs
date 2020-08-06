using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElibraryManagement
{
    public partial class library : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sessionrole = Session["role"] as string;
            try
            {
                if (string.IsNullOrEmpty(sessionrole))
                    {
                    LinkButton1.Visible = true; //user login link button
                    LinkButton2.Visible = true; //Signup link button

                    LinkButton3.Visible = false; //logout link button
                    LinkButton7.Visible = false; //hellouser link button

                    LinkButton6.Visible = true; //Admin login link button
                    LinkButton11.Visible = false; //Admin Author managemnet link button
                    LinkButton12.Visible = false; //Admin publisher managemnet link button
                    LinkButton8.Visible = false; //Admin book inventory link button
                    LinkButton9.Visible = false; //Admin book issuing link button
                    LinkButton10.Visible = false; //Admin member managemnet link button


                }
                else if(Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //Signup link button

                    LinkButton3.Visible = true; //logout link button
                    LinkButton7.Visible = true; //hellouser link button
                    LinkButton7.Text = "Hello" + Session["username"].ToString();

                    LinkButton6.Visible = true; //Admin login link button
                    LinkButton11.Visible = false; //Admin Author managemnet link button
                    LinkButton12.Visible = false; //Admin publisher managemnet link button
                    LinkButton8.Visible = false; //Admin book inventory link button
                    LinkButton9.Visible = false; //Admin book issuing link button
                    LinkButton10.Visible = false; //Admin member managemnet link button
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false; //user login link button
                    LinkButton2.Visible = false; //Signup link button

                    LinkButton3.Visible = true; //logout link button
                    LinkButton7.Visible = true; //hellouser link button
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false; //Admin login link button
                    LinkButton11.Visible = true; //Admin Author managemnet link button
                    LinkButton12.Visible = true; //Admin publisher managemnet link button
                    LinkButton8.Visible = true; //Admin book inventory link button
                    LinkButton9.Visible = true; //Admin book issuing link button
                    LinkButton10.Visible = true; //Admin member managemnet link button
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermanagement.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookinventory.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminbookissuing.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmembermanagement.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("viewbooks.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }

        //logout button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";
            Session["status"] = "";

            LinkButton1.Visible = true; //user login link button
            LinkButton2.Visible = true; //Signup link button

            LinkButton3.Visible = false; //logout link button
            LinkButton7.Visible = false; //hellouser link button

            LinkButton6.Visible = true; //Admin login link button
            LinkButton11.Visible = false; //Admin Author managemnet link button
            LinkButton12.Visible = false; //Admin publisher managemnet link button
            LinkButton8.Visible = false; //Admin book inventory link button
            LinkButton9.Visible = false; //Admin book issuing link button
            LinkButton10.Visible = false; //Admin member managemnet link button

            Response.Redirect("homepage.aspx");
        }

        //view profile
        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
    }
}