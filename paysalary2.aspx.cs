using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace HRPAYROLL
{
    public partial class paysalary2 : System.Web.UI.Page
    {
        public Double MD;

        public Double PF;
        public Double HRA;
        public Double LIC;
        public Double DA;
        public Double OTHER;


       string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
       Dataclass c = new Dataclass();

    
        protected void Page_Load(object sender, EventArgs e)
        {
            string empid = Session["payid"].ToString();
            Button1.Enabled = false;
            if(!IsPostBack)
            {

            
                getdeatail();

                Panel1.Visible = false;
            }



        }


         protected void getdeatail()
        {


           
            string empid = Session["payid"].ToString();

         


            SqlConnection con = new SqlConnection(constr);
            con.Open();

            SqlCommand cmd = new SqlCommand("select *from emp where [Employee Id]='"+empid+"'  ", con);

            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
       
                Label.Text = sdr["fname"].ToString();

                Label2.Text = sdr["Employee Id"].ToString();
                Label4.Text = sdr["salary"].ToString();
                Session["sal"] =    Convert.ToDouble( sdr["salary"]);
                Session["sendslip"] = sdr["email id"].ToString();
                Session["deg"] = sdr["degination"].ToString();
                Label3.Text = sdr["degination"].ToString();


            }


        }

         protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
         {


             try
             {

                 string empid = Session["payid"].ToString();
                 string month = DropDownList3.SelectedValue.ToString();

                 int m = 0;
                 if (month == "January")
                 {

                     m = 1;


                 }
                 else if (month == "Faburay")
                 {


                     m = 2;

                 }

                 else if (month == "March")
                 {


                     m = 3;

                 }

                 else if (month == "April")
                 {


                     m = 4;

                 }
                 else if (month == "May")
                 {


                     m = 5;

                 }

                 else if (month == "Jun")
                 {


                     m = 6;

                 }
                 else if (month == "July")
                 {


                     m = 7;

                 }
                 else if (month == "August")
                 {


                     m = 8;

                 }
                 else if (month == "September")
                 {


                     m = 9;

                 }

                 else if (month == "October")
                 {


                     m = 10;

                 }

                 else if (month == "November")
                 {


                     m = 11;

                 }

                 else if (month == "December")
                 {


                     m = 12;

                 }




                 int currentYear = DateTime.Now.Year;




                 string fromdate = currentYear + "-" + m + "-01";

                 int days = DateTime.DaysInMonth(currentYear, m);
                  
                 string todate = currentYear + "-" + m + "-" + days;


                 //First We find out last date of mont
                 //DateTime today = (DateTime)fromdate;
                 //DateTime endOfMonth = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));
                 //get only last day of month
                 //int day = endOfMonth.Day;

                 //DateTime now = DateTime.Now;
                 //int count;
                 //count = 0;
                 //for (int i = 0; i < day; ++i)
                 //{
                 //    DateTime d = new DateTime(now.Year, now.Month, i + 1);
                 //    Compare date with sunday
                 //    if (d.DayOfWeek == DayOfWeek.Sunday)
                 //    {
                 //        count = count + 1;
                 //    }
                 //}


                 SqlConnection con = new SqlConnection(constr);
                 con.Open();


                 SqlCommand cmd = new SqlCommand("select count(*) from attend   where  empid='" + empid + "'  and timedate between '" + fromdate + "' and  '" + todate + "'", con);



                 SqlCommand cm3 = new SqlCommand("select count(*) from attend   where  empid='" + empid + "'  and timedate between '" + fromdate + "' and  '" + todate + "' and status='f' ", con);

                 int fullday = (int)cm3.ExecuteScalar();

                 SqlCommand cm4 = new SqlCommand("select count(*) from attend   where  empid='" + empid + "'  and timedate between '" + fromdate + "' and  '" + todate + "' and status='H' ", con);

                 int halday = (int)cm4.ExecuteScalar();


                 string totalattn = cmd.ExecuteScalar().ToString();

                 SqlCommand cmd3 = new SqlCommand("select [First date of leave]  from applyleave where [Employee Id]='" + empid + "'", con);

                 DateTime leavdate = (DateTime)cmd3.ExecuteScalar();

                 string[] dt = leavdate.ToString().Split(' ');




                 SqlCommand cmd1 = new SqlCommand(" select * from  applyleave  where [Employee Id]='" + empid + "'", con);

                 SqlDataReader sdr = cmd1.ExecuteReader();


                 int leavdays = 0;


                 while (sdr.Read())
                 {

                     int lv = (int)sdr["Duration of Leave"];


                     leavdays = (int)lv;


                     leavdays = (int)sdr["Duration of Leave"] + leavdays;


                 }


                 string salary = Label4.Text.ToString();

                 lblfd.Text = fullday.ToString();
                 lblhf.Text = halday.ToString();
                 lblbs.Text =   Session["sal"].ToString();
               
                  Session["FD"]=fullday;

                      Session["HD"]=halday;

                          Session["LV"]=leavdays;

                          Session["DIM"] = days;

                 Panel1.Visible = true;


             }

             catch
             {

                 Session["hrerr"] = "data not found";
                 Response.Redirect("hrerror.aspx");

             }

         }


       protected void caluculatesal( int fullDay,int halfDay,int leave  ,Double SALARY,int dayinMonth,string designation)
           
       {


           Double md = 0;
           Double pf = 0;
           Double lic = 0;
           Double da = 0;
           Double hra = 0;
           Double other = 0;

           SqlConnection con = new SqlConnection(constr);
           con.Open();

           SqlCommand cmd = new SqlCommand("select * from salarybase where degination='" + designation + "'  ", con);

           SqlDataReader sdr = cmd.ExecuteReader();

           while(sdr.Read())
           {


               md = Convert.ToDouble(sdr["md"]);
               pf =  Convert.ToDouble(sdr["pf"]);
               lic = Convert.ToDouble(sdr["lic"]);
               da = Convert.ToDouble(sdr["da"]);
               other = Convert.ToDouble(sdr["other"]);
           hra    = Convert.ToDouble(sdr["hra"]);
              

           }

 
         Double finalSal = 0;


       

           int extralv=0;
           extralv =((int) Session["DIM"]) - (fullDay + halfDay + leave);
           float perdaysa = (float)SALARY / 30;

           float basicSal = (fullDay * perdaysa) + ((halfDay * perdaysa) / 2) + (leave * perdaysa) + (4 * perdaysa);

           if(chkmd.Checked==true)
           {
              
               
               MD= SALARY*(md / 100);
               finalSal = finalSal - MD;
               md1.Text = MD.ToString();
           }
            if(chkpf.Checked==true)
           {

               finalSal = finalSal - ((float)SALARY * (pf / 100));
               PF = SALARY * (pf / 100);
               pf1.Text = PF.ToString();

           }
          if (chklic.Checked == true)
           {

              LIC = SALARY * (lic / 100);
               finalSal = finalSal - ((float)SALARY * (lic / 100));
               lic1.Text =LIC.ToString();
           }
          if (chkha.Checked == true)
           {


              HRA=SALARY * (hra / 100);
               finalSal = finalSal + ((float)SALARY * (hra / 100));
               hra1.Text = HRA.ToString();
           }

          
            if (chkda.Checked == true)
           {

               DA=(float)SALARY * (da / 100);
               finalSal = finalSal + ((float)SALARY * (da / 100));
               da1.Text = DA.ToString();
           }

            if (chkothr.Checked == true)
            {

                OTHER=SALARY * (other / 100);
                finalSal = finalSal + ((float)SALARY * (other / 100));
                other1.Text = OTHER.ToString();
            }


            finalSal = finalSal + basicSal;
            int a = Convert.ToInt32(finalSal);
           txtsal.Text = a.ToString();
           

       }

       protected void Button2_Click(object sender, EventArgs e)
       {
           Button1.Enabled = true;


           caluculatesal((int)Session["FD"], (int)Session["HD"], (int)Session["LV"], (Double)Session["sal"], (int)Session["DIM"], Session["deg"].ToString());


       }

       protected void Button1_Click(object sender, EventArgs e)
       {


           if (checkpaid() == 0)
           {

               string EMPNAME = Label.Text;
               string EMPID = Label2.Text;
               string EMPGRADE = Label3.Text;
               string TOTALSALARY = Label4.Text;
               string MONTH = DropDownList3.SelectedValue;
               string TOTALFULLDAY = lblfd.Text;
               string TOTALHAFDAY = lblhf.Text;
               string BASICSALARY = lblbs.Text;
               string MD = md1.Text;
               string PF = pf1.Text;
               string LIC = lic1.Text;
               string HRA = hra1.Text;
               string DA= da1.Text;
               string OTHER= other1.Text;
              

               string FINALSALARY = txtsal.Text;

               SqlConnection con = new SqlConnection(constr);
               con.Open();

               SqlCommand cmd = new SqlCommand("insert into paidsalary values('" + EMPNAME + "','" + EMPID + "','" + EMPGRADE + "','" + TOTALSALARY + "','" + MONTH + "','" + TOTALFULLDAY + "','" + TOTALHAFDAY + "','" + BASICSALARY + "','" + MD + "','" + PF + "','" + LIC + "','" + HRA + "','" + DA + "','" + OTHER + "','" + FINALSALARY + "')", con);

               int i = cmd.ExecuteNonQuery();
               hora1.InnerHtml = "sucessfully paid ";

                if(sendmail()==1)
                {


                }

           }
           else
           {
               hora.InnerHtml = "alredy paid ";

           }


       }

       public int checkpaid()
       {


           SqlConnection con = new SqlConnection(constr);
           con.Open();



           SqlCommand cmd = new SqlCommand("select count(* ) from paidsalary  where [empid] ='" + Label2.Text + "' and [month] ='" + DropDownList3.Text + "'", con);


           int s = Convert.ToInt16(cmd.ExecuteScalar().ToString());

           if (s > 0)
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


               strHTMLMsg = strHTMLMsg + "YOU HAVE BEEN PAID FOR MONTH '" + DropDownList3.SelectedValue.ToString() +"' : <BR/>";
               strHTMLMsg = strHTMLMsg + "     HERE IS YOUR SALARY SLIP from purushottam singh ceo of company:<BR/>";
               strHTMLMsg = strHTMLMsg + "         Employee Name: " + Label.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "        Employee Id: " + Label2.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "         Employee Degination: " + Label3.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "        Total Salary: " + Label4.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "        YOUR DEDUCTION: <BR/>";
               strHTMLMsg = strHTMLMsg + "         Medical Deduction: " + md1.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "         PF Deduction: " + pf1.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "         LIC Deduction: " + lic1.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "         YOUR BENIFITS : <BR/>";
               strHTMLMsg = strHTMLMsg + "        HRA : " + hra1.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "        DA : " + da1.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "        OTHER : " + other1.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "        FINAL Salary: " + txtsal.Text + "<BR/>";
               strHTMLMsg = strHTMLMsg + "     THANK YOU";

               string fromaddr = "iskylarak@gmail.com";
               string toaddr = Session["sendslip"].ToString();//TO ADDRESS HERE
               string password = "anshikaak1417";


               MailMessage msg = new MailMessage();
               msg.Subject = "YOUR SALARY SLIP";
               msg.From = new MailAddress(fromaddr);
               msg.Body = strHTMLMsg;
               msg.IsBodyHtml = true;
               msg.To.Add(new MailAddress( Session["sendslip"].ToString()));
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



               Response.Redirect("error.aspx");

               return 0;


           }

           return 1;

       }

    }
    }
