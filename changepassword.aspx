<%@ Page Title="" Language="C#" MasterPageFile="~/EMPLOYEE.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="HRPAYROLL.changepassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div>    
    <div class="container">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <div class="panel panel-primary">
           <div class="panel-heading">
               <div class="panel-title">change password</div>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                     <label>old password:</label>
                         <input  type="password"  runat="server"  class="form-control" id="p1" />
                        <div runat="server" id="div1" style="color:red;"></div>
                         </div>
                        <div class="form-group">
                             <label>New password:</label>
                            <input  type="password"  id="p2"  runat="server" class="form-control" />
                            
                            </div>
                    <label>confirm password:</label>
                            <input  type="password"  id="p3"  runat="server" class="form-control" />
                    <div runat="server" id="div2" style="color:red;"></div>
                            </div>
                   
  </div>
                     
                <div class="panel-footer">
                    
                    <asp:Button ID="Button1" Class="btn btn-primary" runat="server" Text="Change Password !" onclick="Button1_Click"/>        
                    <div runat="server" id="pass"> </div>
</div>
            </div>
        </div>
        </div>
         </div>







</asp:Content>
