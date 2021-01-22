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

namespace QueServer
{
    public partial class TransactionList : Form
    {
        public TransactionList()
        {
            InitializeComponent();
        }

        private void TransactionList_Load(object sender, EventArgs e)
        {
            LoadValues();
        }
        void LoadValues()
        {
            transactionsTable.Rows.Clear();

            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Transactions)
                {
                    transactionsTable.Rows.Add(i.Id,
                                               i.Name,
                                               i.Prefix,
                                               i.Details,
                                               "Delete");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var c = new CreateTransaction())
            {
                c.OnSave += (a, b) => { LoadValues(); };
                c.ShowDialog();
            }
        }
    }
}
