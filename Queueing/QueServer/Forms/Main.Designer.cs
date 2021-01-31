namespace QueServer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.settingsSubPanel = new System.Windows.Forms.Panel();
            this.videoOptBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.connectionWorker = new System.ComponentModel.BackgroundWorker();
            this.topPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.exitBtn = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CenterPanel = new System.Windows.Forms.Panel();
            this.centerTable = new System.Windows.Forms.TableLayoutPanel();
            this.numbersTable = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.MediaPlayerTop = new AxWMPLib.AxWindowsMediaPlayer();
            this.MediaPlayerBottom = new AxWMPLib.AxWindowsMediaPlayer();
            this.ofdVideos = new System.Windows.Forms.OpenFileDialog();
            this.sidePanel.SuspendLayout();
            this.settingsSubPanel.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.topPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CenterPanel.SuspendLayout();
            this.centerTable.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayerTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayerBottom)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.sidePanel.Controls.Add(this.settingsSubPanel);
            this.sidePanel.Controls.Add(this.settingBtn);
            this.sidePanel.Controls.Add(this.panel6);
            this.sidePanel.Controls.Add(this.panel5);
            this.sidePanel.Controls.Add(this.Title);
            this.sidePanel.Controls.Add(this.pictureBox1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(163, 450);
            this.sidePanel.TabIndex = 0;
            // 
            // settingsSubPanel
            // 
            this.settingsSubPanel.AutoSize = true;
            this.settingsSubPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.settingsSubPanel.Controls.Add(this.videoOptBtn);
            this.settingsSubPanel.Controls.Add(this.refreshBtn);
            this.settingsSubPanel.Controls.Add(this.clearBtn);
            this.settingsSubPanel.Controls.Add(this.button10);
            this.settingsSubPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingsSubPanel.Location = new System.Drawing.Point(0, 325);
            this.settingsSubPanel.Name = "settingsSubPanel";
            this.settingsSubPanel.Size = new System.Drawing.Size(163, 100);
            this.settingsSubPanel.TabIndex = 9;
            this.settingsSubPanel.Visible = false;
            // 
            // videoOptBtn
            // 
            this.videoOptBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.videoOptBtn.FlatAppearance.BorderSize = 0;
            this.videoOptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.videoOptBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoOptBtn.ForeColor = System.Drawing.Color.White;
            this.videoOptBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.videoOptBtn.Location = new System.Drawing.Point(0, 75);
            this.videoOptBtn.Name = "videoOptBtn";
            this.videoOptBtn.Size = new System.Drawing.Size(163, 25);
            this.videoOptBtn.TabIndex = 16;
            this.videoOptBtn.Text = "VIDEO OPTIONS";
            this.videoOptBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.videoOptBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.videoOptBtn.UseVisualStyleBackColor = true;
            this.videoOptBtn.Click += new System.EventHandler(this.videoOptBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.refreshBtn.FlatAppearance.BorderSize = 0;
            this.refreshBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.refreshBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refreshBtn.ForeColor = System.Drawing.Color.White;
            this.refreshBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.Location = new System.Drawing.Point(0, 50);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(163, 25);
            this.refreshBtn.TabIndex = 14;
            this.refreshBtn.Text = " REFRESH";
            this.refreshBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refreshBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.clearBtn.FlatAppearance.BorderSize = 0;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearBtn.ForeColor = System.Drawing.Color.White;
            this.clearBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearBtn.Location = new System.Drawing.Point(0, 25);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(163, 25);
            this.clearBtn.TabIndex = 15;
            this.clearBtn.Text = " RESET NUMBERS";
            this.clearBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.clearBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.toolTip1.SetToolTip(this.clearBtn, "Resets all numbers back to 0");
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // button10
            // 
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.White;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(163, 25);
            this.button10.TabIndex = 12;
            this.button10.Text = " TRANSACTIONS";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // settingBtn
            // 
            this.settingBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settingBtn.FlatAppearance.BorderSize = 0;
            this.settingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingBtn.ForeColor = System.Drawing.Color.White;
            this.settingBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingBtn.Location = new System.Drawing.Point(0, 425);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(163, 25);
            this.settingBtn.TabIndex = 8;
            this.settingBtn.Text = "SETTINGS";
            this.settingBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingBtn.UseVisualStyleBackColor = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // panel6
            // 
            this.panel6.AutoScroll = true;
            this.panel6.AutoSize = true;
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 450);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(163, 0);
            this.panel6.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.panel4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 171);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(163, 26);
            this.panel5.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(5, 13);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(152, 1);
            this.panel4.TabIndex = 3;
            // 
            // Title
            // 
            this.Title.Dock = System.Windows.Forms.DockStyle.Top;
            this.Title.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(191)))), ((int)(((byte)(108)))));
            this.Title.Location = new System.Drawing.Point(0, 119);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(163, 52);
            this.Title.TabIndex = 5;
            this.Title.Text = "MUNICIPALITY OF KALIBO";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(163, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // connectionWorker
            // 
            this.connectionWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.connectionWorker_DoWork);
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(136)))), ((int)(((byte)(8)))));
            this.topPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.topPanel.Controls.Add(this.label2);
            this.topPanel.Controls.Add(this.exitBtn);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(163, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(681, 30);
            this.topPanel.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(651, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "MUNICIPALITY OF KALIBO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // exitBtn
            // 
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.Location = new System.Drawing.Point(651, 0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(28, 28);
            this.exitBtn.TabIndex = 0;
            this.exitBtn.TabStop = false;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(113)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(163, 430);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(681, 20);
            this.panel3.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(681, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.clockTimer_Tick);
            // 
            // CenterPanel
            // 
            this.CenterPanel.Controls.Add(this.centerTable);
            this.CenterPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CenterPanel.Location = new System.Drawing.Point(163, 30);
            this.CenterPanel.Name = "CenterPanel";
            this.CenterPanel.Size = new System.Drawing.Size(681, 400);
            this.CenterPanel.TabIndex = 5;
            // 
            // centerTable
            // 
            this.centerTable.ColumnCount = 2;
            this.centerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.centerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.centerTable.Controls.Add(this.numbersTable, 0, 0);
            this.centerTable.Controls.Add(this.tableLayoutPanel1, 1, 0);
            this.centerTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.centerTable.Location = new System.Drawing.Point(0, 0);
            this.centerTable.Name = "centerTable";
            this.centerTable.RowCount = 1;
            this.centerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.centerTable.Size = new System.Drawing.Size(681, 400);
            this.centerTable.TabIndex = 0;
            // 
            // numbersTable
            // 
            this.numbersTable.ColumnCount = 2;
            this.numbersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.numbersTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.numbersTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numbersTable.Location = new System.Drawing.Point(3, 3);
            this.numbersTable.Name = "numbersTable";
            this.numbersTable.RowCount = 6;
            this.numbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.numbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.numbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.numbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.numbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.numbersTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.numbersTable.Size = new System.Drawing.Size(266, 394);
            this.numbersTable.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.MediaPlayerTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.MediaPlayerBottom, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(275, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(403, 394);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // MediaPlayerTop
            // 
            this.MediaPlayerTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayerTop.Enabled = true;
            this.MediaPlayerTop.Location = new System.Drawing.Point(3, 3);
            this.MediaPlayerTop.Name = "MediaPlayerTop";
            this.MediaPlayerTop.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayerTop.OcxState")));
            this.MediaPlayerTop.Size = new System.Drawing.Size(397, 191);
            this.MediaPlayerTop.TabIndex = 7;
            // 
            // MediaPlayerBottom
            // 
            this.MediaPlayerBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MediaPlayerBottom.Enabled = true;
            this.MediaPlayerBottom.Location = new System.Drawing.Point(3, 200);
            this.MediaPlayerBottom.Name = "MediaPlayerBottom";
            this.MediaPlayerBottom.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MediaPlayerBottom.OcxState")));
            this.MediaPlayerBottom.Size = new System.Drawing.Size(397, 191);
            this.MediaPlayerBottom.TabIndex = 8;
            // 
            // ofdVideos
            // 
            this.ofdVideos.Filter = "MP4 files|*.mp4|MKV files|*.mkv";
            this.ofdVideos.Multiselect = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(844, 450);
            this.ControlBox = false;
            this.Controls.Add(this.CenterPanel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.sidePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.settingsSubPanel.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.topPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.CenterPanel.ResumeLayout(false);
            this.centerTable.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayerTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MediaPlayerBottom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.ComponentModel.BackgroundWorker connectionWorker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button settingBtn;
        private System.Windows.Forms.Panel settingsSubPanel;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Panel CenterPanel;
        private System.Windows.Forms.TableLayoutPanel centerTable;
        private System.Windows.Forms.TableLayoutPanel numbersTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayerTop;
        private System.Windows.Forms.Button videoOptBtn;
        private System.Windows.Forms.OpenFileDialog ofdVideos;
        private AxWMPLib.AxWindowsMediaPlayer MediaPlayerBottom;
    }
}

