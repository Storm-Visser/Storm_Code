using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Resources;


namespace EindopdrachtWeer
{
    public partial class Form1 : Form
    {
        int interval = 60;
        string cityName = "Veenoord";
        
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(2000);
            InitializeComponent();
            GetWeather(cityName);
            this.TopMost = true;
            WindowState = FormWindowState.Normal;
            Visible = true;
            timer1.Interval = interval * 1000;
            txtInterval.Text = string.Format("{0}", interval);
            txtPlace.Text = string.Format("{0}", cityName);
            t.Abort();
        }
        void GetWeather(string city)
        {
            using (WebClient web = new WebClient())
            {
                string Url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&appid=379ed7569bbd526bc8cd08d144c26fd7&units=metric&cnt=6", city);
                var JSon = web.DownloadString(Url);
                var Result = JsonConvert.DeserializeObject<WeerInfo.Root>(JSon);
                WeerInfo.Root output = Result;
                string WindDir = WindCalc.GetWindDirection(output.wind.deg);
                DateTime LastUpdate = DateTime.Now;
                double Temp = 0.0;
                string Symbol = "";
                if (rbC.Checked == true)
                {
                    Temp = output.main.temp;
                    Symbol = "°C";
                }
                else if(rbF.Checked == true)
                {
                    Temp = output.main.temp * 1.8 + 32;
                    Symbol = "°F";
                }
                else
                {
                    Temp = 404;
                    Symbol = "Error";
                }

                lblPlace.Text = string.Format("{0}, {1}", output.name, output.sys.country);
                lblTemp.Text = string.Format("Temperatuur: {0} {1}", Temp, Symbol);
                lblHum.Text = string.Format("Luchtvochtigheid: {0} %",output.main.humidity);
                lblWind.Text = string.Format("Wind: {0} met {1} Km/H", WindDir, output.wind.speed);
                lblUpdate.Text = string.Format("Laatst geupdate: {0}", LastUpdate);
                lblWeather.Text = string.Format("{0}", output.weather[0].description);
                var myImage = output.weather[0].icon;
                pbWeather.Image = (Image)Properties.Resources.ResourceManager.GetObject(myImage);
                timer1.Interval = interval * 1000;
                huidigeTemperatuurToolStripMenuItem.Text = string.Format("Temperatuur: {0} {1}", Temp, Symbol);
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
            //Weerstation.Visible = true;
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
            GetWeather(cityName);
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
    }
}
