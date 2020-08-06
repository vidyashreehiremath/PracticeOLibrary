<%@ Page Title="" Language="C#" MasterPageFile="~/library.Master" AutoEventWireup="true" CodeBehind="userlogin.aspx.cs" Inherits="ElibraryManagement.userlogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 mx-auto">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                       <img src="images/generaluser.png" width="150px" />
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                       <h3>Member Login</h3>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Member Id</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox1" runat="server" placeholder="Member ID"></asp:TextBox>
                               </div>

                                <label>Member Password</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Password"></asp:TextBox>
                               </div>

                                 <div class="form-group">
                                     <asp:Button ID="Button1" class="btn btn-success btn-block btn-lg" runat="server" Text="Login" OnClick="Button1_Click" />
                                   </div>
                                <div class="form-group">
                                   <a href="usersignup.aspx"> <input ID="Button2" class="btn btn-info btn-block btn-lg" type="button" value="Sign Up" /> </a>
                                   </div>

                            </div>
                        </div>

                    </div>
                </div>

                <a href="homepage.aspx"><< Back To Home</a>
                <br />
                <br />

            </div>
        </div>
    </div>
</asp:Content>
