using QueDatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueCounter
{
    public partial class CounterRegistration : Form
    {
        public CounterRegistration()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                transactions.Items.AddRange(q.Transactions.Select(x => x.Name).ToArray());
                transactions.SelectedIndex = 0;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                if (!q.Counters.Any(x => x.CounterNumber == (int)numericUpDown1.Value))
                {
                    var c = new Counter();
                    // c.IpAddress = label1.Text;
                    c.Transaction = q.Transactions.FirstOrDefault(x => x.Name == transactions.Text);
                    c.CounterNumber = (int)numericUpDown1.Value;

                    q.Counters.Add(c);
                    q.SaveChanges();
                }
                else
                {
                    var c = q.Counters.FirstOrDefault(x => x.CounterNumber == (int)numericUpDown1.Value);
                    c.Transaction = q.Transactions.FirstOrDefault(x => x.Name == transactions.Text);
                    q.SaveChanges();

                }

                AppStartup.CounterNumber = (int)numericUpDown1.Value;
                DialogResult = DialogResult.Yes;
                this.Close();
            }
        }
    }
}
