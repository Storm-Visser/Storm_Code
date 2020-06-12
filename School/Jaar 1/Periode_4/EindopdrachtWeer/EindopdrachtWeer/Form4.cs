using System;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace EindopdrachtWeer
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            //string unit = Form1.GetUnit();
        }
        public void GetForecast(string city, string unit)
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&units={1}&appid=379ed7569bbd526bc8cd08d144c26fd7", city, unit);
                var json = web.DownloadString(url);
                var Object = JsonConvert.DeserializeObject<Forecast>(json);
                Forecast forecast = Object;
                DateTime LastUpdate = DateTime.Now;

                string Symbol = "";
                if (unit == "metric")
                {
                    Symbol = "°C";
                }
                else if (unit == "imperial")
                {
                    Symbol = "°F";
                }
                else
                {
                    Symbol = "K";
                }

                chForecastDays.Series["Temperature"].Points.Clear();
                chForecastDays.ChartAreas["ChartArea1"].AxisY.Title = string.Format("Temperatuur in {0}", Symbol);
                chForecastDays.Series["Temperature"].Points.AddXY(LastUpdate.ToString("dd/MM HH:mm"), forecast.list[0].main.temp);
                /*chForecastDays.Series["Min"].Points.AddXY(LastUpdate.ToString("MM/dd HH:mm"), forecast.list[0].main.temp_min);
                chForecastDays.Series["Max"].Points.AddXY(LastUpdate.ToString("MM/dd HH:mm"), forecast.list[0].main.temp_max);*/
                for (int i = 1; i < 40; i++)
                {
                    int toAdd = i * 3;
                    chForecastDays.Series["Temperature"].Points.AddXY(LastUpdate.AddHours(toAdd).ToString("dd/MM HH:mm"), forecast.list[i].main.temp);
                    /*chForecastDays.Series["Min"].Points.AddXY(LastUpdate.AddHours(toAdd).ToString("MM/dd HH:mm"), forecast.list[i].main.temp_min);
                    chForecastDays.Series["Max"].Points.AddXY(LastUpdate.AddHours(toAdd).ToString("MM/dd HH:mm"), forecast.list[i].main.temp_max);*/
                }
            }
        }
    }
}
