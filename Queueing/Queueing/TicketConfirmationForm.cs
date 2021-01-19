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
    public partial class TicketConfirmationForm : Form
    {
        public TicketConfirmationForm()
        {
            InitializeComponent();
        }

        public Item targetItem { get; set; }

        int _number;

        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                transactionType.Text = targetItem.Name;
                number.Text = targetItem.Prefix.ToUpper() + _number.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isPrio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            using (var w = new QueeuingEntities())
            {
                //var item = w.Items.FirstOrDefault(x => x.Id == id);
                //var filteredItem = w.Ques.Where(x => x.ItemId == item.Id).OrderByDescending(y => y.Number);

                var qitem = new Que();
                qitem.Item = w.Items.FirstOrDefault(x => x.Id == targetItem.Id);
                qitem.Pending = true;
                qitem.Number = Number;
                qitem.Priority = isPrio.Checked;

                w.Ques.Add(qitem);
                w.SaveChanges();

                RNumber = qitem.Item.Prefix + qitem.Number + (isPrio.Checked ? "P" : "");
                RCategory = qitem.Item.Name;
            }
            ///Print number
            document.Print();
            this.Close();
        }
        string RNumber, RCategory;

        private void isPrio_CheckedChanged_1(object sender, EventArgs e)
        {
            Console.WriteLine(isPrio.Checked);
            if (isPrio.Checked)
            {
                number.Text += "P";
            }
            else
                number.Text = number.Text.TrimEnd('P');
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintNumber.Print(e, RNumber, RCategory);
        }
    }
}
