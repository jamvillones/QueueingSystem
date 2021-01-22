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
    public partial class CreateTransaction : Form
    {
        public event EventHandler OnSave;

        public CreateTransaction()
        {
            InitializeComponent();
        }
        bool changesMade = false;
        private void button1_Click(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                var t = new Transaction();
                t.Name = nameTxt.Text.Trim();
                t.Prefix = prefTxt.Text.Trim();
                t.Details = detTxt.Text.Trim();
                t.CurrentNumber = 0;

                q.Transactions.Add(t);
                q.SaveChanges();
            }
            ClearTextBoxes();
            changesMade = true;
        }
        void ClearTextBoxes()
        {
            var texts = this.Controls.Cast<Control>();
            foreach (var i in texts)
            {
                if (i is TextBox)
                    ((TextBox)i).Clear();
            }
        }

        private void CreateTransaction_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(changesMade)
            OnSave?.Invoke(this, null);
        }
    }
}
