namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            this.lblCurrency1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNFarm = new System.Windows.Forms.Button();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.RBKnight = new System.Windows.Forms.RadioButton();
            this.RBArcher = new System.Windows.Forms.RadioButton();
            this.RBMag = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(598, 325);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblCurrency
            // 
            this.lblCurrency.AutoSize = true;
            this.lblCurrency.Location = new System.Drawing.Point(41, 234);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(0, 13);
            this.lblCurrency.TabIndex = 1;
            // 
            // lblCurrency1
            // 
            this.lblCurrency1.AutoSize = true;
            this.lblCurrency1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrency1.Location = new System.Drawing.Point(62, 13);
            this.lblCurrency1.Name = "lblCurrency1";
            this.lblCurrency1.Size = new System.Drawing.Size(58, 25);
            this.lblCurrency1.TabIndex = 0;
            this.lblCurrency1.Text = "coins";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.BTNFarm);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.RBKnight);
            this.panel1.Controls.Add(this.RBArcher);
            this.panel1.Controls.Add(this.RBMag);
            this.panel1.Location = new System.Drawing.Point(297, 396);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 151);
            this.panel1.TabIndex = 1;
            // 
            // BTNFarm
            // 
            this.BTNFarm.Location = new System.Drawing.Point(389, 117);
            this.BTNFarm.Name = "BTNFarm";
            this.BTNFarm.Size = new System.Drawing.Size(136, 23);
            this.BTNFarm.TabIndex = 8;
            this.BTNFarm.Text = "Покращити - 25";
            this.BTNFarm.UseVisualStyleBackColor = true;
            this.BTNFarm.Click += new System.EventHandler(this.BTNFarm_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(399, 3);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(100, 108);
            this.pictureBox5.TabIndex = 7;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(266, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(100, 108);
            this.pictureBox4.TabIndex = 6;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(140, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 108);
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 108);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // RBKnight
            // 
            this.RBKnight.AutoSize = true;
            this.RBKnight.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RBKnight.Location = new System.Drawing.Point(282, 120);
            this.RBKnight.Name = "RBKnight";
            this.RBKnight.Size = new System.Drawing.Size(68, 17);
            this.RBKnight.TabIndex = 2;
            this.RBKnight.TabStop = true;
            this.RBKnight.Text = "Воїн - 50";
            this.RBKnight.UseVisualStyleBackColor = true;
            // 
            // RBArcher
            // 
            this.RBArcher.AutoSize = true;
            this.RBArcher.Location = new System.Drawing.Point(144, 120);
            this.RBArcher.Name = "RBArcher";
            this.RBArcher.Size = new System.Drawing.Size(96, 17);
            this.RBArcher.TabIndex = 1;
            this.RBArcher.TabStop = true;
            this.RBArcher.Text = "Стрілець - 100";
            this.RBArcher.UseVisualStyleBackColor = true;
            // 
            // RBMag
            // 
            this.RBMag.AutoSize = true;
            this.RBMag.Location = new System.Drawing.Point(18, 120);
            this.RBMag.Name = "RBMag";
            this.RBMag.Size = new System.Drawing.Size(72, 17);
            this.RBMag.TabIndex = 0;
            this.RBMag.TabStop = true;
            this.RBMag.Text = "Маг - 150";
            this.RBMag.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lblCurrency1);
            this.panel2.Location = new System.Drawing.Point(637, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 81);
            this.panel2.TabIndex = 2;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(3, 13);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(56, 63);
            this.pictureBox6.TabIndex = 2;
            this.pictureBox6.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(62, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "1/sec";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(34, 123);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // Form1
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(816, 553);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblCurrency;
        private System.Windows.Forms.Label lblCurrency1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RBKnight;
        private System.Windows.Forms.RadioButton RBArcher;
        private System.Windows.Forms.RadioButton RBMag;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNFarm;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

