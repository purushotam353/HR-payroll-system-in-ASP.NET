<%@ Page Title="" Language="C#" MasterPageFile="~/EMPLOYEE.Master" AutoEventWireup="true" CodeBehind="attendance.aspx.cs" Inherits="HRPAYROLL.attendance" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">


   <div id="date" runat="server" >

   </div>


<hr />
<table id="tblWeather" runat="server" border="0" cellpadding="0" cellspacing="0"
    visible="false">
    <tr>
        <th colspan="2">
            Weather Information
        </th>
    </tr>
    <tr>
        <td rowspan="3">
            <asp:Image ID="imgWeatherIcon" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblCity_Country" runat="server" />
            <asp:Image ID="imgCountryFlag" runat="server" />
            <asp:Label ID="lblDescription" runat="server" />
            Humidity:
            <asp:Label ID="lblHumidity" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Temperature:
            (Min:
            <asp:Label ID="lblTempMin" runat="server" />
            Max:
            <asp:Label ID="lblTempMax" runat="server" />
                Day:
            <asp:Label ID="lblTempDay" runat="server" />
                Night:
            <asp:Label ID="lblTempNight" runat="server" />)
        </td>
    </tr>
</table>
    <asp:Button ID="btn" runat="server" Text="Set todays attendence"  cssclass="btn btn-primary"   OnClick="btn_Click" />


    <div runat="server" id="atend">

        </div>
</asp:Content>
