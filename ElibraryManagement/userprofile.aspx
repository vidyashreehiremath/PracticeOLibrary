<%@ Page Title="" Language="C#" MasterPageFile="~/library.Master" AutoEventWireup="true" CodeBehind="userprofile.aspx.cs" Inherits="ElibraryManagement.userprofile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                       <img src="images/generaluser.png" width="100px" />
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                       <h4>Your Profile</h4>
                                       <span>Account status-</span>
                                      <asp:Label ID="Label1" class="badge badge-pill badge-info" runat="server" Text="your status"></asp:Label>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                         <div class="row">
                            <div class="col-md-6">
                                <label>Full Name</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox3" runat="server" placeholder="Full Name"></asp:TextBox>
                               </div>
                            </div>

                             <div class="col-md-6">
                               <label>Date of Birth</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox2" runat="server" placeholder="Password" TextMode="Date"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label>Contact No</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox1" runat="server" placeholder="Contact No" TextMode="Number"></asp:TextBox>
                               </div>
                            </div>

                             <div class="col-md-6">
                               <label>Email Id</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox4" runat="server" placeholder="Email Id" TextMode="Email"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                               <div class="form-group">
                                   <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server">
                                       <asp:ListItem Text="Select" Value="select" />
                              <asp:ListItem Text="Andhra Pradesh" Value="Andhra Pradesh" />
                              <asp:ListItem Text="Arunachal Pradesh" Value="Arunachal Pradesh" />
                              <asp:ListItem Text="Assam" Value="Assam" />
                              <asp:ListItem Text="Bihar" Value="Bihar" />
                              <asp:ListItem Text="Chhattisgarh" Value="Chhattisgarh" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Goa" Value="Goa" />
                              <asp:ListItem Text="Gujarat" Value="Gujarat" />
                              <asp:ListItem Text="Haryana" Value="Haryana" />
                              <asp:ListItem Text="Himachal Pradesh" Value="Himachal Pradesh" />
                              <asp:ListItem Text="Jammu and Kashmir" Value="Jammu and Kashmir" />
                              <asp:ListItem Text="Jharkhand" Value="Jharkhand" />
                              <asp:ListItem Text="Karnataka" Value="Karnataka" />
                              <asp:ListItem Text="Kerala" Value="Kerala" />
                              <asp:ListItem Text="Madhya Pradesh" Value="Madhya Pradesh" />
                              <asp:ListItem Text="Maharashtra" Value="Maharashtra" />
                              <asp:ListItem Text="Manipur" Value="Manipur" />
                              <asp:ListItem Text="Meghalaya" Value="Meghalaya" />
                              <asp:ListItem Text="Mizoram" Value="Mizoram" />
                              <asp:ListItem Text="Nagaland" Value="Nagaland" />
                              <asp:ListItem Text="Odisha" Value="Odisha" />
                              <asp:ListItem Text="Punjab" Value="Punjab" />
                              <asp:ListItem Text="Rajasthan" Value="Rajasthan" />
                              <asp:ListItem Text="Sikkim" Value="Sikkim" />
                              <asp:ListItem Text="Tamil Nadu" Value="Tamil Nadu" />
                              <asp:ListItem Text="Telangana" Value="Telangana" />
                              <asp:ListItem Text="Tripura" Value="Tripura" />
                              <asp:ListItem Text="Uttar Pradesh" Value="Uttar Pradesh" />
                              <asp:ListItem Text="Uttarakhand" Value="Uttarakhand" />
                              <asp:ListItem Text="West Bengal" Value="West Bengal" />
                                   </asp:DropDownList>
                                </div>
                            </div>

                             <div class="col-md-4">
                               <label>City</label>
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox6" runat="server" placeholder="City" ></asp:TextBox>
                               </div>
                            </div>

                            <div class="col-md-4">
                               <label>Pin Code</label>
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox7" runat="server" placeholder="Pin Code" TextMode="Number"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <label>Full Address</label>
                               <div class="form-group">
                                   <asp:TextBox  CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Address" TextMode="MultiLine" Rows="2"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                        <div class="row">
                             <div class="col">
                                <center>
                              <span class="badge badge-pill badge-info">Login Credentials</span>
                                 </center>
                             </div>
                      </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>User ID</label>
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox8" runat="server" placeholder="User ID" ReadOnly="true"></asp:TextBox>
                               </div>
                            </div>

                             <div class="col-md-4">
                               <label>Old Password</label>
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox9" runat="server" placeholder="Old Password" TextMode="Password" ReadOnly="true"></asp:TextBox>
                               </div>
                            </div>

                            <div class="col-md-4">
                                <label>New Password</label>
                               <div class="form-group">
                                   <asp:TextBox  class="form-control" ID="TextBox10" runat="server" placeholder="New Password" TextMode="Password"></asp:TextBox>
                               </div>
                            </div>
                        </div>

                     <div class="row">
                          <div class="col-8 mx-auto">
                              <center>
                              <div class="form-group">
                               <asp:Button ID="Button1" class="btn btn-primary btn-block btn-lg" runat="server" Text="Update" OnClick="Button1_Click" />   
                                </div>
                                </center>
                           </div>
                      </div>
                     
                    </div>

                </div>

                <a href="homepage.aspx"><< Back To Home</a>
                <br />
                <br />

            </div>
            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                       <img src="images/books1.png" width="100px" />
                                </center>
                            </div>
                        </div>

                         <div class="row">
                            <div class="col">
                                <center>
                                       <h4>Your Issued Books</h4>
                                      <asp:Label ID="Label2" class="badge badge-pill badge-info" runat="server" Text="your books info"></asp:Label>
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
                                <asp:GridView ID="GridView1" class="table table-bordered table-striped" runat="server"></asp:GridView>
                            </div>
                        </div> 

                     
                    </div>

                </div>

            </div>
        </div>

        </div>
</asp:Content>
