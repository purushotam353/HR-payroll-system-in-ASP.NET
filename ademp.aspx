<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="ademp.aspx.cs" Inherits="HRPAYROLL.ademp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    


    <script>

        function readURL(input) {

            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('#img').attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }



        $(function () {

            $("#<%=FileUpload1.ClientID%>").change(function () {
                readURL(this);
            });

            $('#uploadbtn').on('click', function () {
                var pathArr = imagesrs.split('\\');

            });
        });

        // form validation
        $(document).ready(function () {



            $("#<%=depart.ClientID%>").on('blur', function () {
                    if ($("#<%=depart.ClientID%>").val().length == 0) {



                        document.getElementById("name").innerHTML = "enter department";
                    }


                }).on('focus', function () {


                    document.getElementById("name").innerHTML = "";

                });




                $("#<%=fname.ClientID%>").on('blur', function () {

                    if ($("#<%=fname.ClientID%>").val().length == 0) {




                        document.getElementById("fnam").innerHTML = "enter name field";
                    }


                }).on('focus', function () {


                    document.getElementById("fnam").innerHTML = "";


                });







                $("#<%=lasname.ClientID%>").on('blur', function () {
                    if ($("#<%=lasname.ClientID%>").val().length == 0) {





                        document.getElementById("lname").innerHTML = "enter lastname field";
                    }


                }).on('focus', function () {


                    document.getElementById("lname").innerHTML = "";

                });


                //email 


                $("#<%=email.ClientID%>").on('blur', function () {
                    if ($("#<%=email.ClientID%>").val().length == 0) {






                        document.getElementById("em").innerHTML = "enter mail id";
                    }


                }).on('focus', function () {


                    document.getElementById("em").innerHTML = "";

                });


                $("#<%=mobile.ClientID%>").on('blur', function () {


                    var m = $("#<%=mobile.ClientID%>").val().length;

                    if ((m > 10) || (m < 10)) {

                        document.getElementById("mob").innerHTML = "mobile no not valid";

                    }



                }).on('focus', function () {


                    document.getElementById("mob").innerHTML = "";

                });




                $("#<%=degi.ClientID%>").on('blur', function () {
                    if ($("#<%=degi.ClientID%>").val().length == 0) {






                        document.getElementById("deg").innerHTML = "enter degiganation";
                    }


                }).on('focus', function () {


                    document.getElementById("deg").innerHTML = "";

                });


                $("#<%=salary.ClientID%>").on('blur', function () {
                    if ($("#<%=salary.ClientID%>").val().length == 0) {






                        document.getElementById("sal").innerHTML = "enter salary";
                    }


                }).on('focus', function () {



                    document.getElementById("sal").innerHTML = "";

                });


                $("#<%=join.ClientID%>").on('blur', function () {
                    if ($("#<%=join.ClientID%>").val().length == 0) {




                        document.getElementById("doj").innerHTML = "enter date of joining";
                    }


                }).on('focus', function () {

                    document.getElementById("doj").innerHTML = "";


                });


                $("#<%=date.ClientID%>").on('blur', function () {
                    if ($("#<%=date.ClientID%>").val().length == 0) {


                        document.getElementById("dob").innerHTML = "enter date of birth";
                    }


                }).on('focus', function () {

                    document.getElementById("dob").innerHTML = "";



                });
            });
          



    </script>
    <style>
        #img
        {

            height:100px;
            width:100px;
        }


        #mainreg{


            margin-left:-100px;
        }

        #hrimage1 
        
        {
            height:100px;
            width:100px;
           
            margin-left:300px;
           margin-top:-30px;
        }


    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container" id="mainreg">

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <div class="panel panel-primary">
           <div class="panel-heading">
               <div class="panel-title">Register a New Employee Person</div>
                </div>
              
                <div class="panel-body">
                     <div class="form-group">
                         <div id="hrimage">
                             
                             <asp:FileUpload ID="FileUpload1" runat="server" />
                            
                             </div>
                         <div  id="hrimage1">
                           <img src="#" id="img" />

                             </div>
                     <label>Employee Id:</label>
                         <input type="text" runat="server" class="form-control" name="abhi" id="hrid" placeholder="EMPLOYEE ID*" disabled="disabled" />
                         </div>  
                    <div class="form-group">
                     <label>Name of Department:</label>
                         <input type="text" runat="server" class="form-control" id="depart" placeholder="NAME OF DEPARTMENT*" />
                        <span id="name" style="color:red;"></span>
                         </div>

                    <div class="form-group">
                     <label>First Name:</label>
                         <input type="text" runat="server" class="form-control" id="fname" placeholder="FIRST NAME*"/>
                        <span id="fnam" style="color:red;"></span>
                         </div>
                        <div class="form-group">
                             <label>Last Name:</label>
                            <input type="text" id="lasname" runat="server" class="form-control" placeholder="LAST NAME*" />
                            <span id="lname" style="color:red;"></span>
                            </div>
                    <div class="form-group">
                             <label>Email Id:</label>
                            <input type="email" id="email" runat="server" class="form-control" placeholder="EMAIL ID*" />
                            <span id="em" style="color:red;"></span>
                            </div>
                    <div class="form-group">
                             <label>Mobile Number:</label>
                            <input type="number" id="mobile" runat="server" class="form-control" placeholder="MOBILE NUMBER*"/>
                        <span id="mob" style="color:red;"></span>
                            </div>
                    <div class="form-group">
                             <label>Degination:</label>
                            <input type="text" id="degi" runat="server" class="form-control" placeholder="DEGINATION*"  />
                        <span id="deg" style="color:red;"></span>
                            </div>
                    <div class="form-group">
                           <label>Salary:</label>
                          <input type="text" runat="server" class="form-control" id="salary" placeholder="SALARY*" />
                        <span id="sal" style="color:red;"></span>
                          </div>
                    <div class="form-group">
                           <label>Date Of Joining:</label>
                          <input type="date" runat="server" class="form-control" id="join" placeholder="DATE OF JOINING*" />
                        <span id="doj" style="color:red;"></span>
                          </div>
                    <div class="form-group">
                             <label> Date of Birth:</label>
                            <input type="date" id="date" runat="server" class="form-control" placeholder="DATE OF BIRTH*" />
                        <span id="dob" style="color:red;"></span>
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
                    <asp:Button ID="Button1" Class="btn btn-primary" runat="server" Text="Submit" OnClick="Button1_Click" />
                   

                    <div id="msg" runat="server">

                        </div>
                </div>
            </div>
        </div>
    </div>
        </div>

</asp:Content>
