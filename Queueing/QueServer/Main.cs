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
using System.Speech.Synthesis;

namespace QueServer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            populateTokens();
            backgroundWorker1.RunWorkerAsync();
        }

        void processNotification(string n)
        {
            int nc;
            string number;
            if (int.TryParse(n, out nc))
            {
                using (var q = new QueeuingEntities())
                {
                    var counter = q.Counters.FirstOrDefault(x => x.CounterNumber == nc);
                    var items = flowLayoutPanel1.Controls.Cast<CounterToken>().FirstOrDefault(x => x.Counter == counter.CounterNumber);
                    if (counter.Que == null)
                    {
                        items.Number = "--";
                        return;
                    }

                    number = counter.Que.Item.Prefix.ToUpper() + counter.Que.Number + (counter.Que.Priority ? "P" : "");
                    items.Number = number;

                }
                SpeechManager.AddMessages(number + " at counter" + nc);
            }
        }

        void populateTokens()
        {
            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Counters)
                {
                    var token = new CounterToken();
                    token.Counter = i.CounterNumber;
                    token.Number = i.Que == null ? "--" : i.Que.Item.Prefix.ToUpper() + i.Que.Number + (i.Que.Priority ? "P" : "");
                    flowLayoutPanel1.Controls.Add(token);
                }
            }
        }

        void setUpServer()
        {
            TcpListener server = null;

            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[256];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    TcpClient client = server.AcceptTcpClient();

                    data = null;
                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        // Process the data sent by the client.
                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);

                        processNotification(data);
                    }

                    // Shutdown and end connection
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            setUpServer();
        }
    }
}
