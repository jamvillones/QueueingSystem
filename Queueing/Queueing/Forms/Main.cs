using QueDatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queueing
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);

        //    // WM_SYSCOMMAND
        //    if (m.Msg == 0x0112)
        //    {
        //        if (m.WParam == new IntPtr(0xF030) // Maximize event - SC_MAXIMIZE from Winuser.h
        //            ) // Restore event - SC_RESTORE from Winuser.h
        //        {
        //            OnMaximized();
        //        }
        //        if (m.WParam == new IntPtr(0xF120))
        //            OnNormal();
        //    }
        //}

        //void OnMaximized()
        //{
        //    this.FormBorderStyle = FormBorderStyle.None;
        //}
        //void OnNormal()
        //{
        //    this.FormBorderStyle = FormBorderStyle.Sizable;
        //}

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Main_Load(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Transactions)
                {
                    var token = new TicketToken();
                    token.Dock = DockStyle.Fill;
                    token.Transaction = i.Name.ToUpper();

                    foreach (var j in i.Counters)
                    {
                        token.Counters += "COUNTER " + j.CounterNumber + " ";
                    }
                    token.OnSelected += (X, Y) =>
                    {
                        ShowConfirmation(i.Id);
                    };
                    //flowLayoutPanel1.Controls.Add(token);
                    tableLayoutPanel1.Controls.Add(token);
                }
            }
        }
        void AddControlsInTable(Control[] c)
        {

        }
        void ShowConfirmation(int id)
        {
            using (var ticketCon = new TicketConfirmationForm())
            {
                using (var q = new QueeuingEntities())
                {
                    ticketCon.targetTransaction = q.Transactions.FirstOrDefault(x => x.Id == id);
                    ticketCon.Number = ticketCon.targetTransaction.CurrentNumber + 1;
                }
                ticketCon.ShowDialog();
            }
        }

        //void AddItemToQue(int id)
        //{
        //    using (var w = new QueeuingEntities())
        //    {
        //        var item = w.Transactions.FirstOrDefault(x => x.Id == id);
        //        var filteredItem = w.Ques.Where(x => x.TransactionId == item.Id).OrderByDescending(y => y.Number);

        //        var qitem = new Que();
        //        qitem.Item = item;
        //        qitem.Pending = true;
        //        int number = filteredItem.Count() == 0 ? 1 : filteredItem.First().Number + 1;
        //        qitem.Number = number;

        //        w.Ques.Add(qitem);
        //        w.SaveChanges();
        //    }
        //}

        Button createButton(string name)
        {
            Button newButton = new Button();
            newButton.Text = name.ToUpper();
            newButton.BackColor = Color.Gainsboro;
            newButton.Font = new System.Drawing.Font("TIMES NEW ROMAN", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            newButton.Margin = new System.Windows.Forms.Padding(5);
            newButton.Size = new System.Drawing.Size(250, 150);
            newButton.UseVisualStyleBackColor = true;

            return newButton;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timeLabel.Text = DateTime.Now.ToString("h:mm:ss tt  ddd  MMMM dd yyyy").ToUpper();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                RefreshControls();
            }
            if (e.KeyCode == Keys.Escape)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
        }
        void RefreshControls()
        {
            var controls = tableLayoutPanel1.Controls.Cast<TicketToken>().ToArray();

            tableLayoutPanel1.Controls.Clear();

            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Transactions)
                {
                    var token = new TicketToken();
                    token.Dock = DockStyle.Fill;
                    token.Transaction = i.Name.ToUpper();

                    foreach (var j in i.Counters)
                    {
                        token.Counters += "COUNTER " + j.CounterNumber + " ";
                    }
                    token.OnSelected += (X, Y) =>
                    {
                        ShowConfirmation(i.Id);
                    };
                    tableLayoutPanel1.Controls.Add(token);
                }
            }
            foreach (var i in controls)
                i.Dispose();
        }
    }
}
