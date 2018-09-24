<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="EMPLOYEELOGIN.aspx.cs" Inherits="HRPAYROLL.EMPLOYEELOGIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="Models/jquery/jquery-3.1.1.min.js"></script>
    <script>
        $(document).ready(function () {



            $("#<%=email.ClientID%>").on('blur', function () {


                if ($("#<%=email.ClientID%>").val().length == 0) {


                    document.getElementById("dname").innerHTML = "Enter username";
                }

            }).on('focus', function () {


                document.getElementById("dname").innerHTML = "";

            });




            $("#<%=txtpass.ClientID%>").on('blur', function () {

                if ($("#<%=txtpass.ClientID%>").val().length == 0) {



                    document.getElementById("pass").innerHTML = "Enter password";
                }


            }).on('focus', function () {

                document.getElementById("pass").innerHTML = "";



            });

        });

        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


 <div>    
    <div class="container">
    <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <div class="panel panel-primary">
           <div class="panel-heading">
               <div class="panel-title">WELCOME TO EMPLOYEE LOGIN PANNEL</div>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                     <label>User Id:</label>
                         <input type="text" runat="server" class="form-control" id="email" />
                         <span id="dname" style="color:red;"></span>
                         </div>
                        <div class="form-group">
                             <label>Password:</label>
                            <input type="password" id="txtpass" runat="server" class="form-control" />
                             <span id="pass" style="color:red;"></span>
                            </div>
                   
                   
  </div>
                     
                <div class="panel-footer">
                    <asp:Button ID="lgemployee" runat="server" Class="btn btn-primary" Text="Submit" OnClick="lgemployee_Click1"  />

                    <div id="error" runat="server">

                        </div>
                </div>
            </div>
        </div>
    </div>
        </div>

    </div>
 












</asp:Content>
