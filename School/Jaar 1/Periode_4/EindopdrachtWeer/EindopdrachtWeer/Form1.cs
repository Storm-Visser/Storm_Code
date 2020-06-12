using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EindopdrachtWeer
{
    public partial class Form1 : Form
    {
    int interval = 60;
    string cityName = "Veenoord";
    string unit = "metric";
    public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(2000);
            InitializeComponent();
            GetWeather(cityName);
            GetForecast(cityName);
            timer1.Interval = interval * 1000;
            txtInterval.Text = string.Format("{0}", interval);
            txtPlace.Text = string.Format("{0}", cityName);
            t.Abort();
        }
        void GetWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                string Url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=379ed7569bbd526bc8cd08d144c26fd7&units={1}&cnt=6&lang=nl", city, unit);
                var JSon = web.DownloadString(Url);
                var Result = JsonConvert.DeserializeObject<WeerInfo.Root>(JSon);
                WeerInfo.Root output = Result;
                string WindDir = WindCalc.GetWindDirection(output.wind.deg);
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
                    Symbol = "Koeien";
                }

                lblPlace.Text = string.Format("{0}, {1}", output.name, output.sys.country);
                lblTemp.Text = string.Format("Temperatuur: {0} {1}", output.main.temp, Symbol);
                lblHum.Text = string.Format("Luchtvochtigheid: {0} %",output.main.humidity);
                lblWind.Text = string.Format("Wind: {0} met {1} Km/H", WindDir, output.wind.speed);
                lblUpdate.Text = string.Format("Laatst geupdate: {0}", LastUpdate);
                lblWeather.Text = string.Format("{0}", output.weather[0].description);
                var myImage = output.weather[0].icon;
                pbWeather.Image = (Image)Properties.Resources.ResourceManager.GetObject(myImage);
                timer1.Interval = interval * 1000;
                huidigeTemperatuurToolStripMenuItem.Text = string.Format("Temperatuur: {0} {1}", output.main.temp, Symbol);
            }
        }
        void GetForecast(string city)
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
                    Symbol = "Koeien";
                }

                chForecast.Series["Average"].Points.Clear();
                chForecast.ChartAreas["ChartArea1"].AxisY.Title = string.Format("Temperatuur in {0}", Symbol);
                chForecast.Series["Average"].Points.AddXY(LastUpdate.ToString("dd/MM HH:mm"), forecast.list[0].main.temp);

                for (int i = 1; i < 5; i++)
                {
                    int toAdd = i * 24;
                    chForecast.Series["Average"].Points.AddXY(LastUpdate.AddHours(toAdd).ToString("dd/MM HH:mm"), forecast.list[i * 8].main.temp);
                }
            }
        }
        public void StartForm()
        {
            Application.Run(new Form2());
        }
        private void optiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            tabControl1.SelectedIndex = 2;
        }

        private void Weerstation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }

        private void verversenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetWeather(cityName);
        }
        private void btnOpties_Click(object sender, EventArgs e)
        {
            cityName = txtPlace.Text;
            interval = int.Parse(txtInterval.Text);
            if (rbF.Checked == true)
            {
                unit = "imperial";
            }
            else
            {
                unit = "metric";
            }
            GetWeather(cityName);
            GetForecast(cityName);
            tabControl1.SelectedIndex = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetWeather(cityName);
        }

        private void overToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 about = new Form3();
            about.ShowDialog();
        }

        private void sluitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // als je op X drukt sluit de applicatie maar hij blijft aan staan.
            e.Cancel = true;
            Visible = false;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            tabControl1.SelectedIndex = 0;
        }
        DateTime GetDate(double milliseconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            day = day.AddSeconds(milliseconds);
            return day;
        }

        private void btn5Days_Click(object sender, EventArgs e)
        {
            Form4 MeerDagen = new Form4();
            MeerDagen.GetForecast(cityName, unit);
            MeerDagen.ShowDialog();
        }
    }
}
