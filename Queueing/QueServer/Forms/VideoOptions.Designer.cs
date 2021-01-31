namespace QueServer.Forms
{
    partial class VideoOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VideoOptions));
            this.dialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.speechVol = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.normalVol = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            this.playerList = new System.Windows.Forms.ComboBox();
            this.mediaPlayerButtons3 = new QueServer.MediaPlayerButtons();
            this.selectVideosBtn = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speechVol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalVol)).BeginInit();
            this.SuspendLayout();
            // 
            // dialog
            // 
            this.dialog.Filter = "Media Formats: *.mp3, *.mp4, *.mkv|*.mp3;*.mp4;*.mkv";
            this.dialog.Multiselect = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Controls.Add(this.playerList);
            this.groupBox3.Controls.Add(this.mediaPlayerButtons3);
            this.groupBox3.Controls.Add(this.selectVideosBtn);
            this.groupBox3.Location = new System.Drawing.Point(12, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 258);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Media Controls";
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.speechVol);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.normalVol);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(7, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 118);
            this.panel1.TabIndex = 4;
            // 
            // speechVol
            // 
            this.speechVol.Dock = System.Windows.Forms.DockStyle.Top;
            this.speechVol.Location = new System.Drawing.Point(0, 71);
            this.speechVol.Maximum = 100;
            this.speechVol.Name = "speechVol";
            this.speechVol.Size = new System.Drawing.Size(197, 45);
            this.speechVol.TabIndex = 6;
            this.speechVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.speechVol.Value = 100;
            this.speechVol.Scroll += new System.EventHandler(this.speechVol_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "On Speech Volume";
            // 
            // normalVol
            // 
            this.normalVol.Dock = System.Windows.Forms.DockStyle.Top;
            this.normalVol.Location = new System.Drawing.Point(0, 13);
            this.normalVol.Maximum = 100;
            this.normalVol.Name = "normalVol";
            this.normalVol.Size = new System.Drawing.Size(197, 45);
            this.normalVol.TabIndex = 0;
            this.normalVol.TickStyle = System.Windows.Forms.TickStyle.None;
            this.normalVol.Value = 100;
            this.normalVol.Scroll += new System.EventHandler(this.normalVol_Scroll);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Media Playing Volume";
            // 
            // playerList
            // 
            this.playerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.playerList.FormattingEnabled = true;
            this.playerList.Location = new System.Drawing.Point(7, 19);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(199, 21);
            this.playerList.TabIndex = 5;
            this.playerList.SelectedIndexChanged += new System.EventHandler(this.playerList_SelectedIndexChanged);
            // 
            // mediaPlayerButtons3
            // 
            this.mediaPlayerButtons3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mediaPlayerButtons3.Location = new System.Drawing.Point(7, 170);
            this.mediaPlayerButtons3.Name = "mediaPlayerButtons3";
            this.mediaPlayerButtons3.Size = new System.Drawing.Size(199, 44);
            this.mediaPlayerButtons3.TabIndex = 4;
            this.mediaPlayerButtons3.OnCommandIssued += new System.EventHandler<QueServer.MediaPlayerButtons.MediaCommandTypes>(this.mediaPlayerButtons_OnCommandIssued);
            // 
            // selectVideosBtn
            // 
            this.selectVideosBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.selectVideosBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.selectVideosBtn.Location = new System.Drawing.Point(7, 220);
            this.selectVideosBtn.Name = "selectVideosBtn";
            this.selectVideosBtn.Size = new System.Drawing.Size(199, 28);
            this.selectVideosBtn.TabIndex = 3;
            this.selectVideosBtn.Text = "Select Videos";
            this.selectVideosBtn.UseVisualStyleBackColor = false;
            this.selectVideosBtn.Click += new System.EventHandler(this.selectVideosBtn_Click);
            // 
            // VideoOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 281);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VideoOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video Options";
            this.Load += new System.EventHandler(this.VideoOptions_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speechVol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.normalVol)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog dialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private MediaPlayerButtons mediaPlayerButtons3;
        private System.Windows.Forms.Button selectVideosBtn;
        private System.Windows.Forms.TrackBar normalVol;
        private System.Windows.Forms.ComboBox playerList;
        private System.Windows.Forms.TrackBar speechVol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}