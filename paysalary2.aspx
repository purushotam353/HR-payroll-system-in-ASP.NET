<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="paysalary2.aspx.cs" Inherits="HRPAYROLL.paysalary2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div runat="server" id="hora1" style="background-color:green;">  </div>
    <div runat="server" id="hora" style="background-color:red;">  </div>
    
    <label>Employee Name:</label>  <asp:Label ID="Label" runat="server" Text="Label"> </asp:Label><br />
       <label>Employee Id:</label><asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
       <label>Employee Degination:</label><asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
       <label>Total Salary:</label><asp:Label ID="Label4" runat="server" Text="Label"></asp:Label> <br />
      <label>Select Month:</label>
                         <asp:DropDownList ID="DropDownList3" runat="server"    AutoPostBack="True"     OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"   >
                              <asp:ListItem>--select month--</asp:ListItem>
                             <asp:ListItem >January</asp:ListItem>
                              <asp:ListItem>February</asp:ListItem>
                              <asp:ListItem>March</asp:ListItem>
                              <asp:ListItem>April</asp:ListItem>
                              <asp:ListItem>May</asp:ListItem>
                              <asp:ListItem>Jun</asp:ListItem>
                              <asp:ListItem>July</asp:ListItem>
                             <asp:ListItem>August</asp:ListItem>
                             <asp:ListItem>September</asp:ListItem>
                             <asp:ListItem>October</asp:ListItem>
                             <asp:ListItem>November</asp:ListItem>
                             <asp:ListItem>December</asp:ListItem>


                         </asp:DropDownList>
    <br />

    <asp:Panel ID="Panel1" runat="server">

       
      
        <label>Total Fullday:</label><asp:Label ID="lblfd" runat="server" Text="Label"></asp:Label><br />
         <label>Total Halfday:</label><asp:Label ID="lblhf" runat="server" Text="Label"></asp:Label><br />
      <%--  <label>Gross Salary:</label><asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>--%>
        <label>Basic Salary:</label><asp:Label ID="lblbs" runat="server" Text="Label"></asp:Label><br />

        <label>Dediction:</label><br />
                             <asp:CheckBox ID="chkmd" runat="server"   /><label>Medical Deduction</label>
                               <asp:Label ID="md1" runat="server" ></asp:Label><br />
                             <asp:CheckBox ID="chkpf" runat="server" /><label>Providant Fund Deduction </label>
         <asp:Label ID="pf1" runat="server" ></asp:Label><br />
                             <asp:CheckBox ID="chklic" runat="server" /><label>LIC </label>
                             <asp:Label ID="lic1" runat="server" ></asp:Label><br />
         <label>Benifits:</label><br />
                             <asp:CheckBox ID="chkha" runat="server" /><label>Housing allowance</label>
                            <asp:Label ID="hra1" runat="server" ></asp:Label><br />
                             <asp:CheckBox ID="chkda" runat="server" /><label>Dearness allowance</label>
                             <asp:Label ID="da1" runat="server" ></asp:Label><br />
                             <asp:CheckBox ID="chkothr" runat="server" /><label>Other allowance</label>
                             <asp:Label ID="other1" runat="server" ></asp:Label><br />
                            
       
       <label>Final Salary:</label> <asp:Label ID="txtsal" runat="server" Text=""></asp:Label><br />
    </asp:Panel>
    


    <asp:Button ID="Button2"    runat="server" Text="Calculate"    OnClicK="Button2_Click"  />
     
        <asp:Button ID="Button1" runat="server"  Text="pay!"  OnClick="Button1_Click" />       
 

    
</asp:Content>
