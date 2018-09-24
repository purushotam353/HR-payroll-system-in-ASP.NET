<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="HRPAYROLL.contactus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script src="Models/jquery/jquery-3.1.1.min.js"></script>
    <script>
        $(document).ready(function () {
            $("#<%=fname.ClientID%>").on('blur', function () {

                if ($("#<%=fname.ClientID%>").val().length == 0) {



                     document.getElementById("fn").innerHTML = "enter name field";
                 }


             }).on('focus', function () {

                 document.getElementById("fn").innerHTML = "";



             });


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

            });;


            $("#<%=reasion.ClientID%>").on('blur', function () {
                if ($("#<%=reasion.ClientID%>").val().length == 0) {




                    document.getElementById("deg").innerHTML = "enter degiganation";
                }


            }).on('focus', function () {

                document.getElementById("deg").innerHTML = "";


            });

        });




</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      
       
     <table height="400px" width="100%" align="center" border="0" style="background-color:black; color:white;">
                <tr height="250px">
                    <td width="400px" align="center"> <h1>Headquater</h1><br /><br />
                        Address: Pune<br /><br />
                  
                  Office:620,Madhayam marg,near rajwada road pune(411008)<br /><br />
                  contact:+91-8503960504|purushotamraj353@gmail.com
</td>
                    <td width="400px" align="center"><h1>Jaipur</h1><br /><br />
                        707,apex tower ,lalkothi Tonk road<br /><br />
                        Jaipur 302017<br /><br />
                        Email:abhi.1232gmail.com


                    </td>
                    <td align="center"center">

                       <h1 style="color=blue;">Follow us::</h1> <br /><br />
                        Facebook:www.facebook.com/Iskylar<br /><br />
                        Twitter:www.twitter.com/Iskylar<br /><br />
                        Instagram:@Iskylar

                    </td>
                </tr>
            </table>



    
    <div class="row">
        <div class="col-md-4  col-md-offset-1">
          <div class="panel panel-warning">
           <div class="panel-heading">
               <div class="panel-title"><h1>Feedback</h1></div>
                </div>
              
                <div class="panel-body">
                     <div class="form-group">
                   
                    <div class="form-group">
                     <label>Name:</label>
                         <input type="text" runat="server" class="form-control" id="fname" placeholder="NAME*"/>
                         <span id="fn" style="color:red;"></span>
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
                             <label>Suggestion:</label>
                            <textarea rows="4" cols="50" id="reasion" runat="server" class="form-control"> </textarea>
                               <span id="deg" style="color:red;"></span>
                            </div>
                     
             
                    <asp:Button ID="Button1" CssClass="btn btn-warning" runat="server" Text="Submit" />
         
                        </div>
              </div>
    </div>
    </div>
        </div>

              <div style="margin-left:800px; margin-top:-400px;">
                  <img src="images/loc.png" />          </div>













</asp:Content>
