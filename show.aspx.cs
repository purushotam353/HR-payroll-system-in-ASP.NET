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
    public partial class show : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";


            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select *from Hr",con);

            SqlDataReader sdr = cmd.ExecuteReader();


          
            html = "<table class='table'>";
            html += "<tr>";
            html += "<th>HRID</th> ";
            html += "<th>NAME OF DEPARTMENT</th> ";
            html += "<th>FIRST NAME </th> ";
            html += "<th>LAST NAME</th> ";
            html += "<th>EMAIL ID</th> ";
            html += "<th>MOBILE NUMBER</th> ";
            html += "<th>DEGINATION</th> ";
            html += "<th>SALARY </th> ";
            html += "<th>DATE OF JOINING</th> ";
            html += "<th>DATE OF BIRTH</th> ";
            html += "<th>GENDER</th> ";
            html += "<th>EDIT</th> ";
            html += "<th>DELETE</th> ";
            html += "</tr>";
            
            while(sdr.Read())
            {
                html += "<tr>";
                html += "<td>"+sdr["Hr Id"].ToString()+"</td>";
                html += "<td>" + sdr["name of department"].ToString() + "</td>";
                html += "<td>" + sdr["fname"].ToString() + "</td>";
                html += "<td>" + sdr["lname"].ToString() + "</td>";
                html += "<td>" + sdr["email id"].ToString() + "</td>";
                html += "<td>" + sdr["mobile number"].ToString() + "</td>";
                html += "<td>" + sdr["degination"].ToString() + "</td>";
                html += "<td>" + sdr["salary"].ToString() + "</td>";
                html += "<td>" + sdr["date of joining"].ToString() + "</td>";
                html += "<td>" + sdr["date of birth"].ToString() + "</td>";
                html += "<td>" + sdr["gender"].ToString() + "</td>";
               

                html += "<td> <a  type='button'   class='chkedit'  id="+sdr["email id"].ToString()+">EDIT</a></td>";
                html += "<td> <a  type='button'   class='chk'  id=" + sdr["email id"].ToString() + ">DELETE</a></td>";
                html += "</tr>";
            }
              html += "</table>";
              con.Close();
             Hr.InnerHtml = html; 
     
        
        
        }



        protected void sethrsession( string id)
        {

            Session["hredit"] = id;

            
            
        }
       
        [WebMethod]
        static public void edithr(string mail)
        {

            show ob = new show();
            ob.sethrsession(mail);


        }
        [WebMethod]
        static public string deletehr(string mail)
        {


            string success = "false";
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        SqlConnection con = new SqlConnection(constr);


        con.Open();
        SqlCommand cmd = new SqlCommand("delete from hr where [email id]= '" + mail + "'", con);



        int i = cmd.ExecuteNonQuery();

            if(i>0)
            {

                success = "true";

            }
            return success;
            
     
        }
    }



}






