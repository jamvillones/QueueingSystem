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
    public partial class TicketConfirmationForm : Form
    {
        public TicketConfirmationForm()
        {
            InitializeComponent();
        }

        public Transaction targetTransaction { get; set; }

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
                transactionType.Text = targetTransaction.Name;
                number.Text = targetTransaction.Prefix.ToUpper() + _number.ToString();
            }
        }

        //public 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void isPrio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                var newQue = new Que();
                newQue.TransactionId = targetTransaction.Id;
                newQue.Priority = isPrio.Checked;
                newQue.Status = 0;
                newQue.TicketCode = number.Text;

                var t = q.Transactions.FirstOrDefault(x => x.Id == targetTransaction.Id);
                t.CurrentNumber = Number;

                q.Ques.Add(newQue);
                q.SaveChanges();

                RNumber = newQue.TicketCode;
                RCategory = newQue.Transaction.Name;

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
