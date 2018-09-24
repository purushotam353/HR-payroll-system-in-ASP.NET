using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.Services;
namespace HRPAYROLL
{
    public partial class applyleavehr : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";


            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select *from applyleave", con);
            
            SqlDataReader sdr = cmd.ExecuteReader();

            html = "<table class='table'>";
            html += "<tr>";
            html += "<th>EMPLOYEE ID</th> ";
            html += "<th>EMPLOYEE NAME</th> ";
            html += "<th>DURATION OF LEAVE</th> ";
            html += "<th>FIRST DATE OF LEAVE</th> ";
            html += "<th>LAST DATE OF LEAVE</th> ";
            html += "<th>REASION</th> ";
            html += "<th>LEAVE ID</th> ";
            html += "<th>STATUS</th> ";
           
            html += "<th>APPROVE/NOT APPROVE</th> ";
            html += "</tr>";

            while (sdr.Read())
            {
                html += "<tr>";
                html += "<td>" + sdr["Employee Id"].ToString() + "</td>";
                html += "<td>" + sdr["Employee Name"].ToString() + "</td>";
                html += "<td>" + sdr["Duration of Leave"].ToString() + "</td>";
                html += "<td>" + sdr["First Date of Leave"].ToString() + "</td>";
                html += "<td>" + sdr["Last Date of Leave"].ToString() + "</td>";
                html += "<td>" + sdr["Reasion"].ToString() + "</td>";
                html += "<td>" + sdr["leave Id"].ToString() + "</td>";
                html += "<td>" + sdr["status"].ToString() + "</td>";


                html += "<td> <input  type='button'  name="+sdr["Employee Id"].ToString()+" value='apporve' class='chkedit'  id=" + sdr["leave Id"].ToString() + "></td>";
                html += "</tr>";
            }
            html += "</table>";
            con.Close();
            leaveapply.InnerHtml = html; 
     
       
        }
        protected void leave(string LVID,string EMPID)
        {

            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
             con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE applyleave SET status='approve' WHERE [leave Id]='" + LVID + "'", con);
                int i = cmd.ExecuteNonQuery();
            SqlCommand cmd1 = new SqlCommand("insert into Empnotification values('your "+i+" leave is approved',1,'"+EMPID+"')",con);
            int j=  cmd1.ExecuteNonQuery();

           
        




        }

        [WebMethod]
        static public void update(string leaveid,string empid)
        {


            applyleavehr ob = new applyleavehr();
            ob.leave(leaveid,empid);


        }

    }
}