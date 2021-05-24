namespace FF4FE_Tracker_and_Timer
{
    partial class EnterFlags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnterFlags));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbPresetFlags = new System.Windows.Forms.ComboBox();
            this.gbHidden = new System.Windows.Forms.GroupBox();
            this.cbWin = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbReqCount = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbObjCount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtFlags = new System.Windows.Forms.TextBox();
            this.gbHidden.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(13, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Your Flag String Here";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(13, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Choose a Preset Flag Set";
            // 
            // cbPresetFlags
            // 
            this.cbPresetFlags.FormattingEnabled = true;
            this.cbPresetFlags.Location = new System.Drawing.Point(16, 119);
            this.cbPresetFlags.Name = "cbPresetFlags";
            this.cbPresetFlags.Size = new System.Drawing.Size(378, 21);
            this.cbPresetFlags.TabIndex = 3;
            this.cbPresetFlags.SelectedIndexChanged += new System.EventHandler(this.cbPresetFlags_SelectedIndexChanged);
            // 
            // gbHidden
            // 
            this.gbHidden.Controls.Add(this.cbWin);
            this.gbHidden.Controls.Add(this.label5);
            this.gbHidden.Controls.Add(this.cbReqCount);
            this.gbHidden.Controls.Add(this.label4);
            this.gbHidden.Controls.Add(this.cbObjCount);
            this.gbHidden.Enabled = false;
            this.gbHidden.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbHidden.ForeColor = System.Drawing.SystemColors.Control;
            this.gbHidden.Location = new System.Drawing.Point(16, 175);
            this.gbHidden.Name = "gbHidden";
            this.gbHidden.Size = new System.Drawing.Size(378, 151);
            this.gbHidden.TabIndex = 4;
            this.gbHidden.TabStop = false;
            this.gbHidden.Text = "Hidden Flag Objectives";
            // 
            // cbWin
            // 
            this.cbWin.FormattingEnabled = true;
            this.cbWin.Items.AddRange(new object[] {
            "game",
            "crystal"});
            this.cbWin.Location = new System.Drawing.Point(141, 109);
            this.cbWin.Name = "cbWin";
            this.cbWin.Size = new System.Drawing.Size(67, 24);
            this.cbWin.TabIndex = 9;
            this.cbWin.SelectedIndexChanged += new System.EventHandler(this.cbWin_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(11, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Win Condition";
            // 
            // cbReqCount
            // 
            this.cbReqCount.FormattingEnabled = true;
            this.cbReqCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbReqCount.Location = new System.Drawing.Point(141, 69);
            this.cbReqCount.Name = "cbReqCount";
            this.cbReqCount.Size = new System.Drawing.Size(67, 24);
            this.cbReqCount.TabIndex = 7;
            this.cbReqCount.SelectedIndexChanged += new System.EventHandler(this.cbReqCount_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Control;
            this.label4.Location = new System.Drawing.Point(11, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Required Count";
            // 
            // cbObjCount
            // 
            this.cbObjCount.FormattingEnabled = true;
            this.cbObjCount.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbObjCount.Location = new System.Drawing.Point(141, 27);
            this.cbObjCount.Name = "cbObjCount";
            this.cbObjCount.Size = new System.Drawing.Size(67, 24);
            this.cbObjCount.TabIndex = 6;
            this.cbObjCount.SelectedIndexChanged += new System.EventHandler(this.cbObjCount_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(27, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Objective Count";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(216, 351);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(319, 351);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtFlags
            // 
            this.txtFlags.Location = new System.Drawing.Point(13, 48);
            this.txtFlags.Name = "txtFlags";
            this.txtFlags.Size = new System.Drawing.Size(381, 20);
            this.txtFlags.TabIndex = 8;
            // 
            // EnterFlags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(99)))));
            this.ClientSize = new System.Drawing.Size(411, 388);
            this.Controls.Add(this.txtFlags);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbHidden);
            this.Controls.Add(this.cbPresetFlags);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnterFlags";
            this.Text = "Free Enterprise Flag Entry";
            this.Load += new System.EventHandler(this.EnterFlags_Load);
            this.gbHidden.ResumeLayout(false);
            this.gbHidden.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbPresetFlags;
        private System.Windows.Forms.GroupBox gbHidden;
        private System.Windows.Forms.ComboBox cbWin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbReqCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbObjCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtFlags;
    }
}