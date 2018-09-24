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



namespace HRPAYROLL
{
    public partial class EMPLOYEELOGIN : System.Web.UI.Page
    {

        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void lgemployee_Click1(object sender, EventArgs e)
        {


            string ID = "";
            string PASS = "";
            string roll = "";

            string id = email.Value;
            string pass = txtpass.Value;



            SqlConnection con = new SqlConnection(constr);

            con.Open();

            SqlCommand cmd = new SqlCommand("select * from login", con);




            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read() && ID != id)
            {



                ID = sdr["username"].ToString();
                PASS = sdr["password"].ToString();
                roll = sdr["rolltype"].ToString();


            }



            if (id == ID && pass == PASS && roll=="emplogin")
            {
                Session["emplogin"] = "true";
                Session["empid"] = ID;
                Session["emppass"] = pass;
                Response.Redirect("HomeEMPLOYEE.aspx");


            }
            else
            {

                error.InnerHtml = "Invalid id password";


            }
        }
    }
}