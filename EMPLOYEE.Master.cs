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
    public partial class EMPLOYEE : System.Web.UI.MasterPage
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (Session["emplogin"].ToString() == "true")
                {


                }

            }



            catch
            {

                Session["loginerr"] = "please login as employee";
                Response.Redirect("showerror.aspx");


            }


            notification();
            string imagename = "";

            SqlConnection con = new SqlConnection(constr);

            con.Open();


            string id = Session["empid"].ToString();
            SqlCommand cmd1 = new SqlCommand("select image from emp where [Employee Id]='" + id + "'", con);


            imagename = cmd1.ExecuteScalar().ToString();

            img.Src = "profile pic/employee profile/" + imagename;

            con.Close();


        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            Session.Clear();
            Session.RemoveAll();

            Response.Redirect("WebForm1.aspx");

        }

        public void notification()
        {

            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Empnotification where empid='"+Session["empid"].ToString()+"' and isnew=1 ", con);

            string no = cmd.ExecuteScalar().ToString();


            SqlCommand cmd1 = new SqlCommand("select * from Empnotification where empid='" + Session["empid"].ToString() + "' and isnew=1 ", con);


            SqlDataReader sdr = cmd1.ExecuteReader();


            while(sdr.Read())
            {

                lk1.InnerHtml = sdr["description"].ToString();

            }

            notNo.InnerHtml = no;


        }

    }
}