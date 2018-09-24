using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRPAYROLL
{
    public partial class attendance : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;
        string time = DateTime.Now.ToLongTimeString();
        protected void Page_Load(object sender, EventArgs e)
        {

            date.InnerHtml = DateTime.Now.ToString();

            GetWeatherInfo();

            if(!IsPostBack)
            {


                btn.Enabled = false;
                btnstatus();
            }

           

        }
         //get  wether
        protected void GetWeatherInfo()
        {
            string appId = "4422abbde9f18d91a17bf126c3ef2153";
            string url = string.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=1&APPID={1}", "jaipur", appId);
            using (WebClient client = new WebClient())
            {


                string json = client.DownloadString(url);

                WeatherInfo weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherInfo>(json);
                lblCity_Country.Text = weatherInfo.city.name + "," + weatherInfo.city.country;
                imgCountryFlag.ImageUrl = string.Format("http://openweathermap.org/images/flags/{0}.png", weatherInfo.city.country.ToLower());
                lblDescription.Text = weatherInfo.list[0].weather[0].description;
                imgWeatherIcon.ImageUrl = string.Format("http://openweathermap.org/img/w/{0}.png", weatherInfo.list[0].weather[0].icon);
                lblTempMin.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.min, 1));
                lblTempMax.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.max, 1));
                lblTempDay.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.day, 1));
                lblTempNight.Text = string.Format("{0}°С", Math.Round(weatherInfo.list[0].temp.night, 1));
                lblHumidity.Text = weatherInfo.list[0].humidity.ToString();
                tblWeather.Visible = true;

            }

        }
        protected void btnstatus()
        {

            string day = DateTime.Now.DayOfWeek.ToString();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
         
            string[] spilttime = time.Split(delimiterChars);
            int h = Convert.ToInt32(spilttime[0].ToString());
            string sloat = spilttime[3];




           if (((h >= 9 && h <= 11) && sloat == "AM") || (h == 12 && sloat == "PM") || (h <= 7 && sloat == "PM"))
            {
                btn.Enabled = true;
            }
          





        }

        protected void btn_Click(object sender, EventArgs e)
        {


            string day = DateTime.Now.DayOfWeek.ToString();
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string time = DateTime.Now.ToLongTimeString();
            string[] spilttime = time.Split(delimiterChars);
            int h = Convert.ToInt32(spilttime[0].ToString());
            string sloat = spilttime[3];

            DateTime today = DateTime.Today;
            string status = "";

            if(sloat=="AM")
            {
                status = "f";
                
            }
            else if(sloat=="PM")
            {

                status = "H";


            }

            string id = Session["empid"].ToString();
            string name = "";

            DateTime dt = DateTime.Now;

            string timedate = dt.ToString();
           


            SqlConnection con = new SqlConnection(constr);

            con.Open();

           SqlCommand   cmd1 = new SqlCommand("select Max(timedate) from attend where empid ='"+id+"'", con);
           
            string[] checkdate = cmd1.ExecuteScalar().ToString().Split(' ');

            string[] t = today.ToString().Split(' ');
            if (checkdate[0] != t[0])
            {

                SqlCommand cmd = new SqlCommand("select fname from emp where [Employee Id]='" + id + "'", con);
                name = cmd.ExecuteScalar().ToString();
                SqlCommand cmd2 = new SqlCommand("insert into attend values('" + name + "','" + id + "','" + timedate + "','" + status + "')", con);
                int i = cmd2.ExecuteNonQuery();


                if (i > 0)
                {

                    atend.Visible = true;
                    atend.InnerText = "Successfull today Attendance";
                }

            }
            else
            {

                atend.Visible = true;

                atend.InnerText = "already done Attendance !";

            }



        }




    }

}