using CustomisedPicture;
namespace WindowsFormsApp1
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
            this.centre_hex = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.start_rocket = new System.Windows.Forms.PictureBox();
            this.reset_planet = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pattern_timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.centre_hex)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.start_rocket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reset_planet)).BeginInit();
            this.SuspendLayout();
            // 
            // centre_hex
            // 
            this.centre_hex.BackColor = System.Drawing.Color.Transparent;
            this.centre_hex.Image = ((System.Drawing.Image)(resources.GetObject("centre_hex.Image")));
            this.centre_hex.Location = new System.Drawing.Point(1032, 42);
            this.centre_hex.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.centre_hex.Name = "centre_hex";
            this.centre_hex.Size = new System.Drawing.Size(140, 127);
            this.centre_hex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.centre_hex.TabIndex = 4;
            this.centre_hex.TabStop = false;
            this.centre_hex.Click += new System.EventHandler(this.centre_hex_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.start_rocket);
            this.panel1.Controls.Add(this.reset_planet);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1311, 784);
            this.panel1.TabIndex = 5;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove_1);
            // 
            // start_rocket
            // 
            this.start_rocket.Image = ((System.Drawing.Image)(resources.GetObject("start_rocket.Image")));
            this.start_rocket.Location = new System.Drawing.Point(880, 50);
            this.start_rocket.Margin = new System.Windows.Forms.Padding(4);
            this.start_rocket.Name = "start_rocket";
            this.start_rocket.Size = new System.Drawing.Size(213, 101);
            this.start_rocket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.start_rocket.TabIndex = 1;
            this.start_rocket.TabStop = false;
            this.start_rocket.Click += new System.EventHandler(this.start_rocket_Click);
            // 
            // reset_planet
            // 
            this.reset_planet.Image = ((System.Drawing.Image)(resources.GetObject("reset_planet.Image")));
            this.reset_planet.Location = new System.Drawing.Point(1144, 175);
            this.reset_planet.Margin = new System.Windows.Forms.Padding(4);
            this.reset_planet.Name = "reset_planet";
            this.reset_planet.Size = new System.Drawing.Size(120, 124);
            this.reset_planet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.reset_planet.TabIndex = 0;
            this.reset_planet.TabStop = false;
            this.reset_planet.Click += new System.EventHandler(this.reset_planet_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pattern_timer
            // 
            this.pattern_timer.Enabled = true;
            this.pattern_timer.Tick += new System.EventHandler(this.pattern_timer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(1137, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "START";
            this.label2.Click += new System.EventHandler(this.start_rocket_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(950, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 42);
            this.label1.TabIndex = 4;
            this.label1.Text = "RESET";
            this.label1.Click += new System.EventHandler(this.reset_planet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1311, 784);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.centre_hex);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.centre_hex)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.start_rocket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reset_planet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox centre_hex;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox reset_planet;
        private System.Windows.Forms.PictureBox start_rocket;
        private System.Windows.Forms.Timer pattern_timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

