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
    public partial class DefaultServerAddressForm : Form
    {
        public DefaultServerAddressForm()
        {
            InitializeComponent();
        }

        private void DefaultServerAddressForm_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.ServerIp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change host Address?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            Properties.Settings.Default.ServerIp = textBox1.Text;
            Properties.Settings.Default.Save();
        }
    }
}
