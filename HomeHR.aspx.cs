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
    public partial class HomeHR : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            


            
           if(!IsPostBack)
           {
                string day = DateTime.Now.DayOfWeek.ToString();
                char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
                string time = DateTime.Now.ToLongTimeString();
                string[] spilttime = time.Split(delimiterChars);
                int h = Convert.ToInt32(spilttime[0].ToString());
                string sloat = spilttime[3];

               
               

                if ((h >= 9 && h <= 11) && sloat == "AM") 
                {
                   wish.InnerHtml = "good morning";
                }
            else if(h == 12 && sloat == "PM")
                {

                    wish.InnerHtml = "good afternoon";

            }

                else if(h >= 4 && sloat == "PM")
                {


                    wish.InnerHtml="good evening";
                }

                get_details();
            }
        }







        public void get_details()
        {
            try
            {
                string id = Session["hrid"].ToString();


                SqlConnection con = new SqlConnection(constr);

                con.Open();

                SqlCommand cmd = new SqlCommand("select fname from Hr where [Hr Id]='" + id + "'", con);
                name.InnerHtml = cmd.ExecuteScalar().ToString();

            }
            catch
            {
                Session["mailerr"] = "please login first";
                Response.Redirect("error.aspx");
            }

        }


    }
}