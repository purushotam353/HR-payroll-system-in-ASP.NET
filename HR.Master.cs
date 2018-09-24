using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRPAYROLL
{
    public partial class Hr : System.Web.UI.MasterPage
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["hrlogin"].ToString() == "true")
                {


                }

            }



            catch
            {

                Session["loginerr"] = "please login as Hr";
                Response.Redirect("showerror.aspx");


            }


            string imagename = "";

            SqlConnection con = new SqlConnection(constr);

            con.Open();


            string id = Session["hrid"].ToString();
            SqlCommand cmd1 = new SqlCommand("select image from Hr where [Hr Id]='" + id + "'", con);


            imagename = cmd1.ExecuteScalar().ToString();

            img.Src = "profile pic/hr profile/" + imagename;

            con.Close();


        }

        protected void Button1_Click1(object sender, EventArgs e)
        {


            Session.Clear();
            Session.RemoveAll();

            Response.Redirect("WebForm1.aspx");

        }
    }
}
