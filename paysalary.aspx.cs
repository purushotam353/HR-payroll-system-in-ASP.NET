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
    public partial class paysalary : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {


            if(!IsPostBack)
            {

                addempid();
            }

        }


        protected void addempid()
        {

            SqlConnection con = new SqlConnection(constr);
            con.Open();

              SqlCommand cmd = new SqlCommand("select *from emp", con);

            SqlDataReader sdr = cmd.ExecuteReader();
            while(sdr.Read())
            {



                DropDownList1.Items.Add(sdr["Employee Id"].ToString());

            }

        }

        protected void lgadmin_Click(object sender, EventArgs e)
        {

            Session["payid"] = DropDownList1.SelectedItem.ToString();

            Response.Redirect("paysalary2.aspx");

        }


    }
}