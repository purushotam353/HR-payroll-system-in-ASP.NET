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
    public partial class ademp : System.Web.UI.Page
    {
        string pass = "";
        string loginid = "";
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {

                hrid.Value = getempid();


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




            if (FileUpload1.HasFile)
            {
                string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                if (fileName.EndsWith("JPG") || fileName.EndsWith("jpg") || fileName.EndsWith("gif") || fileName.EndsWith("png"))
                {

                    fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/profile pic/employee profile/") + fileName);



                    if (HRID != "" && DEPART != "")
                    {


                        SqlConnection con = new SqlConnection(constr);
                        con.Open();


                        if (chkmail() == 0)
                        {


                            pass = getpass(6);
                            loginid = getid();

                            SqlCommand cmd = new SqlCommand("insert into emp values('" + HRID + "','" + DEPART + "','" + FNAME + "','" + LASNAME + "','" + EMAIL + "','" + MOBILE + "','" + DEGI + "','" + SALARY + "','" + JOIN + "','" + DATE + "','" + gender + "','" + fileName + "')", con);
                            SqlCommand cmd1 = new SqlCommand("insert into login values ('" + getid() + "','" + getpass(6) + "','emplogin')", con);





                            if (sendmail() == 0)
                            {
                                Response.Redirect("error.aspx");


                            }
                            int i = cmd.ExecuteNonQuery();

                            int j = cmd1.ExecuteNonQuery();
                            if (i > 0)
                            {

                                msg.InnerHtml = "suceesfully submited";


                            }

                            else
                            {

                                msg.InnerHtml = "not suceesfully submited";


                            }

                        }
                        else
                        {


                            msg.InnerHtml = "email already exist";
                            msg.Visible = true;


                        }
                    }



                    else
                    {


                        msg.InnerHtml = "fill all fileld";
                        msg.Visible = true;


                    }
                }
                else
                {


                    msg.InnerHtml = "invlaid image";
                    msg.Visible = true;
                }
            }
        }

        public int chkmail()
        {


            SqlConnection con = new SqlConnection(constr);
            con.Open();



            SqlCommand cmd = new SqlCommand("select count(* ) from  emp where [email id ] ='" + email.Value + "'", con);


            int s =   Convert.ToInt16(  cmd.ExecuteScalar().ToString());

            if (s>0)
            {


                return 1;
            }


            else 
            {

                return 0;
            }
        }


        //email send
        public int sendmail()
        {
            try
            {

                string strHTMLMsg = "";


                strHTMLMsg = strHTMLMsg + "welcome to organization '" + fname.Value + "' : <BR/>";
                strHTMLMsg = strHTMLMsg + "          your employeess id  : " + hrid.Value + "<BR/>";
                strHTMLMsg = strHTMLMsg + "          login id is : " + loginid + "<BR/>";
                strHTMLMsg = strHTMLMsg + "        password is: " + pass + "<BR/>";
                strHTMLMsg = strHTMLMsg + "     please use your login id and password to login";

                string fromaddr = "iskylarak@gmail.com";
                string toaddr = email.Value;//TO ADDRESS HERE
                string password = "anshikaak1417";


                MailMessage msg = new MailMessage();
                msg.Subject = "Username &password";
                msg.From = new MailAddress(fromaddr);
                msg.Body = strHTMLMsg;
                msg.IsBodyHtml = true;
                msg.To.Add(new MailAddress(email.Value));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential(fromaddr, password);
                smtp.Credentials = nc;
                smtp.Send(msg);

            }
            catch (Exception ex)
            {


                Session["mailerr"] = ex.Message;
                Session["slipsend"] = email.Value;


                Response.Redirect("error.aspx");

                return 0;


            }

            return 1;

        }

        public string getpass(int length)
        {

            const string valid = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();


        }

        public string getid()
        {

            return hrid.Value;
        }


        public string getempid()
        {

            string id = "emp00";

            string totalid = "";
            string stmt = "SELECT COUNT(*) FROM emp";
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


        
    


