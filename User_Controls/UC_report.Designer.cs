
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
            this.btnGenerateRoomReport = new Guna.UI2.WinForms.Guna2Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cboxRoomAvailability = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label24 = new System.Windows.Forms.Label();
            this.dtpDateMovingIn = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2DateTimePicker1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HScrollBar1 = new Guna.UI2.WinForms.Guna2HScrollBar();
            this.BarJobType = new Guna.UI2.WinForms.Guna2GroupBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.recessStatusPieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.guna2Panel2.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.BarJobType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recessStatusPieChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerateRoomReport
            // 
            this.btnGenerateRoomReport.Animated = true;
            this.btnGenerateRoomReport.BorderRadius = 10;
            this.btnGenerateRoomReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateRoomReport.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerateRoomReport.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGenerateRoomReport.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGenerateRoomReport.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGenerateRoomReport.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnGenerateRoomReport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGenerateRoomReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateRoomReport.Location = new System.Drawing.Point(734, 72);
            this.btnGenerateRoomReport.Name = "btnGenerateRoomReport";
            this.btnGenerateRoomReport.Size = new System.Drawing.Size(110, 33);
            this.btnGenerateRoomReport.TabIndex = 191;
            this.btnGenerateRoomReport.Text = "Load";
            this.btnGenerateRoomReport.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.label13.Location = new System.Drawing.Point(472, 44);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(99, 13);
            this.label13.TabIndex = 193;
            this.label13.Text = "Room Availability";
            // 
            // cboxRoomAvailability
            // 
            this.cboxRoomAvailability.BackColor = System.Drawing.Color.Transparent;
            this.cboxRoomAvailability.BorderRadius = 5;
            this.cboxRoomAvailability.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboxRoomAvailability.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxRoomAvailability.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxRoomAvailability.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboxRoomAvailability.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboxRoomAvailability.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboxRoomAvailability.ItemHeight = 30;
            this.cboxRoomAvailability.Items.AddRange(new object[] {
            "Available",
            "Not-Available",
            "Both"});
            this.cboxRoomAvailability.Location = new System.Drawing.Point(475, 60);
            this.cboxRoomAvailability.Name = "cboxRoomAvailability";
            this.cboxRoomAvailability.Size = new System.Drawing.Size(200, 36);
            this.cboxRoomAvailability.TabIndex = 194;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.label24.Location = new System.Drawing.Point(241, 46);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(48, 13);
            this.label24.TabIndex = 196;
            this.label24.Text = "Date to:";
            // 
            // dtpDateMovingIn
            // 
            this.dtpDateMovingIn.Animated = true;
            this.dtpDateMovingIn.BorderRadius = 5;
            this.dtpDateMovingIn.Checked = true;
            this.dtpDateMovingIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtpDateMovingIn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.dtpDateMovingIn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDateMovingIn.ForeColor = System.Drawing.Color.White;
            this.dtpDateMovingIn.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDateMovingIn.Location = new System.Drawing.Point(244, 60);
            this.dtpDateMovingIn.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDateMovingIn.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDateMovingIn.Name = "dtpDateMovingIn";
            this.dtpDateMovingIn.Size = new System.Drawing.Size(200, 36);
            this.dtpDateMovingIn.TabIndex = 195;
            this.dtpDateMovingIn.Value = new System.DateTime(2022, 9, 2, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(9, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 198;
            this.label4.Text = "Date From:";
            // 
            // guna2DateTimePicker1
            // 
            this.guna2DateTimePicker1.Animated = true;
            this.guna2DateTimePicker1.BorderRadius = 5;
            this.guna2DateTimePicker1.Checked = true;
            this.guna2DateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2DateTimePicker1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.guna2DateTimePicker1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2DateTimePicker1.ForeColor = System.Drawing.Color.White;
            this.guna2DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.guna2DateTimePicker1.Location = new System.Drawing.Point(12, 60);
            this.guna2DateTimePicker1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.guna2DateTimePicker1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.guna2DateTimePicker1.Name = "guna2DateTimePicker1";
            this.guna2DateTimePicker1.Size = new System.Drawing.Size(200, 36);
            this.guna2DateTimePicker1.TabIndex = 197;
            this.guna2DateTimePicker1.Value = new System.DateTime(2022, 9, 2, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(286, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 25);
            this.label6.TabIndex = 192;
            this.label6.Text = "Room Availability Report";
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.label6);
            this.guna2Panel2.Controls.Add(this.guna2DateTimePicker1);
            this.guna2Panel2.Controls.Add(this.btnGenerateRoomReport);
            this.guna2Panel2.Controls.Add(this.dtpDateMovingIn);
            this.guna2Panel2.Controls.Add(this.label13);
            this.guna2Panel2.Controls.Add(this.label4);
            this.guna2Panel2.Controls.Add(this.cboxRoomAvailability);
            this.guna2Panel2.Controls.Add(this.label24);
            this.guna2Panel2.Location = new System.Drawing.Point(23, 112);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(847, 108);
            this.guna2Panel2.TabIndex = 14;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.guna2HScrollBar1);
            this.guna2Panel1.Controls.Add(this.BarJobType);
            this.guna2Panel1.Location = new System.Drawing.Point(346, 236);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(524, 317);
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
            this.BarJobType.BorderRadius = 10;
            this.BarJobType.Controls.Add(this.chart1);
            this.BarJobType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BarJobType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.BarJobType.Location = new System.Drawing.Point(17, 3);
            this.BarJobType.Name = "BarJobType";
            this.BarJobType.ShadowDecoration.BorderRadius = 10;
            this.BarJobType.ShadowDecoration.Enabled = true;
            this.BarJobType.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.BarJobType.Size = new System.Drawing.Size(488, 305);
            this.BarJobType.TabIndex = 7;
            this.BarJobType.Text = "Employee Job Type";
            this.BarJobType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BarJobType.Click += new System.EventHandler(this.BarJobType_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(20, 53);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "JobTitles";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(451, 224);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            title1.Name = "Employee Job Type";
            this.chart1.Titles.Add(title1);
            // 
            // recessStatusPieChart
            // 
            chartArea2.Name = "ChartArea1";
            this.recessStatusPieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.recessStatusPieChart.Legends.Add(legend2);
            this.recessStatusPieChart.Location = new System.Drawing.Point(23, 239);
            this.recessStatusPieChart.Name = "recessStatusPieChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.recessStatusPieChart.Series.Add(series2);
            this.recessStatusPieChart.Size = new System.Drawing.Size(300, 300);
            this.recessStatusPieChart.TabIndex = 17;
            this.recessStatusPieChart.Text = "chart2";
            // 
            // UC_report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.recessStatusPieChart);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel2);
            this.Name = "UC_report";
            this.Size = new System.Drawing.Size(890, 569);
            this.Load += new System.EventHandler(this.UC_report_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.BarJobType.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recessStatusPieChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2ComboBox cboxRoomAvailability;
        private System.Windows.Forms.Label label24;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDateMovingIn;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2DateTimePicker guna2DateTimePicker1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2HScrollBar guna2HScrollBar1;
        private Guna.UI2.WinForms.Guna2GroupBox BarJobType;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart recessStatusPieChart;
        public Guna.UI2.WinForms.Guna2Button btnGenerateRoomReport;
    }
}
