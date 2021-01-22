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
    public partial class PrintFormatPreview : Form
    {
        public PrintFormatPreview()
        {
            InitializeComponent();
        }

        private void document_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            PrintNumber.Print(e,"M007","Lerom Ipsum");
        }
    }
}
