<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="manageSaL.aspx.cs" Inherits="HRPAYROLL.manageSaL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <%--ready response or get id for edit and delete data --%>
    <script>

        $(document).ready(function () {

            $(".chkedit").on('click', function () {

                var mailid = $(this).attr("id");


                $.ajax({
                    type: "POST",
                    url: "manageSaL.aspx/editsal",
                    data: '{mail:"' + mailid + '"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (data) {

                        window.location.href = "editmanageSal.aspx";
                    },
                    error: function (e) {
                        alert('some error in server side ');
                    }

                });




            });


        });








    </script>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



    <div id="sal" runat="server"></div>
</asp:Content>
