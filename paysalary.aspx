<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="paysalary.aspx.cs" Inherits="HRPAYROLL.paysalary" %>
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
               <div class="panel-title">Pay salary</div>
                </div>
                <div class="panel-body">

                    <div class="form-group">
                     <label>Emplioyee Id:</label>
                        <asp:DropDownList ID="DropDownList1" runat="server">

                           

                        </asp:DropDownList>
                         </div>
              
  </div>
                     
                <div class="panel-footer">
                    
                    <asp:Button ID="lgadmin" runat="server" Class="btn btn-primary"  Text="Pay salary!" OnClick="lgadmin_Click"  />
                    <div id="error" runat="server">
                                        
                        </div>
                   
                </div>
            </div>
        </div>
    </div>
        </div>

    </div>
 


</asp:Content>
