using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queueing
{
    public partial class TicketToken : UserControl
    {
        public TicketToken()
        {
            InitializeComponent();
        }

        public event EventHandler OnSelected;

        private void TicketToken_Load(object sender, EventArgs e)
        {
            transactionName.Click += ClickCallback;
            counterLabel.Click += ClickCallback;
            divider.Click += ClickCallback;
            this.Click += ClickCallback;
        }

        public string Transaction
        {
            get
            {
                return transactionName.Text;
            }
            set
            {
                transactionName.Text = value;
            }
        }
        public string Counters
        {
            get
            {
                return counterLabel.Text;
            }
            set
            {
                counterLabel.Text = value;
            }
        }

        private void ClickCallback(object sender, EventArgs e)
        {
            OnSelected?.Invoke(this, null);
        }
    }
}
