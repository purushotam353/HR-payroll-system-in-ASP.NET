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
    public partial class Event : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

 string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            string html = "";



            SqlConnection con = new SqlConnection(constr);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Event", con);




            SqlDataReader sdr = cmd.ExecuteReader();


            while(sdr.Read())
            
            
            {


                html += " <a href='#'><div class='panel panel-info'><div class='panel-heading'>" + sdr["Event"].ToString() + "</div><div class='panel-heading'>" + sdr["Date"].ToString() + "</div><div class='panel-body'>" + sdr["Discription"].ToString() + "</div> </div></a>";

            }

            events.InnerHtml = html;
            



        }
    } }
