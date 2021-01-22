namespace QueServer
{
    partial class TransactionList
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
            this.transactionsTable = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prefCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delCol = new System.Windows.Forms.DataGridViewButtonColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.transactionsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // transactionsTable
            // 
            this.transactionsTable.AllowUserToAddRows = false;
            this.transactionsTable.AllowUserToDeleteRows = false;
            this.transactionsTable.AllowUserToResizeColumns = false;
            this.transactionsTable.AllowUserToResizeRows = false;
            this.transactionsTable.BackgroundColor = System.Drawing.SystemColors.Control;
            this.transactionsTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transactionsTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.transactionsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.transactionsTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.nameCol,
            this.prefCol,
            this.detCol,
            this.delCol});
            this.transactionsTable.EnableHeadersVisualStyles = false;
            this.transactionsTable.Location = new System.Drawing.Point(12, 49);
            this.transactionsTable.MultiSelect = false;
            this.transactionsTable.Name = "transactionsTable";
            this.transactionsTable.ReadOnly = true;
            this.transactionsTable.RowHeadersVisible = false;
            this.transactionsTable.Size = new System.Drawing.Size(776, 389);
            this.transactionsTable.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Id";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // nameCol
            // 
            this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.nameCol.HeaderText = "Name";
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            this.nameCol.Width = 60;
            // 
            // prefCol
            // 
            this.prefCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.prefCol.HeaderText = "Prefix";
            this.prefCol.Name = "prefCol";
            this.prefCol.ReadOnly = true;
            this.prefCol.Width = 58;
            // 
            // detCol
            // 
            this.detCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.detCol.HeaderText = "Details";
            this.detCol.Name = "detCol";
            this.detCol.ReadOnly = true;
            // 
            // delCol
            // 
            this.delCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delCol.HeaderText = "Delete";
            this.delCol.Name = "delCol";
            this.delCol.ReadOnly = true;
            this.delCol.Width = 44;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(599, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "ADD NEW TRANSACTION";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TransactionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.transactionsTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TransactionList";
            this.Text = "Transaction List";
            this.Load += new System.EventHandler(this.TransactionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.transactionsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView transactionsTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn prefCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn detCol;
        private System.Windows.Forms.DataGridViewButtonColumn delCol;
    }
}