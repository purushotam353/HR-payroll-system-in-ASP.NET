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
    public partial class changepassword : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string id = Session["empid"].ToString();

                string oldpass = p1.Value;
                string nwpass = p2.Value;
                string conf = p3.Value;


                SqlConnection con = new SqlConnection(constr);

                con.Open();

                if (oldpass == Session["emppass"].ToString())
                {

                    if (nwpass == conf)
                    {


                        SqlCommand cmd1 = new SqlCommand("update login set password='" + nwpass + "' where username='" + id + "'", con);

                        int i = cmd1.ExecuteNonQuery();


                        if (i > 0)
                        {

                        }

                        else
                        {
                               div1.InnerHtml = "some error occur";
                        }


                    }



                    else
                    {

                        div2.InnerHtml = "password not matched";

                        }

                    
                   
                }
                else
                {
                    div1.InnerHtml = "old password not mache";

                }
            }
            catch (Exception ex)
            {

                Session["mailerr"] = "password not found";
                Response.Redirect("error.aspx");
            }

            finally {

                pass.InnerHtml = "Change password sucessfully";

            }
           
        }
    }
}

 