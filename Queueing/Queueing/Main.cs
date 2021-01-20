﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void Main_Load(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Items)
                {
                    var token = new TicketToken();
                    token.Transaction = i.Name.ToUpper();

                    foreach (var j in i.Counters)
                    {
                        token.Counters += "COUNTER " + j.CounterNumber+" ";
                    }
                    token.OnSelected += (X, Y) =>
                    {
                        ShowConfirmation(i.Id);
                    };
                    flowLayoutPanel1.Controls.Add(token);
                }
            }
        }
        void ShowConfirmation(int id)
        {
            using (var ticketCon = new TicketConfirmationForm())
            {
                using (var q = new QueeuingEntities())
                {
                    ticketCon.targetItem = q.Items.FirstOrDefault(x => x.Id == id);
                    var f = q.Ques.Where(a => a.ItemId == id).OrderByDescending(c => c.Number);
                    ticketCon.Number = f.Count() == 0 ? 1 : f.First().Number + 1;
                }
                ticketCon.ShowDialog();
            }
        }
        void AddItemToQue(int id)
        {
            using (var w = new QueeuingEntities())
            {
                var item = w.Items.FirstOrDefault(x => x.Id == id);
                var filteredItem = w.Ques.Where(x => x.ItemId == item.Id).OrderByDescending(y => y.Number);

                var qitem = new Que();
                qitem.Item = item;
                qitem.Pending = true;
                int number = filteredItem.Count() == 0 ? 1 : filteredItem.First().Number + 1;
                qitem.Number = number;

                w.Ques.Add(qitem);
                w.SaveChanges();
            }
        }

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
            timeLabel.Text = (DateTime.Now.ToString("h:mm:ss tt - ddd MMMM dd, yyyy")).ToUpper();
        }
    }
}