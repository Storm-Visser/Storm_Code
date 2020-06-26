using System;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

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
        //haal het huidige weer op en zet het in de db(roep de functie aan)
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
                
                string today = LastUpdate.Day + "/" + LastUpdate.Month;
                double temp = output.main.temp;
                if(unit == "metric")
                {
                    insertData(temp, LastUpdate);
                }
                else if (unit == "imperial")
                {
                    insertData(((temp - 32) / 1.8), LastUpdate);
                }
                deleteData(LastUpdate);
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
                    Symbol = "°K";
                }
                chPastDays.Series["Average"].Points.Clear();
                chPastDays.ChartAreas["ChartArea1"].AxisY.Title = string.Format("Gem. temperatuur in {0}", Symbol);
                //voeg data toe aan db
                DateTime newdate = LastUpdate.AddDays(-5);
                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "weerstation";
                if (dbCon.IsConnect())
                {
                    int count = 0;
                    int total = 0;
                    for (int i = 1; i < 6; i++)
                    {
                        newdate = newdate.AddDays(1);
                        int Day = newdate.Day;
                        int Month = newdate.Month;
                        string query = string.Format("SELECT temp FROM afgelopendagen2  WHERE day={0} AND month={1} AND place='{2}'", Day, Month, cityName);
                        var cmd = new MySqlCommand(query, dbCon.Connection);
                        var reader = cmd.ExecuteReader();
                        count = 0;
                        total = 0;
                        while (reader.Read())
                        {
                            total += reader.GetInt32(0);
                            count++;
                        }
                        if (count == 0)
                        {
                            lblError.Text = "er is niet genoeg data beschikbaar voor alle dagen";
                        }
                        else
                        {
                            lblError.Text = "";
                            lblPastPlace.Text = string.Format("De afgelopen dagen in {0}", cityName);
                            double average = total / count;
                            if (unit == "imperial")
                            {
                                average = (average * 1.8) + 32;
                            }
                            chPastDays.Series["Average"].Points.AddXY(newdate.ToString("dd/MM"), average);
                        }
                        reader.Close();
                    }
                }

                //alles laten zien
                lblPlace.Text = string.Format("{0}, {1}", output.name, output.sys.country);
                lblTemp.Text = string.Format("Temperatuur: {0} {1}", temp, Symbol);
                lblHum.Text = string.Format("Luchtvochtigheid: {0} %",output.main.humidity);
                lblWind.Text = string.Format("Wind: {0} met {1} m/s", WindDir, output.wind.speed);
                lblUpdate.Text = string.Format("Laatst geupdate: {0}", LastUpdate);
                lblWeather.Text = string.Format("{0}", output.weather[0].description);
                var myImage = output.weather[0].icon;
                pbWeather.Image = (Image)Properties.Resources.ResourceManager.GetObject(myImage);
                timer1.Interval = interval * 1000;
                huidigeTemperatuurToolStripMenuItem.Text = string.Format("Temperatuur: {0} {1}", output.main.temp, Symbol);
            }
        }
        //haal de voorspelling op
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

                for (int i = 1; i < 9; i++)
                {
                    int toAdd = i * 3;
                    chForecast.Series["Average"].Points.AddXY(LastUpdate.AddHours(toAdd).ToString("dd/MM HH:mm"), forecast.list[i].main.temp);
                }
            }
        }
        //stop data in de database
        void insertData(double temp, DateTime today)
        {
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "weerstation";
            if (dbCon.IsConnect())
            {
                string query = string.Format("INSERT INTO afgelopendagen2 (id, temp, day, month, place) VALUES (NULL, '{0}', '{1}', '{2}', '{3}')", temp, today.Day, today.Month, cityName);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("check");
                }
                reader.Close();
            }
        } 
        //delete alle oude data uit de db
        void deleteData(DateTime date)
        {
            DateTime Date = date.AddDays(-5);
            int SmD = Date.Day;
            int SmM = Date.Month;
            Date = date.AddDays(-10);
            int LaD = Date.Day;
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "weerstation";
            if (dbCon.IsConnect())
            {
                string query = string.Format("DELETE FROM afgelopendagen2 WHERE day > {0} AND day < {1} AND month = {2}", LaD, SmD, SmM);
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("check");
                }
                reader.Close();
            }
        }
        public void StartForm()
        {
            Application.Run(new Form2());
        }
        //bottom right menu
        private void optiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            tabControl1.SelectedIndex = 3;
        }
        private void verversenToolStripMenuItem_Click(object sender, EventArgs e)
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
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Visible = true;
            tabControl1.SelectedIndex = 0;
        }
        //open de applicatie
        private void Weerstation_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
        }
        //onthoud de opties die geselecteerd zijn
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
        //om de zoveel seconden doe iets
        private void timer1_Tick(object sender, EventArgs e)
        {
            GetWeather(cityName);
        }
        //minimaliseer de applicatie
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // als je op X drukt sluit de applicatie maar hij blijft aan staan.
            e.Cancel = true;
            Visible = false;
        }
        //laat de uitgebreide grafiek zien
        private void btn5Days_Click(object sender, EventArgs e)
        {
            Form4 MeerDagen = new Form4();
            MeerDagen.GetForecast(cityName, unit);
            MeerDagen.ShowDialog();
        }
    }
}
