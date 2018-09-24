<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="edithr.aspx.cs" Inherits="HRPAYROLL.edithr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="container">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <div class="panel panel-primary">
           <div class="panel-heading">
               <div class="panel-title">Edit A Hr Person Details</div>
                </div>
              
                <div class="panel-body">
                     <div class="form-group">
                     <label>Hr Id:</label>
                         <input type="text" runat="server" class="form-control" name="abhi" id="hrid"  disabled="disabled" />
                         </div>  
                    <div class="form-group">
                     <label>Name of Department:</label>
                         <input type="text" runat="server" class="form-control" id="depart"  />
                         </div>

                    <div class="form-group">
                     <label>First Name:</label>
                         <input type="text" runat="server" class="form-control" id="fname" />
                         </div>
                        <div class="form-group">
                             <label>Last Name:</label>
                            <input type="text" id="lasname" runat="server" class="form-control"  />
                            </div>
                    <div class="form-group">
                             <label>Email Id:</label>
                            <input type="email" id="email" runat="server" class="form-control"  />
                            </div>
                    <div class="form-group">
                             <label>Mobile Number:</label>
                            <input type="number" id="mobile" runat="server" class="form-control" />
                            </div>
                    <div class="form-group">
                             <label>Degination:</label>
                            <input type="text" id="degi" runat="server" class="form-control"   />
                            </div>
                    <div class="form-group">
                           <label>Salary:</label>
                          <input type="text" runat="server" class="form-control" id="salary"  />
                          </div>
                    <div class="form-group">
                           <label>Date Of Joining:</label>
                          <input type="date" runat="server" class="form-control" id="join"  />
                          </div>
                    <div class="form-group">
                             <label> Date of Birth:</label>
                            <input type="date" id="date" runat="server" class="form-control"  />
                            </div>
                      
                    <div class="form-group">
                             <label>Gender: </label>
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                            <asp:ListItem  Selected="True"  >male</asp:ListItem>
                            <asp:ListItem>female</asp:ListItem>

                        </asp:RadioButtonList><br />
                           
                        
                            </div>   
                     
  </div>
                     
                <div class="panel-footer">
                    <asp:Button ID="Button1" runat="server" Class="btn btn-primary" Text="Submit" onclick="Button1_Click" />
                   

                    <div id="msg" runat="server">

                        </div>
                </div>
            </div>
        </div>
    </div>
        </div>




</asp:Content>
