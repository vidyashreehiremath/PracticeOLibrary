<%@ Page Title="" Language="C#" MasterPageFile="~/library.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="ElibraryManagement.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
           $(document).ready(function () {

               //$(document).ready(function () {
               //$('.table').DataTable();
               // });

               $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
               //$('.table1').DataTable();
           });
   </script>
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
                                        <h4>Member Details</h4>
                                    </center>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="images/generaluser.png" />
                                       
                                    </center>
                            </div>
                        </div>
 
                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
 
                        <div class="row">
                            
                            <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Member ID"></asp:TextBox>
                                   <asp:LinkButton class="btn btn-primary" ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                   <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Full Name" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Account status</label>
                                <div class="form-group">
                                 <div class="input-group">
                                   <asp:TextBox CssClass="form-control m-1" ID="TextBox7" runat="server" placeholder="Status" ReadOnly="true"></asp:TextBox>
                                   
                                   <asp:LinkButton class="btn btn-success mr-1" ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><i class="fas fa-check-circle"></i></asp:LinkButton>

                                    <asp:LinkButton class="btn btn-warning mr-1" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><i class="far fa-pause-circle"></i></asp:LinkButton>

                                    <asp:LinkButton class="btn btn-danger mr-1" ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><i class="fas fa-times-circle"></i></asp:LinkButton>
                                   
                                    </div>
                                 </div>
                            </div>
                        </div>

                        <div class="row">
                            
                            <div class="col-md-3">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="DOB" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Contact No" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-5">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="Email ID" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                         <div class="row">
                            
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox9" runat="server" placeholder="State" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                             <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox10" runat="server" placeholder="City" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-4">
                                <label>Pin Code</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox11" runat="server" placeholder="Pin Code" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        
                        <div class="row">
                            
                            <div class="col-md-12">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Full Postal Address" TextMode="MultiLine" ReadOnly="true" Rows="2"></asp:TextBox>
                                </div>
                            </div>

                        </div>
 
                        <div class="row">
                     
                            <div class="col-8 mx-auto">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="Delete User Permanently" OnClick="Button3_Click" />
                            </div>
                            
                        </div>
 
 
                    </div>
                </div>
 
                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>

           <div class="col-md-7">

                <div class="card">
                    <div class="card-body">

                         <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                  </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />
                            </div>
                        </div>

                        <div class="row">
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                            <div class="col">
                                <asp:GridView ID="GridView1" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div> 

                     
                    </div>

                </div>

            </div>
       </div>
   </div>
</asp:Content>
