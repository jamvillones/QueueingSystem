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

namespace QueCounter
{
    public partial class ShowNumbersForm : Form
    {
        public ShowNumbersForm()
        {
            InitializeComponent();
        }

        private void ShowNumbersForm_Load(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                fillTable(q.Ques.Where(x => x.Status == 0));
            }
        }
        void fillTable(IQueryable<Que> numbers)
        {
            dataGridView1.Rows.Clear();
            foreach (var i in numbers)
            {
                dataGridView1.Rows.Add(i.Id,
                                       i.TicketCode,
                                       i.Transaction.Name,
                                       i.Priority);
            }
        }
    }
}
