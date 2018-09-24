using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRPAYROLL
{
    public partial class ADMIN : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

               if(Session["adminlogin"].ToString() =="true")
            {


            }

            }


          
            catch
            {

                Session["loginerr"] = "please login as admin";
                Response.Redirect("showerror.aspx");


            }

            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {


            Session.Clear();
            Session.RemoveAll();

            Response.Redirect("WebForm1.aspx");

        }

       
    }
}