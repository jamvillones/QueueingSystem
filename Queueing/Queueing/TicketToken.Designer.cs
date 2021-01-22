namespace Queueing
{
    partial class TicketToken
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
            this.transactionName = new System.Windows.Forms.Label();
            this.divider = new System.Windows.Forms.Panel();
            this.counterLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // transactionName
            // 
            this.transactionName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.transactionName.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionName.Location = new System.Drawing.Point(26, 22);
            this.transactionName.Name = "transactionName";
            this.transactionName.Size = new System.Drawing.Size(330, 97);
            this.transactionName.TabIndex = 0;
            this.transactionName.Text = "[TRANSACTION]\r\nTEST";
            this.transactionName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // divider
            // 
            this.divider.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.divider.BackColor = System.Drawing.Color.Black;
            this.divider.Location = new System.Drawing.Point(20, 122);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(341, 2);
            this.divider.TabIndex = 1;
            // 
            // counterLabel
            // 
            this.counterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.counterLabel.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterLabel.Location = new System.Drawing.Point(26, 127);
            this.counterLabel.Name = "counterLabel";
            this.counterLabel.Size = new System.Drawing.Size(330, 51);
            this.counterLabel.TabIndex = 2;
            this.counterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TicketToken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.counterLabel);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.transactionName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TicketToken";
            this.Size = new System.Drawing.Size(380, 200);
            this.Load += new System.EventHandler(this.TicketToken_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label transactionName;
        private System.Windows.Forms.Panel divider;
        private System.Windows.Forms.Label counterLabel;
    }
}
