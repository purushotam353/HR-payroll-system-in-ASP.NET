<%@ Page Title="" Language="C#" MasterPageFile="~/HR.Master" AutoEventWireup="true" CodeBehind="editmanageSal.aspx.cs" Inherits="HRPAYROLL.editmanageSal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

     <div class="row">
        <div class="col-md-6 col-md-offset-3">
          <div class="panel panel-primary">
           <div class="panel-heading">
               <div class="panel-title">EDIT MANAGE SALARY TABLE</div>
                </div>
              
                <div class="panel-body">
                     <div class="form-group">
                        
                     <label>Degination:</label>
                         <input type="text" runat="server" class="form-control" name="abhi" id="degination"  />
                         </div>  
                    <div class="form-group">
                     <label>MEDICAL  DEDICTION:</label>
                         <input type="text" runat="server" class="form-control" id="md"  />
                         </div>

                    <div class="form-group">
                     <label>PF:</label>
                         <input type="text" runat="server" class="form-control" id="pf" />
                         </div>
                        <div class="form-group">
                             <label>HRA:</label>
                            <input type="text" id="hra" runat="server" class="form-control"  />
                            </div>
                    <div class="form-group">
                             <label>DA:</label>
                            <input type="text" id="da" runat="server" class="form-control"  />
                            </div>
                    <div class="form-group">
                             <label>OTHER:</label>
                            <input type="text" id="other" runat="server" class="form-control" />
                            </div>
                    
  </div>
                     
                <div class="panel-footer">
                    <asp:Button ID="Button1" runat="server" Class="btn btn-primary" Text="SAVE EDIT DATA !" OnClick="Button1_Click"  />
                    

                    <div id="msg" runat="server">

                        </div>
                </div>
            </div>
        </div>
    </div>
        





</asp:Content>
