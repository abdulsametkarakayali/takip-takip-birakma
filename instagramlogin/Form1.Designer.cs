namespace instagramlogin
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.imgProfile = new System.Windows.Forms.PictureBox();
            this.txtKullaniciId = new System.Windows.Forms.TextBox();
            this.txtIsim = new System.Windows.Forms.TextBox();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.txtBiografi = new System.Windows.Forms.TextBox();
            this.PnlBilgiler = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.takipçiİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takipBırakToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.kullaniciBegenileriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.imgProfile)).BeginInit();
            this.PnlBilgiler.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "KullaniciId";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "KullaniciAdi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "İsim";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Biografi";
            // 
            // imgProfile
            // 
            this.imgProfile.Location = new System.Drawing.Point(262, 15);
            this.imgProfile.Name = "imgProfile";
            this.imgProfile.Size = new System.Drawing.Size(117, 111);
            this.imgProfile.TabIndex = 11;
            this.imgProfile.TabStop = false;
            // 
            // txtKullaniciId
            // 
            this.txtKullaniciId.Location = new System.Drawing.Point(96, 15);
            this.txtKullaniciId.Name = "txtKullaniciId";
            this.txtKullaniciId.Size = new System.Drawing.Size(142, 20);
            this.txtKullaniciId.TabIndex = 12;
            // 
            // txtIsim
            // 
            this.txtIsim.Location = new System.Drawing.Point(96, 78);
            this.txtIsim.Name = "txtIsim";
            this.txtIsim.Size = new System.Drawing.Size(142, 20);
            this.txtIsim.TabIndex = 12;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(96, 42);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(142, 20);
            this.txtKullaniciAdi.TabIndex = 12;
            // 
            // txtBiografi
            // 
            this.txtBiografi.Location = new System.Drawing.Point(96, 113);
            this.txtBiografi.Name = "txtBiografi";
            this.txtBiografi.Size = new System.Drawing.Size(142, 20);
            this.txtBiografi.TabIndex = 12;
            // 
            // PnlBilgiler
            // 
            this.PnlBilgiler.Controls.Add(this.imgProfile);
            this.PnlBilgiler.Controls.Add(this.txtBiografi);
            this.PnlBilgiler.Controls.Add(this.label4);
            this.PnlBilgiler.Controls.Add(this.txtKullaniciAdi);
            this.PnlBilgiler.Controls.Add(this.label5);
            this.PnlBilgiler.Controls.Add(this.txtIsim);
            this.PnlBilgiler.Controls.Add(this.label6);
            this.PnlBilgiler.Controls.Add(this.txtKullaniciId);
            this.PnlBilgiler.Controls.Add(this.label7);
            this.PnlBilgiler.Location = new System.Drawing.Point(12, 27);
            this.PnlBilgiler.Name = "PnlBilgiler";
            this.PnlBilgiler.Size = new System.Drawing.Size(385, 150);
            this.PnlBilgiler.TabIndex = 13;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.takipçiİşlemleriToolStripMenuItem,
            this.takipBırakToolStripMenuItem1,
            this.kullaniciBegenileriToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(406, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // takipçiİşlemleriToolStripMenuItem
            // 
            this.takipçiİşlemleriToolStripMenuItem.Name = "takipçiİşlemleriToolStripMenuItem";
            this.takipçiİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(103, 20);
            this.takipçiİşlemleriToolStripMenuItem.Text = "Takipçi İşlemleri";
            this.takipçiİşlemleriToolStripMenuItem.Click += new System.EventHandler(this.takipçiİşlemleriToolStripMenuItem_Click);
            // 
            // takipBırakToolStripMenuItem1
            // 
            this.takipBırakToolStripMenuItem1.Name = "takipBırakToolStripMenuItem1";
            this.takipBırakToolStripMenuItem1.Size = new System.Drawing.Size(76, 20);
            this.takipBırakToolStripMenuItem1.Text = "Takip Bırak";
            this.takipBırakToolStripMenuItem1.Click += new System.EventHandler(this.takipBırakToolStripMenuItem1_Click);
            // 
            // kullaniciBegenileriToolStripMenuItem
            // 
            this.kullaniciBegenileriToolStripMenuItem.Name = "kullaniciBegenileriToolStripMenuItem";
            this.kullaniciBegenileriToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.kullaniciBegenileriToolStripMenuItem.Text = "Kullanici Begenileri";
            this.kullaniciBegenileriToolStripMenuItem.Click += new System.EventHandler(this.kullaniciBegenileriToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 207);
            this.Controls.Add(this.PnlBilgiler);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "İnstagram Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgProfile)).EndInit();
            this.PnlBilgiler.ResumeLayout(false);
            this.PnlBilgiler.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox imgProfile;
        private System.Windows.Forms.TextBox txtKullaniciId;
        private System.Windows.Forms.TextBox txtIsim;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.TextBox txtBiografi;
        private System.Windows.Forms.Panel PnlBilgiler;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem takipçiİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takipBırakToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem kullaniciBegenileriToolStripMenuItem;
    }
}

