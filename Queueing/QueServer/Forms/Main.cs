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
using QueDatabaseModel;
using QueServer.Forms;

namespace QueServer
{
    public partial class Main : Form
    {
        Properties.Settings settings = Properties.Settings.Default;

        public Main()
        {
            InitializeComponent();
        }

        void InitVideo()
        {
            MediaPlayerTop.uiMode = "none";
            MediaPlayerTop.settings.setMode("loop", true);
            //MediaPlayerTop.settings.volume = settings.NormalVolume;

            MediaPlayerBottom.uiMode = "none";
            MediaPlayerBottom.settings.setMode("loop", true);
            //MediaPlayerBottom.settings.volume = settings.BottomVolume;
        }

        /// <summary>
        /// processes the messages relayed by clients
        /// </summary>
        /// <param name="n"></param>
        void processNotification(string n)
        {
            int nc;

            if (int.TryParse(n, out nc))
            {
                using (var q = new QueeuingEntities())
                {
                    var counter = q.Counters.FirstOrDefault(x => x.CounterNumber == nc);
                    var token = numbersTable.Controls.Cast<CounterToken>().FirstOrDefault(x => x.Counter == counter.CounterNumber);

                    if (counter.Ques.Any(x => x.Status == 0))
                    {
                        token.Number = "--";
                        return;
                    }

                    var currentNumber = counter.Ques.FirstOrDefault(x => x.Status == 1);
                    token.Number = currentNumber?.TicketCode ?? "--";

                    if (currentNumber != null)
                        SpeechManager.AddMessages("Now serving, " + currentNumber.TicketCode + " at counter " + counter.CounterNumber);
                }
            }
        }

        /// <summary>
        /// instantiates tokens for display
        /// </summary>
        void populateTokens()
        {
            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Counters)
                {
                    ///creates the token
                    var token = new CounterToken();
                    token.Dock = DockStyle.Fill;
                    token.Counter = i.CounterNumber;

                    ///finds the active number corresponding the current counter on the loop
                    var currentNumber = i.Ques.FirstOrDefault(x => x.Status == 1);

                    ///if nothing found put __ for empty number
                    token.Number = currentNumber?.TicketCode ?? "--";
                    ///then add to the table
                    numbersTable.Controls.Add(token);
                }
            }
        }

        /// <summary>
        /// handles the process of accepting connections
        /// </summary>
        void StartAcceptingConnections()
        {
            TcpListener server = null;

            ///this gets the ipv4 address of this computer/server
            string localIp = null;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                }
            }
            ///end

            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse(localIp);
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

        /// <summary>
        /// refreshes controls to track changes 
        /// </summary>
        void refreshControls()
        {
            var controls = numbersTable.Controls.Cast<CounterToken>().ToArray();

            numbersTable.Controls.Clear();
            populateTokens();

            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].Dispose();
            }
        }

        #region Control Callbacks
        private void Main_Load(object sender, EventArgs e)
        {
            InitVideo();

            populateTokens();
            connectionWorker.RunWorkerAsync();
            SpeechManager.OnSpeechPlaying += SpeechManager_OnSpeechPlaying;
        }

        /// <summary>
        /// Callaback for when speech is activated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SpeechManager_OnSpeechPlaying(object sender, bool e)
        {
            if (e)
                MediaPlayerTop.settings.volume = settings.TalkingVolume;

            else
                MediaPlayerTop.settings.volume = settings.NormalVolume;
        }

        private void connectionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            StartAcceptingConnections();
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("h:mm:ss tt  ddd  MMMM dd yyyy").ToUpper();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit this application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            MediaPlayerTop.Ctlcontrols.stop();
            MediaPlayerTop.Dispose();

            MediaPlayerBottom.Ctlcontrols.stop();
            MediaPlayerBottom.Dispose();

            this.Close();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Right)
            {
                MediaPlayerTop.Ctlcontrols.next();
            }
            if (e.Control && e.KeyCode == Keys.Left)
            {
                MediaPlayerTop.Ctlcontrols.previous();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var t = new TransactionList())
            {
                t.OnChangesMade += T_OnChangesMade;
                t.ShowDialog();
            }
        }

        private void T_OnChangesMade(object sender, EventArgs e)
        {
            refreshControls();
        }

        private void settingBtn_Click(object sender, EventArgs e)
        {
            settingsSubPanel.Visible = !settingsSubPanel.Visible;
        }

        private void videoOptBtn_Click(object sender, EventArgs e)
        {
            using (var v = new VideoOptions(MediaPlayerTop, MediaPlayerBottom))
                v.ShowDialog();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want clear the number in Queue and reset all numbers to 1?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;
            using (var q = new QueeuingEntities())
            {
                foreach (var i in q.Transactions)
                    i.CurrentNumber = 0;

                q.Ques.RemoveRange(q.Ques);
                q.SaveChanges();
            }

            var token = numbersTable.Controls.Cast<CounterToken>();
            foreach (var i in token)
                i.Number = "--";
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            refreshControls();
        }
        #endregion
    }
}
