using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRPAYROLL
{
    public partial class manageSaL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;


            string html = "";


            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select *from salarybase", con);

            SqlDataReader sdr = cmd.ExecuteReader();



            html = "<table class='table'>";
            html += "<tr>";
            html += "<th>DEGINATION</th> ";
            html += "<th>MEDICAL DEDICATION(%)</th> ";
            html += "<th>PF(%) </th> ";
            html += "<th>LIC(%)</th> ";
            html += "<th>HRA(%)</th> ";
            html += "<th>DA(%)</th> ";
            html += "<th>OTHER(%)</th> ";
            html += "<th>EDIT</th> "; 
            html += "</tr>";

            while (sdr.Read())
            {
                html += "<tr>";
                html += "<td>" + sdr["degination"].ToString() + "</td>";
                html += "<td>" + sdr["md"].ToString() + "</td>";
                html += "<td>" + sdr["pf"].ToString() + "</td>";
                html += "<td>" + sdr["lic"].ToString() + "</td>";
                html += "<td>" + sdr["hra"].ToString() + "</td>";
                html += "<td>" + sdr["da"].ToString() + "</td>";
                html += "<td>" + sdr["other"].ToString() + "</td>";

                html += "<td> <a  type='button'   class='chkedit'  id=" + sdr["degination"].ToString() + ">EDIT</a></td>";
               
                html += "</tr>";
            }
            html += "</table>";
            con.Close();
            sal.InnerHtml = html; 
     
        

        }


        protected void setempsession(string id)
        {

            Session["saledit"] = id;



        }


        [WebMethod]
        static public void editsal(string mail)
        {

            manageSaL ob = new manageSaL();
            ob.setempsession(mail);


        }
      
       //// static public string deletehr(string mail)
       // {


       //     string success = "false";
       //     string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
       //     SqlConnection con = new SqlConnection(constr);


       //     con.Open();
       //     SqlCommand cmd = new SqlCommand("delete from emp where [email id]= '" + mail + "'", con);



       //     int i = cmd.ExecuteNonQuery();

       //     if (i > 0)
       //     {

       //         success = "true";

       //     }
       //     return success;


       // }
    }
}