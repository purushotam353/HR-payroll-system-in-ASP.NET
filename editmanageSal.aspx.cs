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
    public partial class editmanageSal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                getdata();

            }
        }
        protected void getdata()
        {
            string mailid = Session["saledit"].ToString();


            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);


            con.Open();
            SqlCommand cmd = new SqlCommand("select * from salarybase where degination= '" + mailid + "'", con);

            SqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {


                degination.Value = sdr["degination"].ToString();
                md.Value = sdr["md"].ToString();
                pf.Value = sdr["pf"].ToString();
                hra.Value = sdr["hra"].ToString();
                da.Value = sdr["da"].ToString();
                other.Value = sdr["other"].ToString();
                
            }






        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string DEGINATION = degination.Value;
            string MD = md.Value;
            string PF = pf.Value;
            string HRA = hra.Value;
            string DA = da.Value;
            string OTHER = other.Value;
           


            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);


            con.Open();

            SqlCommand cmd = new SqlCommand("update salarybase set [degination]='" + DEGINATION + "',[md]='" + MD + "',[pf]='" + PF + "',[hra]='" + HRA + "',[da]='" + DA + "',[other]='" + OTHER + "' " , con);


            int i = cmd.ExecuteNonQuery();


            if (i > 0)
            {

                msg.InnerHtml = "suceesfully submited";


            }

            else
            {

                msg.InnerHtml = "not suceesfully submited";


            }

        }
    }
}