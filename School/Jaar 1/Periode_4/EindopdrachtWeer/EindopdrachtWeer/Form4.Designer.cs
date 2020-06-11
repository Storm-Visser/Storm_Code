namespace EindopdrachtWeer
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.chForecastDays = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chForecastDays)).BeginInit();
            this.SuspendLayout();
            // 
            // chForecastDays
            // 
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Title = "Datum en tijd";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "Temperatuur";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this.chForecastDays.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chForecastDays.Legends.Add(legend1);
            this.chForecastDays.Location = new System.Drawing.Point(-74, 42);
            this.chForecastDays.Name = "chForecastDays";
            this.chForecastDays.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chForecastDays.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BorderColor = System.Drawing.Color.MediumOrchid;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Average";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Min";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Max";
            this.chForecastDays.Series.Add(series1);
            this.chForecastDays.Series.Add(series2);
            this.chForecastDays.Series.Add(series3);
            this.chForecastDays.Size = new System.Drawing.Size(2048, 289);
            this.chForecastDays.TabIndex = 5;
            this.chForecastDays.Text = "Voorspelling";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblName.Location = new System.Drawing.Point(12, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(334, 39);
            this.lblName.TabIndex = 6;
            this.lblName.Text = "Stenden Weerstation";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1902, 328);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.chForecastDays);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.Text = "Voorspelling 5 dagen";
            ((System.ComponentModel.ISupportInitialize)(this.chForecastDays)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.DataVisualization.Charting.Chart chForecastDays;
    }
}