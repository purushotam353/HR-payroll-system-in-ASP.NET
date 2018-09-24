<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="applyleavehr.aspx.cs" Inherits="HRPAYROLL.applyleavehr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #leaveapply {
            margin-left: 200px;
        }
        </style>

    <script>

        $(document).ready(function () {
         

            $(".chkedit").on('click', function () {

                var lvid = $(this).attr("id");
              
                var empid = $(this).attr("name");

                $.ajax({
                    type: "POST",
                    url: "applyleavehr.aspx/update",
                    data: '{ leaveid:"' + lvid + '",empid:"'+empid+'"}',
                    contentType: "application/json",
                    dataType: "json",

                    success: function (data) {


                            window.location.href = "applyleavehr.aspx";

                       
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

    <div id="leaveapply" runat="server">

        </div>
</asp:Content>
