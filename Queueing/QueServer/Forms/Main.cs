﻿using System;
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

namespace QueServer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        int playIndex = 0;

        private void Main_Load(object sender, EventArgs e)
        {
            videoPlayer.uiMode = "none";
            videoPlayer.URL = VideoSource.FolderPath + VideoSource.FileNames[playIndex];

            videoPlayer.Ctlcontrols.play();
            videoPlayer.settings.setMode("loop", true);
            //videoPlayer.settings.autoStart = true;        

            listBox1.Items.AddRange(VideoSource.FileNames);

            populateTokens();
            backgroundWorker1.RunWorkerAsync();
        }

        private void VideoPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //Console.WriteLine(e.newState);
            //if (e.newState == 8)
            //{
            //    videoPlayer.URL = VideoSource.FolderPath + VideoSource.FileNames[1];
            //    videoPlayer.Ctlcontrols.play();
            //}
        }

        void processNotification(string n)
        {
            int nc;
            //string number;
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
        int columnCount = 4;

        void populateTokens()
        {
            using (var q = new QueeuingEntities())
            {
                //int counterCount = q.Counters.Count();
                foreach (var i in q.Counters)
                {
                    var token = new CounterToken();
                    token.Dock = DockStyle.Fill;
                    token.Counter = i.CounterNumber;

                    var currentNumber = i.Ques.FirstOrDefault(x => x.Status == 1);

                    token.Number = currentNumber?.TicketCode ?? "--";
                    numbersTable.Controls.Add(token);
                }
            }
        }

        void StartAcceptingConnections()
        {
            TcpListener server = null;

            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse(Properties.Settings.Default.ServerIp);
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
            StartAcceptingConnections();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("h:mm:ss tt  ddd  MMMM dd yyyy").ToUpper();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //toolsSubmenu.Visible = !toolsSubmenu.Visible;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit this application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openServerDefaults();
        }

        void openServerDefaults()
        {
            using (var d = new ServerDefaults())
                d.ShowDialog();
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.I)
            {
                openServerDefaults();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ticketSubmenu.Visible = !ticketSubmenu.Visible;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            using (var t = new TransactionList())
                t.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            settingsSubPanel.Visible = !settingsSubPanel.Visible;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            videoPlayer.URL = VideoSource.FolderPath + VideoSource.FileNames[listBox1.SelectedIndex];
            videoPlayer.Ctlcontrols.play();
        }
    }
}