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
using System.IO;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace HRPAYROLL
{
    public partial class applyforleave : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Text1.Value = getempid();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {


            string HRID = empid.Value;
            string DEPART = name.Value;
            string FNAME = duration.Value;
            string LASNAME = fdate.Value;
            string EMAIL = ldate.Value;
            string MOBILE = reasion.Value;
            string LEAVE = Text1.Value;


            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("insert into applyleave values('" + HRID + "','" + DEPART + "','" + FNAME + "','" + LASNAME + "','" + EMAIL + "','" + MOBILE + "','pending','" + LEAVE + "')", con);
            int i = cmd.ExecuteNonQuery();

            if (i > 0)
            {

                msg.InnerHtml = "suceesfully applyeded";


            }

            else
            {

                msg.InnerHtml = "not suceesfully submited";


            }

        }
            public string getempid()
        {

            string id = "id00";

            string totalid = "";
            string stmt = "SELECT COUNT(*) FROM applyleave";
            int count = 0;

            SqlConnection con = new SqlConnection();

            con.ConnectionString = constr;
            {
                SqlCommand Count = new SqlCommand(stmt, con);
                {
                    con.Open();
                    count = (int)Count.ExecuteScalar();

                    con.Close();

                }
            }

            totalid = id + (Convert.ToString(count + 1));
            return totalid;
        
        }

        }  

    }
