using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Chart
{
    public partial class Form1 : Form
    {
        /* Nieuwe grafiek aanmaken d.m.v.:
           1. Toolbox --> Chart slepen naar Designer.
           2. Chart aanklikken --> in Properties venster Series aanklikken en Collection openen. 
           3. In de Series Collection Editor evt. nieuwe grafieken toevoegen d.m.v. 'Add'.
         * 4. Eigen data en extra info. toevoegen zoals Labels e.d.
        */
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rdn = new Random();
            for (int i = 0; i < 50; i++)
            {
                chart1.Series["test1"].Points.AddXY(rdn.Next(0, 10), rdn.Next(0, 10));
                chart1.Series["test2"].Points.AddXY(rdn.Next(0, 10), rdn.Next(0, 10));
                
            }
            //chart1.Series["test1"].Points.AddXY(1, 2);
            //chart1.Series["test1"].Points.AddXY(3, 4);
            //chart1.Series["test2"].Points.AddXY(3, 4);
            //chart1.Series["test2"].Points.AddXY(5, 6);

            chart1.Series["test1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["test1"].Color = Color.Red;

            chart1.Series["test2"].ChartType = SeriesChartType.FastLine;
            chart1.Series["test2"].Color = Color.Blue;

            //chart1.Series["test1"].Points[0].AxisLabel = "First Point";
        }
    }
}
