
namespace Residence_Management_System.Reports
{
    partial class UC_RoomReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.roomReservationsTableAdapter1 = new Residence_Management_System.Reports.RoomsOccupiedDataSetTableAdapters.RoomReservationsTableAdapter();
            this.roomsOccupiedDataSet1 = new Residence_Management_System.Reports.RoomsOccupiedDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.roomsOccupiedDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Residence_Management_System.Reports.RoomsOccupiedReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(890, 569);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // roomReservationsTableAdapter1
            // 
            this.roomReservationsTableAdapter1.ClearBeforeFill = true;
            // 
            // roomsOccupiedDataSet1
            // 
            this.roomsOccupiedDataSet1.DataSetName = "RoomsOccupiedDataSet";
            this.roomsOccupiedDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // UC_RoomReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.reportViewer1);
            this.Name = "UC_RoomReport";
            this.Size = new System.Drawing.Size(890, 569);
            this.Load += new System.EventHandler(this.UC_RoomReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.roomsOccupiedDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private RoomsOccupiedDataSetTableAdapters.RoomReservationsTableAdapter roomReservationsTableAdapter1;
        private RoomsOccupiedDataSet roomsOccupiedDataSet1;
    }
}
