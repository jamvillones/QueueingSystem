using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueServer
{
    public partial class CounterToken : UserControl
    {
        public CounterToken()
        {
            InitializeComponent();
        }

        int counter;

        public int Counter
        {
            get
            {
                return counter;
            }

            set
            {
                counter = value;
                counterLabel.Text = "COUNTER " + value;
            }
        }

        public string Number
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    if (numberLabel.InvokeRequired)
                    {
                        numberLabel.Invoke((MethodInvoker)delegate
                        {
                            numberLabel.Text = "--";
                        });

                    }
                    else
                        numberLabel.Text = "--";
                    return;
                }
                if (numberLabel.InvokeRequired)
                {
                    numberLabel.Invoke((MethodInvoker)delegate
                    {
                        numberLabel.Text = value;
                    });

                }
                else
                    numberLabel.Text = value;
            }
        }
    }
}
