using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QueDatabaseModel;

namespace QueCounter
{
    public partial class SkippedNumbers : Form
    {
        public event EventHandler<int> SkipSelect;
        public SkippedNumbers()
        {
            InitializeComponent();
        }
        private int counterId;
        public int CounterId
        {
            set
            {
                counterId = value;
            }
        }

        private void SkippedNumbers_Load(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                var qs = q.Ques.Where(x => x.CounterId == counterId && x.Status == 3);
                foreach (var i in qs)
                    dataGridView1.Rows.Add(i.Id, i.TicketCode, i.Transaction.Name);
            }

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var queId = (int)(dataGridView1.SelectedCells[0].Value);
            SkipSelect?.Invoke(this, queId);

            this.Close();
        }
    }


}
