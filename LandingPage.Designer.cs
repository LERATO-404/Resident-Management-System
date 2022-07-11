
namespace Residence_Management_System
{
    partial class LandingPage
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
            this.sideBarContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.sideBarTimer = new System.Windows.Forms.Timer(this.components);
            this.tabsContainer = new System.Windows.Forms.Panel();
            this.LogoLandingPage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.menuBtn = new FontAwesome.Sharp.IconButton();
            this.homebtn = new FontAwesome.Sharp.IconButton();
            this.registerbtn = new FontAwesome.Sharp.IconButton();
            this.roombtn = new FontAwesome.Sharp.IconButton();
            this.activitiesbtn = new FontAwesome.Sharp.IconButton();
            this.reporbtn = new FontAwesome.Sharp.IconButton();
            this.sideBarContainer.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoLandingPage)).BeginInit();
            this.SuspendLayout();
            // 
            // sideBarContainer
            // 
            this.sideBarContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.sideBarContainer.Controls.Add(this.menuBtn);
            this.sideBarContainer.Controls.Add(this.homebtn);
            this.sideBarContainer.Controls.Add(this.registerbtn);
            this.sideBarContainer.Controls.Add(this.roombtn);
            this.sideBarContainer.Controls.Add(this.activitiesbtn);
            this.sideBarContainer.Controls.Add(this.reporbtn);
            this.sideBarContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.sideBarContainer.Location = new System.Drawing.Point(0, 0);
            this.sideBarContainer.MaximumSize = new System.Drawing.Size(195, 800);
            this.sideBarContainer.MinimumSize = new System.Drawing.Size(44, 800);
            this.sideBarContainer.Name = "sideBarContainer";
            this.sideBarContainer.Size = new System.Drawing.Size(44, 800);
            this.sideBarContainer.TabIndex = 0;
            this.sideBarContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelMenu_Paint);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panelLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panelLogo.Controls.Add(this.LogoLandingPage);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(44, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(890, 58);
            this.panelLogo.TabIndex = 1;
            this.panelLogo.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // sideBarTimer
            // 
            this.sideBarTimer.Interval = 10;
            this.sideBarTimer.Tick += new System.EventHandler(this.sideBarTimer_Tick);
            // 
            // tabsContainer
            // 
            this.tabsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsContainer.Location = new System.Drawing.Point(44, 58);
            this.tabsContainer.Name = "tabsContainer";
            this.tabsContainer.Size = new System.Drawing.Size(890, 569);
            this.tabsContainer.TabIndex = 6;
            // 
            // LogoLandingPage
            // 
            this.LogoLandingPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LogoLandingPage.Image = global::Residence_Management_System.Properties.Resources.LogoRMS;
            this.LogoLandingPage.ImageRotate = 0F;
            this.LogoLandingPage.Location = new System.Drawing.Point(0, 0);
            this.LogoLandingPage.Name = "LogoLandingPage";
            this.LogoLandingPage.Size = new System.Drawing.Size(163, 58);
            this.LogoLandingPage.TabIndex = 17;
            this.LogoLandingPage.TabStop = false;
            this.LogoLandingPage.Click += new System.EventHandler(this.guna2PictureBox2_Click_1);
            // 
            // menuBtn
            // 
            this.menuBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.menuBtn.FlatAppearance.BorderSize = 0;
            this.menuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuBtn.ForeColor = System.Drawing.Color.White;
            this.menuBtn.IconChar = FontAwesome.Sharp.IconChar.Navicon;
            this.menuBtn.IconColor = System.Drawing.Color.White;
            this.menuBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuBtn.IconSize = 32;
            this.menuBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuBtn.Location = new System.Drawing.Point(3, 3);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(192, 55);
            this.menuBtn.TabIndex = 12;
            this.menuBtn.Text = " Menu";
            this.menuBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.menuBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.menuBtn.UseVisualStyleBackColor = true;
            this.menuBtn.Click += new System.EventHandler(this.iconButton1_Click_1);
            // 
            // homebtn
            // 
            this.homebtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homebtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.homebtn.FlatAppearance.BorderSize = 0;
            this.homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.homebtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homebtn.ForeColor = System.Drawing.Color.White;
            this.homebtn.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.homebtn.IconColor = System.Drawing.Color.White;
            this.homebtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.homebtn.IconSize = 32;
            this.homebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homebtn.Location = new System.Drawing.Point(3, 64);
            this.homebtn.Name = "homebtn";
            this.homebtn.Size = new System.Drawing.Size(192, 44);
            this.homebtn.TabIndex = 6;
            this.homebtn.Text = " Home";
            this.homebtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.homebtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.homebtn.UseVisualStyleBackColor = true;
            this.homebtn.Click += new System.EventHandler(this.homebtn_Click);
            // 
            // registerbtn
            // 
            this.registerbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registerbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.registerbtn.FlatAppearance.BorderSize = 0;
            this.registerbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registerbtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerbtn.ForeColor = System.Drawing.Color.White;
            this.registerbtn.IconChar = FontAwesome.Sharp.IconChar.UserPlus;
            this.registerbtn.IconColor = System.Drawing.Color.White;
            this.registerbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.registerbtn.IconSize = 32;
            this.registerbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registerbtn.Location = new System.Drawing.Point(3, 114);
            this.registerbtn.Name = "registerbtn";
            this.registerbtn.Size = new System.Drawing.Size(192, 44);
            this.registerbtn.TabIndex = 7;
            this.registerbtn.Text = " Register";
            this.registerbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.registerbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.registerbtn.UseVisualStyleBackColor = true;
            this.registerbtn.Click += new System.EventHandler(this.registerbtn_Click);
            // 
            // roombtn
            // 
            this.roombtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.roombtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.roombtn.FlatAppearance.BorderSize = 0;
            this.roombtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.roombtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roombtn.ForeColor = System.Drawing.Color.White;
            this.roombtn.IconChar = FontAwesome.Sharp.IconChar.Bed;
            this.roombtn.IconColor = System.Drawing.Color.White;
            this.roombtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.roombtn.IconSize = 32;
            this.roombtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roombtn.Location = new System.Drawing.Point(3, 164);
            this.roombtn.Name = "roombtn";
            this.roombtn.Size = new System.Drawing.Size(192, 44);
            this.roombtn.TabIndex = 8;
            this.roombtn.Text = " Rooms";
            this.roombtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.roombtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.roombtn.UseVisualStyleBackColor = true;
            this.roombtn.Click += new System.EventHandler(this.roombtn_Click);
            // 
            // activitiesbtn
            // 
            this.activitiesbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.activitiesbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.activitiesbtn.FlatAppearance.BorderSize = 0;
            this.activitiesbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.activitiesbtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.activitiesbtn.ForeColor = System.Drawing.Color.White;
            this.activitiesbtn.IconChar = FontAwesome.Sharp.IconChar.A;
            this.activitiesbtn.IconColor = System.Drawing.Color.White;
            this.activitiesbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.activitiesbtn.IconSize = 32;
            this.activitiesbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.activitiesbtn.Location = new System.Drawing.Point(3, 214);
            this.activitiesbtn.Name = "activitiesbtn";
            this.activitiesbtn.Size = new System.Drawing.Size(192, 44);
            this.activitiesbtn.TabIndex = 9;
            this.activitiesbtn.Text = " Activities";
            this.activitiesbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.activitiesbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.activitiesbtn.UseVisualStyleBackColor = true;
            this.activitiesbtn.Click += new System.EventHandler(this.activitiesbtn_Click);
            // 
            // reporbtn
            // 
            this.reporbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reporbtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.reporbtn.FlatAppearance.BorderSize = 0;
            this.reporbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reporbtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reporbtn.ForeColor = System.Drawing.Color.White;
            this.reporbtn.IconChar = FontAwesome.Sharp.IconChar.FileDownload;
            this.reporbtn.IconColor = System.Drawing.Color.White;
            this.reporbtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.reporbtn.IconSize = 32;
            this.reporbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reporbtn.Location = new System.Drawing.Point(3, 264);
            this.reporbtn.Name = "reporbtn";
            this.reporbtn.Size = new System.Drawing.Size(192, 44);
            this.reporbtn.TabIndex = 10;
            this.reporbtn.Text = " Report";
            this.reporbtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reporbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.reporbtn.UseVisualStyleBackColor = true;
            this.reporbtn.Click += new System.EventHandler(this.reporbtn_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 627);
            this.Controls.Add(this.tabsContainer);
            this.Controls.Add(this.panelLogo);
            this.Controls.Add(this.sideBarContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LandingPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LandingPage";
            this.Load += new System.EventHandler(this.LandingPage_Load);
            this.sideBarContainer.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LogoLandingPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton homebtn;
        private FontAwesome.Sharp.IconButton registerbtn;
        private FontAwesome.Sharp.IconButton roombtn;
        private FontAwesome.Sharp.IconButton activitiesbtn;
        private FontAwesome.Sharp.IconButton reporbtn;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Timer sideBarTimer;
        public System.Windows.Forms.FlowLayoutPanel sideBarContainer;
        private FontAwesome.Sharp.IconButton menuBtn;
        private Guna.UI2.WinForms.Guna2PictureBox LogoLandingPage;
        private System.Windows.Forms.Panel tabsContainer;
    }
}