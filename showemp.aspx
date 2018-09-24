<%@ Page Title="" Language="C#" MasterPageFile="~/ADMIN.Master" AutoEventWireup="true" CodeBehind="showemp.aspx.cs" Inherits="HRPAYROLL.showemp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
     <%--ready response or get id for edit and delete data --%>
    <script>

        $(document).ready(function () {


            $(".chk").on('click', function () {

                var mailid = $(this).attr("id");


                $.ajax({
                    type: "POST",
                    url: "showemp.aspx/deletehr",
                    data: '{ mail:"' + mailid + '"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (data) {


                        if (data.d == "true") {


                            alert("suceesfully deleted");
                            window.location.href = "showemp.aspx";


                        }

                        else {


                            alert("could not delete item");


                        }
                    },
                    error: function (e) {
                        alert('some error in server side ');
                    }

                });




            });

            $(".chkedit").on('click', function () {

                var mailid = $(this).attr("id");


                $.ajax({
                    type: "POST",
                    url: "showemp.aspx/editemp",
                    data: '{mail:"' + mailid + '"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (data) {

                        window.location.href = "editemp.aspx";
                    },
                    error: function (e) {
                        alert('some error in server side ');
                    }

                });




            });


        });








    </script>





   


</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="emp"  runat="server">


    </div>
</asp:Content>
