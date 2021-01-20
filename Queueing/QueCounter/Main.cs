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

        Item targetItem { get; set; }

        int counterNum;

        private void Main_Load(object sender, EventArgs e)
        {
            counterNum = AppStartup.CounterNumber;
            this.Text = "COUNTER: " + counterNum;

            using (var q = new QueeuingEntities())
            {
                transactionType.Items.AddRange(q.Items.Select(x => x.Name).ToArray());

                var c = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);
                targetItem = c.Item;

                counterNumber.Text = c.CounterNumber.ToString();
                counterNum = c.CounterNumber;
                transactionType.Text = c.Item.Name;
                currentNumber.Text = c.Que == null ? "--" : c.Que.Item.Prefix.ToUpper() + c.Que.Number;
            }

            //worker.RunWorkerAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                var counter = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);

                // var numbers = q.Ques.Where(x => x.Item.Id == targetItem.Id && x.Pending == true);
                IQueryable<Que> numbers = null;
                if (checkBox1.Checked)
                {
                    numbers = q.Ques.Where(x => x.Item.Id == targetItem.Id && x.Pending == true && x.Priority);
                    if (numbers.Count() == 0)
                        numbers = q.Ques.Where(x => x.Item.Id == targetItem.Id && x.Pending == true);
                }
                else
                    numbers = q.Ques.Where(x => x.Item.Id == targetItem.Id && x.Pending == true);

                if (numbers.Count() == 0)
                {
                    counter.CurrentNumber = null;
                    q.SaveChanges();

                    currentNumber.Text = "--";
                    //sendNotif(counterNum.ToString());
                    worker.RunWorkerAsync();

                    MessageBox.Show("Numbers for this particular transaction is depleted. Choose other transactions.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Que next = numbers.First();

                counter.Que = next;
                counter.Que.Pending = false;
                q.SaveChanges();

                currentNumber.Text = counter.Que.Item.Prefix.ToUpper() + counter.Que.Number + (counter.Que.Priority ? "P" : "");

                //sendNotif(counterNum.ToString());
                worker.RunWorkerAsync();
            }
        }

        private void transactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var q = new QueeuingEntities())
            {
                targetItem = q.Items.FirstOrDefault(x => x.Name == transactionType.Text);
                var c = q.Counters.FirstOrDefault(x => x.CounterNumber == counterNum);
                c.Item = targetItem;
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
                client.Connect("127.0.0.1", port);

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
            worker.RunWorkerAsync();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control&&e.Shift&&e.KeyCode == Keys.I)
            {
                using (var d = new DefaultServerAddressForm())
                    d.ShowDialog();
            }
        }
    }
}
