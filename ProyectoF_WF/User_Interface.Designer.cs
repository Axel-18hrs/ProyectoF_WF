namespace ProyectoF_WF
{
    partial class User_Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(User_Interface));
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.pbCargarImagenes = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.escogerArchivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imagenesDelUsuarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videosDelUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Log_OutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenes)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(221, 78);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(890, 368);
            this.axWindowsMediaPlayer1.TabIndex = 0;
            this.axWindowsMediaPlayer1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.axWindowsMediaPlayer1_PreviewKeyDown);
            // 
            // pbCargarImagenes
            // 
            this.pbCargarImagenes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pbCargarImagenes.Location = new System.Drawing.Point(69, 66);
            this.pbCargarImagenes.Name = "pbCargarImagenes";
            this.pbCargarImagenes.Size = new System.Drawing.Size(1225, 419);
            this.pbCargarImagenes.TabIndex = 2;
            this.pbCargarImagenes.TabStop = false;
            this.pbCargarImagenes.DoubleClick += new System.EventHandler(this.pbCargarImagenes_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.escogerArchivoToolStripMenuItem,
            this.imagenesDelUsuarToolStripMenuItem,
            this.videosDelUsuarioToolStripMenuItem,
            this.Log_OutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1375, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // escogerArchivoToolStripMenuItem
            // 
            this.escogerArchivoToolStripMenuItem.Name = "escogerArchivoToolStripMenuItem";
            this.escogerArchivoToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.escogerArchivoToolStripMenuItem.Text = "Choose file";
            this.escogerArchivoToolStripMenuItem.Click += new System.EventHandler(this.escogerArchivoToolStripMenuItem_Click);
            // 
            // imagenesDelUsuarToolStripMenuItem
            // 
            this.imagenesDelUsuarToolStripMenuItem.Name = "imagenesDelUsuarToolStripMenuItem";
            this.imagenesDelUsuarToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.imagenesDelUsuarToolStripMenuItem.Text = "Studio image";
            this.imagenesDelUsuarToolStripMenuItem.Click += new System.EventHandler(this.imagenesDelUsuarToolStripMenuItem_Click);
            // 
            // videosDelUsuarioToolStripMenuItem
            // 
            this.videosDelUsuarioToolStripMenuItem.Name = "videosDelUsuarioToolStripMenuItem";
            this.videosDelUsuarioToolStripMenuItem.Size = new System.Drawing.Size(99, 24);
            this.videosDelUsuarioToolStripMenuItem.Text = "User videos";
            this.videosDelUsuarioToolStripMenuItem.Click += new System.EventHandler(this.videosDelUsuarioToolStripMenuItem_Click);
            // 
            // Log_OutToolStripMenuItem
            // 
            this.Log_OutToolStripMenuItem.Name = "Log_OutToolStripMenuItem";
            this.Log_OutToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.Log_OutToolStripMenuItem.Text = "Log out";
            this.Log_OutToolStripMenuItem.Click += new System.EventHandler(this.Log_OutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Crimson;
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1375, 55);
            this.panel1.TabIndex = 1;
            // 
            // User_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1370, 553);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.pbCargarImagenes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "User_Interface";
            this.Text = "User_Interface";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.User_Interface_FormClosed);
            this.Load += new System.EventHandler(this.User_Interface_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.User_Interface_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargarImagenes)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.PictureBox pbCargarImagenes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem escogerArchivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imagenesDelUsuarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videosDelUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Log_OutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
    }
}