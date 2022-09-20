
namespace Residence_Management_System.User_Controls
{
    partial class UC_report
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HScrollBar1 = new Guna.UI2.WinForms.Guna2HScrollBar();
            this.BarJobType = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2GroupBox2 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.occ = new System.Windows.Forms.Label();
            this.non_occ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.occupied = new System.Windows.Forms.Label();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            this.recessStatusPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HScrollBar2 = new Guna.UI2.WinForms.Guna2HScrollBar();
            this.guna2Panel1.SuspendLayout();
            this.BarJobType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.guna2GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recessStatusPieChart)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2HScrollBar1);
            this.guna2Panel1.Controls.Add(this.BarJobType);
            this.guna2Panel1.Location = new System.Drawing.Point(31, 192);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(501, 318);
            this.guna2Panel1.TabIndex = 16;
            // 
            // guna2HScrollBar1
            // 
            this.guna2HScrollBar1.InUpdate = false;
            this.guna2HScrollBar1.LargeChange = 11;
            this.guna2HScrollBar1.Location = new System.Drawing.Point(3, 382);
            this.guna2HScrollBar1.Maximum = 914;
            this.guna2HScrollBar1.Name = "guna2HScrollBar1";
            this.guna2HScrollBar1.ScrollbarSize = 18;
            this.guna2HScrollBar1.Size = new System.Drawing.Size(863, 18);
            this.guna2HScrollBar1.SmallChange = 5;
            this.guna2HScrollBar1.TabIndex = 10;
            // 
            // BarJobType
            // 
            this.BarJobType.AutoScroll = true;
            this.BarJobType.BackColor = System.Drawing.Color.Transparent;
            this.BarJobType.BorderColor = System.Drawing.Color.White;
            this.BarJobType.BorderRadius = 10;
            this.BarJobType.Controls.Add(this.chart1);
            this.BarJobType.CustomBorderColor = System.Drawing.Color.White;
            this.BarJobType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BarJobType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.BarJobType.Location = new System.Drawing.Point(3, 3);
            this.BarJobType.Name = "BarJobType";
            this.BarJobType.ShadowDecoration.BorderRadius = 10;
            this.BarJobType.ShadowDecoration.Enabled = true;
            this.BarJobType.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.BarJobType.Size = new System.Drawing.Size(488, 305);
            this.BarJobType.TabIndex = 7;
            this.BarJobType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BarJobType.Click += new System.EventHandler(this.BarJobType_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(19, 10);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "JobTitles";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(451, 267);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Employee Job Type";
            title1.Text = "Employee Job Type";
            this.chart1.Titles.Add(title1);
            // 
            // guna2GroupBox2
            // 
            this.guna2GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox2.BorderRadius = 10;
            this.guna2GroupBox2.Controls.Add(this.occ);
            this.guna2GroupBox2.Controls.Add(this.non_occ);
            this.guna2GroupBox2.Controls.Add(this.label1);
            this.guna2GroupBox2.Controls.Add(this.occupied);
            this.guna2GroupBox2.Controls.Add(this.iconPictureBox3);
            this.guna2GroupBox2.CustomBorderColor = System.Drawing.Color.White;
            this.guna2GroupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2GroupBox2.Location = new System.Drawing.Point(31, 21);
            this.guna2GroupBox2.Name = "guna2GroupBox2";
            this.guna2GroupBox2.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox2.ShadowDecoration.Enabled = true;
            this.guna2GroupBox2.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.guna2GroupBox2.Size = new System.Drawing.Size(264, 145);
            this.guna2GroupBox2.TabIndex = 18;
            this.guna2GroupBox2.Text = "Number of Room Status:";
            this.guna2GroupBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // occ
            // 
            this.occ.AutoSize = true;
            this.occ.Location = new System.Drawing.Point(115, 72);
            this.occ.Name = "occ";
            this.occ.Size = new System.Drawing.Size(40, 15);
            this.occ.TabIndex = 19;
            this.occ.Text = "label2";
            // 
            // non_occ
            // 
            this.non_occ.AutoSize = true;
            this.non_occ.Location = new System.Drawing.Point(115, 110);
            this.non_occ.Name = "non_occ";
            this.non_occ.Size = new System.Drawing.Size(40, 15);
            this.non_occ.TabIndex = 20;
            this.non_occ.Text = "label3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Free Rooms:";
            // 
            // occupied
            // 
            this.occupied.AutoSize = true;
            this.occupied.Location = new System.Drawing.Point(61, 72);
            this.occupied.Name = "occupied";
            this.occupied.Size = new System.Drawing.Size(48, 15);
            this.occupied.TabIndex = 3;
            this.occupied.Text = "Rooms:";
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Bed;
            this.iconPictureBox3.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 46;
            this.iconPictureBox3.Location = new System.Drawing.Point(3, 0);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(49, 46);
            this.iconPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox3.TabIndex = 2;
            this.iconPictureBox3.TabStop = false;
            // 
            // recessStatusPieChart
            // 
            chartArea2.Name = "ChartArea1";
            this.recessStatusPieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.recessStatusPieChart.Legends.Add(legend2);
            this.recessStatusPieChart.Location = new System.Drawing.Point(13, 13);
            this.recessStatusPieChart.Name = "recessStatusPieChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.recessStatusPieChart.Series.Add(series2);
            this.recessStatusPieChart.Size = new System.Drawing.Size(300, 295);
            this.recessStatusPieChart.TabIndex = 21;
            this.recessStatusPieChart.Text = "chart2";
            title2.Name = "PieChart";
            title2.Text = "Number of student  leaving, staying, not-sure during recess";
            this.recessStatusPieChart.Titles.Add(title2);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.AutoScroll = true;
            this.guna2GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.White;
            this.guna2GroupBox1.BorderRadius = 10;
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.White;
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.guna2GroupBox1.Location = new System.Drawing.Point(31, 516);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2GroupBox1.ShadowDecoration.Enabled = true;
            this.guna2GroupBox1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.guna2GroupBox1.Size = new System.Drawing.Size(832, 42);
            this.guna2GroupBox1.TabIndex = 7;
            this.guna2GroupBox1.Text = "Residence Management System - RMS";
            this.guna2GroupBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.guna2HScrollBar2);
            this.guna2Panel2.Controls.Add(this.recessStatusPieChart);
            this.guna2Panel2.Location = new System.Drawing.Point(538, 192);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(325, 318);
            this.guna2Panel2.TabIndex = 17;
            // 
            // guna2HScrollBar2
            // 
            this.guna2HScrollBar2.InUpdate = false;
            this.guna2HScrollBar2.LargeChange = 11;
            this.guna2HScrollBar2.Location = new System.Drawing.Point(3, 382);
            this.guna2HScrollBar2.Maximum = 914;
            this.guna2HScrollBar2.Name = "guna2HScrollBar2";
            this.guna2HScrollBar2.ScrollbarSize = 18;
            this.guna2HScrollBar2.Size = new System.Drawing.Size(863, 18);
            this.guna2HScrollBar2.SmallChange = 5;
            this.guna2HScrollBar2.TabIndex = 10;
            // 
            // UC_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.guna2GroupBox2);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_report";
            this.Size = new System.Drawing.Size(890, 569);
            this.Load += new System.EventHandler(this.UC_report_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.BarJobType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.guna2GroupBox2.ResumeLayout(false);
            this.guna2GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recessStatusPieChart)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HScrollBar guna2HScrollBar1;
        private Guna.UI2.WinForms.Guna2GroupBox BarJobType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox2;
        private System.Windows.Forms.Label occupied;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart recessStatusPieChart;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2HScrollBar guna2HScrollBar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label occ;
        private System.Windows.Forms.Label non_occ;
    }
}
