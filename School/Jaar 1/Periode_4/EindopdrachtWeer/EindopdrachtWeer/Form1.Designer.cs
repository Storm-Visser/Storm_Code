namespace EindopdrachtWeer
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.pbWeather = new System.Windows.Forms.PictureBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.lblWind = new System.Windows.Forms.Label();
            this.lblHum = new System.Windows.Forms.Label();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblWeather = new System.Windows.Forms.Label();
            this.lblPlace = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn5Days = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.chForecast = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblName = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOpties = new System.Windows.Forms.Button();
            this.rbF = new System.Windows.Forms.RadioButton();
            this.rbC = new System.Windows.Forms.RadioButton();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Weerstation = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.huidigeTemperatuurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verversenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeather)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chForecast)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 333);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.pbWeather);
            this.tabPage1.Controls.Add(this.lblUpdate);
            this.tabPage1.Controls.Add(this.lblWind);
            this.tabPage1.Controls.Add(this.lblHum);
            this.tabPage1.Controls.Add(this.lblTemp);
            this.tabPage1.Controls.Add(this.lblWeather);
            this.tabPage1.Controls.Add(this.lblPlace);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(429, 304);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Actueel";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.MediumPurple;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(334, 39);
            this.label6.TabIndex = 8;
            this.label6.Text = "Stenden Weerstation";
            // 
            // pbWeather
            // 
            this.pbWeather.BackColor = System.Drawing.Color.White;
            this.pbWeather.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pbWeather.ErrorImage")));
            this.pbWeather.Image = global::EindopdrachtWeer.Properties.Resources.cat;
            this.pbWeather.ImageLocation = "";
            this.pbWeather.Location = new System.Drawing.Point(28, 49);
            this.pbWeather.Name = "pbWeather";
            this.pbWeather.Size = new System.Drawing.Size(80, 80);
            this.pbWeather.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWeather.TabIndex = 7;
            this.pbWeather.TabStop = false;
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdate.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblUpdate.Location = new System.Drawing.Point(249, 282);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(71, 12);
            this.lblUpdate.TabIndex = 6;
            this.lblUpdate.Text = "Laatst geupdate";
            // 
            // lblWind
            // 
            this.lblWind.AutoSize = true;
            this.lblWind.Location = new System.Drawing.Point(25, 251);
            this.lblWind.Name = "lblWind";
            this.lblWind.Size = new System.Drawing.Size(40, 17);
            this.lblWind.TabIndex = 5;
            this.lblWind.Text = "Wind";
            // 
            // lblHum
            // 
            this.lblHum.AutoSize = true;
            this.lblHum.Location = new System.Drawing.Point(25, 197);
            this.lblHum.Name = "lblHum";
            this.lblHum.Size = new System.Drawing.Size(107, 17);
            this.lblHum.TabIndex = 4;
            this.lblHum.Text = "Luctvochtigheid";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(25, 143);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(90, 17);
            this.lblTemp.TabIndex = 3;
            this.lblTemp.Text = "Temperatuur";
            // 
            // lblWeather
            // 
            this.lblWeather.AutoSize = true;
            this.lblWeather.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeather.Location = new System.Drawing.Point(105, 88);
            this.lblWeather.Name = "lblWeather";
            this.lblWeather.Size = new System.Drawing.Size(108, 29);
            this.lblWeather.TabIndex = 2;
            this.lblWeather.Text = "Weather";
            // 
            // lblPlace
            // 
            this.lblPlace.AutoSize = true;
            this.lblPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlace.Location = new System.Drawing.Point(103, 49);
            this.lblPlace.Name = "lblPlace";
            this.lblPlace.Size = new System.Drawing.Size(240, 39);
            this.lblPlace.TabIndex = 1;
            this.lblPlace.Text = "Place, Country";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn5Days);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.chForecast);
            this.tabPage2.Controls.Add(this.lblName);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 304);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Trend";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn5Days
            // 
            this.btn5Days.Location = new System.Drawing.Point(333, 28);
            this.btn5Days.Name = "btn5Days";
            this.btn5Days.Size = new System.Drawing.Size(75, 31);
            this.btn5Days.TabIndex = 6;
            this.btn5Days.Text = "5 Dagen";
            this.btn5Days.UseVisualStyleBackColor = true;
            this.btn5Days.Click += new System.EventHandler(this.btn5Days_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "24 uur vooruit";
            // 
            // chForecast
            // 
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.AxisX.IsStartedFromZero = false;
            chartArea1.AxisX.Title = "Datum en tijd";
            chartArea1.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.AxisY.Title = "Temperatuur";
            chartArea1.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea1.Name = "ChartArea1";
            this.chForecast.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chForecast.Legends.Add(legend1);
            this.chForecast.Location = new System.Drawing.Point(-4, 42);
            this.chForecast.Name = "chForecast";
            this.chForecast.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chForecast.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            series1.BorderColor = System.Drawing.Color.MediumOrchid;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "Average";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.LightSkyBlue;
            series2.Legend = "Legend1";
            series2.Name = "Rain";
            this.chForecast.Series.Add(series1);
            this.chForecast.Series.Add(series2);
            this.chForecast.Size = new System.Drawing.Size(430, 262);
            this.chForecast.TabIndex = 4;
            this.chForecast.Text = "Voorspelling";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.MediumPurple;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(334, 39);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Stenden Weerstation";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.btnOpties);
            this.tabPage3.Controls.Add(this.rbF);
            this.tabPage3.Controls.Add(this.rbC);
            this.tabPage3.Controls.Add(this.txtInterval);
            this.tabPage3.Controls.Add(this.txtPlace);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(429, 304);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Opties";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.MediumPurple;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(334, 39);
            this.label4.TabIndex = 9;
            this.label4.Text = "Stenden Weerstation";
            // 
            // btnOpties
            // 
            this.btnOpties.Location = new System.Drawing.Point(127, 232);
            this.btnOpties.Name = "btnOpties";
            this.btnOpties.Size = new System.Drawing.Size(49, 23);
            this.btnOpties.TabIndex = 8;
            this.btnOpties.Text = "Go";
            this.btnOpties.UseVisualStyleBackColor = true;
            this.btnOpties.Click += new System.EventHandler(this.btnOpties_Click);
            // 
            // rbF
            // 
            this.rbF.AutoSize = true;
            this.rbF.Location = new System.Drawing.Point(171, 180);
            this.rbF.Name = "rbF";
            this.rbF.Size = new System.Drawing.Size(43, 21);
            this.rbF.TabIndex = 6;
            this.rbF.Text = "°F";
            this.rbF.UseVisualStyleBackColor = true;
            // 
            // rbC
            // 
            this.rbC.AutoSize = true;
            this.rbC.Checked = true;
            this.rbC.Location = new System.Drawing.Point(127, 180);
            this.rbC.Name = "rbC";
            this.rbC.Size = new System.Drawing.Size(44, 21);
            this.rbC.TabIndex = 5;
            this.rbC.TabStop = true;
            this.rbC.Text = "°C";
            this.rbC.UseVisualStyleBackColor = true;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(127, 125);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(266, 22);
            this.txtInterval.TabIndex = 4;
            // 
            // txtPlace
            // 
            this.txtPlace.Location = new System.Drawing.Point(127, 76);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(266, 22);
            this.txtPlace.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Weergave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Interval";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plaats";
            // 
            // Weerstation
            // 
            this.Weerstation.ContextMenuStrip = this.contextMenuStrip1;
            this.Weerstation.Icon = ((System.Drawing.Icon)(resources.GetObject("Weerstation.Icon")));
            this.Weerstation.Text = "Weerstation";
            this.Weerstation.Visible = true;
            this.Weerstation.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Weerstation_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.huidigeTemperatuurToolStripMenuItem,
            this.overToolStripMenuItem,
            this.optiesToolStripMenuItem,
            this.verversenToolStripMenuItem,
            this.openToolStripMenuItem,
            this.sluitenToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 148);
            // 
            // huidigeTemperatuurToolStripMenuItem
            // 
            this.huidigeTemperatuurToolStripMenuItem.Name = "huidigeTemperatuurToolStripMenuItem";
            this.huidigeTemperatuurToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.huidigeTemperatuurToolStripMenuItem.Text = "Huidige temperatuur";
            // 
            // overToolStripMenuItem
            // 
            this.overToolStripMenuItem.Name = "overToolStripMenuItem";
            this.overToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.overToolStripMenuItem.Text = "Over";
            this.overToolStripMenuItem.Click += new System.EventHandler(this.overToolStripMenuItem_Click);
            // 
            // optiesToolStripMenuItem
            // 
            this.optiesToolStripMenuItem.Name = "optiesToolStripMenuItem";
            this.optiesToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.optiesToolStripMenuItem.Text = "Opties";
            this.optiesToolStripMenuItem.Click += new System.EventHandler(this.optiesToolStripMenuItem_Click);
            // 
            // verversenToolStripMenuItem
            // 
            this.verversenToolStripMenuItem.Name = "verversenToolStripMenuItem";
            this.verversenToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.verversenToolStripMenuItem.Text = "Verversen";
            this.verversenToolStripMenuItem.Click += new System.EventHandler(this.verversenToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // sluitenToolStripMenuItem
            // 
            this.sluitenToolStripMenuItem.Name = "sluitenToolStripMenuItem";
            this.sluitenToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.sluitenToolStripMenuItem.Text = "Sluiten";
            this.sluitenToolStripMenuItem.Click += new System.EventHandler(this.sluitenToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(432, 328);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stenden Weerstation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWeather)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chForecast)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblWeather;
        private System.Windows.Forms.Label lblPlace;
        private System.Windows.Forms.Label lblWind;
        private System.Windows.Forms.Label lblHum;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.NotifyIcon Weerstation;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem huidigeTemperatuurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verversenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sluitenToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbF;
        private System.Windows.Forms.RadioButton rbC;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpties;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbWeather;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chForecast;
        private System.Windows.Forms.Button btn5Days;
        private System.Windows.Forms.Label label5;
    }
}

