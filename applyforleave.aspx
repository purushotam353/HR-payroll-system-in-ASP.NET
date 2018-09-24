<%@ Page Title="" Language="C#" MasterPageFile="~/EMPLOYEE.Master" AutoEventWireup="true" CodeBehind="applyforleave.aspx.cs" Inherits="HRPAYROLL.applyforleave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script src="Models/jquery/jquery-3.1.1.min.js"></script>
    <script>

        $(document).ready(function () {



            $("#<%=empid.ClientID%>").on('blur', function () {


        if ($("#<%=empid.ClientID%>").val().length == 0) {


                    document.getElementById("empi").innerHTML = "Enter Employee Id";
                }

            }).on('focus', function () {


                document.getElementById("empi").innerHTML = "";

            });




    $("#<%=name.ClientID%>").on('blur', function () {

        if ($("#<%=name.ClientID%>").val().length == 0) {



                    document.getElementById("dname").innerHTML = "Enter Your Name";
                }


            }).on('focus', function () {

                document.getElementById("dname").innerHTML = "";



            });



    $("#<%=duration.ClientID%>").on('blur', function () {

        if ($("#<%=duration.ClientID%>").val().length == 0) {



                    document.getElementById("ln").innerHTML = "Enter Duration of Leave";
                }


            }).on('focus', function () {

                document.getElementById("ln").innerHTML = "";


            });



   
    $("#<%=fdate.ClientID%>").on('blur', function () {
        if ($("#<%=fdate.ClientID%>").val().length == 0) {



                    document.getElementById("doj").innerHTML = "Enter First Date of Leave";
                }


            }).on('focus', function () {


                document.getElementById("doj").innerHTML = "";


            });



    $("#<%=ldate.ClientID%>").on('blur', function () {
        if ($("#<%=ldate.ClientID%>").val().length == 0) {


                    document.getElementById("dob").innerHTML = "Enter  Last Date Of Leave";
                }

            }).on('focus', function () {


                document.getElementById("dob").innerHTML = "";

            });




            $("#<%=reasion.ClientID%>").on('blur', function () {

                if ($("#<%=reasion.ClientID%>").val().length == 0) {



                    document.getElementById("reasn").innerHTML = "Enter Reasion of leave ";
                 }


             }).on('focus', function () {

                 document.getElementById("reasn").innerHTML = "";


             });

});


</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<div class="container" id="mainreg">

    <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <div class="panel panel-primary">
           <div class="panel-heading">
               <div class="panel-title">apply for leave</div>
                </div>
              
                <div class="panel-body">

                     <div class="form-group">

                     <label>Leave Id:</label>
                         <input type="text" runat="server" class="form-control"  id="Text1" placeholder="LEAVE ID*" disabled="disabled" />
                         </div> 

                     <div class="form-group">

                     <label>Employee Id:</label>
                         <input type="text" runat="server" class="form-control" name="abhi" id="empid" placeholder="EMPLOYEE ID*" />
                          <span id="empi" style="color:red;"></span>
                         </div>  

                    <div class="form-group">
                     <label>Employee Name:</label>
                         <input type="text" runat="server" class="form-control" id="name" placeholder="EMPLOYEE NAME*"/>
                         <span id="dname" style="color:red;"></span>
                         </div>

                     <div class="form-group">
                           <label> Duration of leave:</label>
                          <input type="text" runat="server" class="form-control" id="duration" placeholder="DURATION OF LEAVE*" />
                          <span id="ln" style="color:red;"></span>
                          </div>
               
                    <div class="form-group">
                           <label> First Date of leave:</label>
                          <input type="date" runat="server" class="form-control" id="fdate" placeholder="FIRST DATE OF LEAVE*" />
                         <span id="doj" style="color:red;"></span>
                          </div>
                    <div class="form-group">
                             <label>Last Date of leave:</label>
                            <input type="date" id="ldate" runat="server" class="form-control" placeholder=" LAST DATE OF LEAVE*" />
                         <span id="dob" style="color:red;"></span>
                            </div>
                      <div class="form-group">
                             <label>Reasion of leave:</label>
                            <textarea rows="4" cols="50" id="reasion" runat="server" class="form-control"> </textarea>
                           <span id="reasn" style="color:red;"></span>
                            </div>
                     
  </div>
                     
                <div class="panel-footer">
                    <asp:Button ID="Button1" Class="btn btn-primary" runat="server" Text="Submit" onclick="Button1_Click"/>
                    
                    <div id="msg" runat="server">

                        </div>
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
