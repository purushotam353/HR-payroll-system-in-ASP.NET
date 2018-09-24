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
    public partial class editemp : System.Web.UI.Page
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
            string mailid = Session["empedit"].ToString();


            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);


            con.Open();
            SqlCommand cmd = new SqlCommand("select * from emp where [email id]= '" + mailid + "'", con);

            SqlDataReader sdr = cmd.ExecuteReader();


            while (sdr.Read())
            {


                hrid.Value = sdr["Employee Id"].ToString();
                depart.Value = sdr["name of depertment"].ToString();
                fname.Value = sdr["fname"].ToString();
                lasname.Value = sdr["lname"].ToString();
                email.Value = sdr["email id"].ToString();
                mobile.Value = sdr["mobile number"].ToString();
                degi.Value = sdr["degination"].ToString();
                salary.Value = sdr["salary"].ToString();
                join.Value = sdr["date of joining"].ToString();
                date.Value = sdr["date of birth"].ToString();
                RadioButtonList1.DataValueField = sdr["gender"].ToString();
            }






        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string HRID = hrid.Value;
            string DEPART = depart.Value;
            string FNAME = fname.Value;
            string LASNAME = lasname.Value;
            string EMAIL = email.Value;
            string MOBILE = mobile.Value;
            string DEGI = degi.Value;
            string SALARY = salary.Value;
            string JOIN = join.Value;
            string DATE = date.Value;
            string gender = RadioButtonList1.SelectedItem.ToString();


            string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);


            con.Open();

            SqlCommand cmd = new SqlCommand("update emp set [name of depertment]='" + DEPART + "',[fname]='" + FNAME + "',[lname]='" + LASNAME + "',[email id]='" + EMAIL + "',[mobile number]='" + MOBILE + "',[degination]='" + DEGI + "',[salary]='" + SALARY + "',[date of joining]='" + JOIN + "',[date of birth]='" + DATE + "',[gender]='" + gender + "'where [Employee Id]='" + HRID + "'  ", con);


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