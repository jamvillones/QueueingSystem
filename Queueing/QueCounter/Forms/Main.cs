using QueDatabaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueCounter
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        IntPtr SC_MAX = new IntPtr(0xF030);
        IntPtr SC_NORMAL = new IntPtr(0xF120);
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                if (m.WParam == SC_MAX) // Maximize event - SC_MAXIMIZE from Winuser.h
                {
                    Console.WriteLine("maximize");
                    Properties.Settings.Default.WindowsState = true;
                    Properties.Settings.Default.Save();
                }
                else if (m.WParam == SC_NORMAL)
                {
                    Console.WriteLine("minimize");
                    Properties.Settings.Default.WindowsState = false;
                    Properties.Settings.Default.Save();
                }
            }
            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                var counter = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);
                q.Counters.Remove(counter);
                q.SaveChanges();
            }
            this.Close();
        }

        Transaction targetItem { get; set; }
        Counter targetCounter { get; set; }
        int counterNum;

        private void Main_Load(object sender, EventArgs e)
        {
            WindowState = Properties.Settings.Default.WindowsState ? FormWindowState.Maximized : FormWindowState.Normal;
            checkBox2.Checked = Properties.Settings.Default.AutoHide;

            counterNum = AppStartup.CounterNumber;
            this.Text = "COUNTER: " + counterNum;

            using (var q = new QueeuingEntities())
            {
                transactionType.Items.AddRange(q.Transactions.Select(x => x.Name).ToArray());

                var c = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);
                targetCounter = c;
                targetItem = c.Transaction;

                counterNumber.Text = c.CounterNumber.ToString();
                counterNum = c.CounterNumber;
                transactionType.Text = c.Transaction.Name;
                var num = c.Ques.FirstOrDefault(x => x.Status == 1);
                currentNumberTxt.Text = num?.TicketCode ?? "--";

                currentNumber = num;
            }
        }

        Que currentNumber = null;

        private void nextNumber_Click(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                var counter = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);

                if (currentNumber != null)
                {
                    Console.WriteLine("remove");
                    var cnum = q.Ques?.FirstOrDefault(x => x.Id == currentNumber.Id);
                    if (cnum != null)
                    {
                        cnum.Status = 2;
                    }
                }

                IQueryable<Que> numbers = null;

                if (checkBox1.Checked)
                {
                    numbers = q.Ques.Where(x => x.Transaction.Id == targetItem.Id && x.Status == 0 && x.Priority);
                    if (numbers.Count() == 0)
                        numbers = q.Ques.Where(x => x.Transaction.Id == targetItem.Id && x.Status == 0);
                }
                else
                    numbers = q.Ques.Where(x => x.Transaction.Id == targetItem.Id && x.Status == 0);

                if (numbers.Count() == 0)
                {
                    q.SaveChanges();
                    currentNumberTxt.Text = "--";
                    sendMessage();
                    MessageBox.Show("Numbers for this particular transaction is depleted. Choose other transactions.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Que next = numbers.First();
                currentNumber = next;
                next.Counter = counter;
                next.Status = 1;

                q.SaveChanges();

                currentNumberTxt.Text = next.TicketCode;
                sendMessage();
            }

            if (checkBox2.Checked)
                WindowState = FormWindowState.Minimized;
        }
        void sendMessage()
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync();
        }

        private void transactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                targetItem = q.Transactions.FirstOrDefault(x => x.Name == transactionType.Text);
                var c = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);
                c.Transaction = targetItem;
                q.SaveChanges();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var numList = new ShowNumbersForm())
                numList.ShowDialog();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        Int32 port = 13000;
        void sendNotif(string message)
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect(Properties.Settings.Default.ServerIp, port);

                NetworkStream stream;
                // Translate the passed message into ASCII and store it as a Byte array.
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

                // Get a client stream for reading and writing.
                //  Stream stream = client.GetStream();

                stream = client.GetStream();

                // Send the message to the connected TcpServer.
                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: {0}", message);

                // Receive the TcpServer.response.

                // Buffer to store the response bytes.
                data = new Byte[256];

                // String to store the response ASCII representation.
                String responseData = String.Empty;

                // Read the first batch of the TcpServer response bytes.
                Int32 bytes = stream.Read(data, 0, data.Length);
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                //// Close everything.
                stream.Close();
                //client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            sendNotif(counterNum.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
                worker.RunWorkerAsync();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.I)
            {
                using (var d = new ServerDefaults())
                    d.ShowDialog();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoHide = checkBox2.Checked;
            Properties.Settings.Default.Save();
        }

        private void skip_Click(object sender, EventArgs e)
        {
            if (currentNumber == null)
                return;

            using (var q = new QueeuingEntities())
            {
                var n = q.Ques.FirstOrDefault(x => x.Id == currentNumber.Id);
                n.Status = (int)NumberStatus.skipped;
                q.SaveChanges();
            }
            currentNumberTxt.Text = "--";
            currentNumber = null;
            sendMessage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (var skipped = new SkippedNumbers())
            {                
                skipped.CounterId = targetCounter.Id;
                skipped.SkipSelect += Skipped_SkipSelect;               
                //skipped.Parent = this;
                skipped.ShowDialog(this);
            }
        }

        private void Skipped_SkipSelect(object sender, int e)
        {
            //throw new NotImplementedException();
            using (var q = new QueeuingEntities())
            {
                if (currentNumber != null)
                {
                    var c = q.Ques.FirstOrDefault(x => x.Id == currentNumber.Id);
                    c.Status = (int)NumberStatus.done;
                }
                var skipped = q.Ques.FirstOrDefault(x => x.Id == e);
                currentNumber = skipped;
                currentNumberTxt.Text = skipped.TicketCode;
                skipped.Status = (int)NumberStatus.active;

                sendMessage();
                q.SaveChanges();

            }
        }
    }
}
