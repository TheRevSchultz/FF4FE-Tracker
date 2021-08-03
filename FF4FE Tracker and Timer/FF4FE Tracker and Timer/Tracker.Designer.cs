namespace FF4FE_Tracker_and_Timer
{
    partial class Tracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tracker));
            this.clbObjectives = new System.Windows.Forms.CheckedListBox();
            this.lbFlags = new System.Windows.Forms.ListBox();
            this.lblObjectives = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.wbSchala = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReenterFlags = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tParseStopwatch = new System.Windows.Forms.Timer(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnBosses = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblVersion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clbObjectives
            // 
            this.clbObjectives.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.clbObjectives.CheckOnClick = true;
            this.clbObjectives.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbObjectives.ForeColor = System.Drawing.SystemColors.Window;
            this.clbObjectives.FormattingEnabled = true;
            this.clbObjectives.Location = new System.Drawing.Point(3, 24);
            this.clbObjectives.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.clbObjectives.Name = "clbObjectives";
            this.clbObjectives.Size = new System.Drawing.Size(366, 166);
            this.clbObjectives.TabIndex = 4;
            this.clbObjectives.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbObjectives_ItemCheck);
            this.clbObjectives.SelectedIndexChanged += new System.EventHandler(this.clbObjectives_SelectedIndexChanged);
            // 
            // lbFlags
            // 
            this.lbFlags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.lbFlags.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlags.ForeColor = System.Drawing.SystemColors.Window;
            this.lbFlags.FormattingEnabled = true;
            this.lbFlags.HorizontalScrollbar = true;
            this.lbFlags.ItemHeight = 16;
            this.lbFlags.Location = new System.Drawing.Point(3, 210);
            this.lbFlags.Name = "lbFlags";
            this.lbFlags.Size = new System.Drawing.Size(366, 244);
            this.lbFlags.TabIndex = 5;
            this.lbFlags.SelectedIndexChanged += new System.EventHandler(this.lbFlags_SelectedIndexChanged);
            // 
            // lblObjectives
            // 
            this.lblObjectives.AutoSize = true;
            this.lblObjectives.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblObjectives.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblObjectives.Location = new System.Drawing.Point(3, 4);
            this.lblObjectives.Name = "lblObjectives";
            this.lblObjectives.Size = new System.Drawing.Size(76, 15);
            this.lblObjectives.TabIndex = 6;
            this.lblObjectives.Text = "Objectives";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(3, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "Flags";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Finale Lyrics", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimer.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTimer.Location = new System.Drawing.Point(426, 10);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(128, 54);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "Timer";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(8, 465);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 9;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(8, 490);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(8, 515);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // wbSchala
            // 
            this.wbSchala.Location = new System.Drawing.Point(363, 63);
            this.wbSchala.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbSchala.Name = "wbSchala";
            this.wbSchala.ScriptErrorsSuppressed = true;
            this.wbSchala.Size = new System.Drawing.Size(316, 391);
            this.wbSchala.TabIndex = 12;
            this.wbSchala.Url = new System.Uri("http://schala-kitty.net/ff4fe-tracker/", System.UriKind.Absolute);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(193, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "Embedded Tracker and Zeromus Icon By SchalaKitty";
            // 
            // btnReenterFlags
            // 
            this.btnReenterFlags.Location = new System.Drawing.Point(89, 467);
            this.btnReenterFlags.Name = "btnReenterFlags";
            this.btnReenterFlags.Size = new System.Drawing.Size(98, 21);
            this.btnReenterFlags.TabIndex = 14;
            this.btnReenterFlags.Text = "Re-Enter Flags";
            this.btnReenterFlags.UseVisualStyleBackColor = true;
            this.btnReenterFlags.Click += new System.EventHandler(this.btnReenterFlags_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(193, 471);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Developed for FF4FE 4.4.0";
            // 
            // tParseStopwatch
            // 
            this.tParseStopwatch.Tick += new System.EventHandler(this.tParseStopwatch_Tick);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(194, 519);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(276, 19);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "http://schala-kitty.net/ff4fe-tracker/";
            // 
            // btnBosses
            // 
            this.btnBosses.Location = new System.Drawing.Point(89, 494);
            this.btnBosses.Name = "btnBosses";
            this.btnBosses.Size = new System.Drawing.Size(98, 44);
            this.btnBosses.TabIndex = 19;
            this.btnBosses.Text = "Boss Scaling Data";
            this.btnBosses.UseVisualStyleBackColor = true;
            this.btnBosses.Click += new System.EventHandler(this.btnBosses_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FF4FE_Tracker_and_Timer.Properties.Resources.FreeEnt;
            this.pictureBox1.Location = new System.Drawing.Point(594, 480);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(57, 58);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblVersion.Location = new System.Drawing.Point(405, 471);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(65, 19);
            this.lblVersion.TabIndex = 20;
            this.lblVersion.Text = "Version";
            // 
            // Tracker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(656, 550);
            this.Controls.Add(this.lbFlags);
            this.Controls.Add(this.clbObjectives);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnBosses);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnReenterFlags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.wbSchala);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblObjectives);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Tracker";
            this.Text = "Free Enterprise Tracker and Timer";
            this.Load += new System.EventHandler(this.Tracker_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbFlags;
        private System.Windows.Forms.Label lblObjectives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.WebBrowser wbSchala;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReenterFlags;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tParseStopwatch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnBosses;
        public System.Windows.Forms.CheckedListBox clbObjectives;
        private System.Windows.Forms.Label lblVersion;
    }
}

