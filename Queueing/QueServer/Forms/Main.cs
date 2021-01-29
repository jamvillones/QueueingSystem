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
            InitVideo();

            populateTokens();
            backgroundWorker1.RunWorkerAsync();
            SpeechManager.OnSpeechPlaying += SpeechManager_OnSpeechPlaying;
        }

        void InitVideo()
        {
            videoPlayerTop.uiMode = "none";
            videoPlayerTop.settings.setMode("loop", true);
            videoPlayerTop.settings.volume = settings.NormalVolume;

            videoPlayerBottom.uiMode = "none";
            videoPlayerBottom.settings.setMode("loop", true);
            videoPlayerBottom.settings.volume = settings.BottomVolume;

        }
        Properties.Settings settings = Properties.Settings.Default;

        private void SpeechManager_OnSpeechPlaying(object sender, bool e)
        {
            //throw new NotImplementedException();
            if (e)
                videoPlayerTop.settings.volume = settings.TalkingVolume;

            else
                videoPlayerTop.settings.volume = settings.NormalVolume;

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
                        token.Number = "--";
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

            string localIp = null;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                }
            }

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

            videoPlayerTop.Ctlcontrols.stop();
            videoPlayerTop.Dispose();

            videoPlayerBottom.Ctlcontrols.stop();
            videoPlayerBottom.Dispose();

            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openServerDefaults();
        }

        void openServerDefaults()
        {

        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift && e.KeyCode == Keys.I)
            {
                openServerDefaults();
            }
            if (e.Control && e.KeyCode == Keys.Right)
            {
                videoPlayerTop.Ctlcontrols.next();
            }
            if (e.Control && e.KeyCode == Keys.Left)
            {
                videoPlayerTop.Ctlcontrols.previous();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            //if (ofdVideos.ShowDialog() == DialogResult.OK)
            //{
            //    if (videoPlayerTop.currentPlaylist != null)
            //    {
            //        videoPlayerTop.currentPlaylist.clear();
            //    }
            //    WMPLib.IWMPPlaylist playlist = videoPlayerTop.playlistCollection.newPlaylist("myplaylist");
            //    WMPLib.IWMPMedia media;
            //    foreach (string file in ofdVideos.FileNames)
            //    {
            //        media = videoPlayerTop.newMedia(file);
            //        playlist.appendItem(media);
            //    }

            //    videoPlayerTop.currentPlaylist = playlist;
            //    videoPlayerTop.Ctlcontrols.play();
            //}
            using (var v = new QueServer.Forms.VideoOptions())
            {
                v.OnBotVideoSelected += V_OnBotVideoSelected;
                v.OnTopVideoSelected += V_OnTopVideoSelected;
                v.OnTopVolumeChanged += V_OnTopVolumeChanged;
                v.OnBotVolumeChanged += V_OnBotVolumeChanged;
                v.ShowDialog();
            }
        }

        private void V_OnBotVolumeChanged(object sender, int e)
        {
            //throw new NotImplementedException();
            videoPlayerBottom.settings.volume = e;
        }

        private void V_OnTopVolumeChanged(object sender, int e)
        {
            videoPlayerTop.settings.volume = e;
        }

        private void V_OnTopVideoSelected(object sender, string[] e)
        {
            //throw new NotImplementedException();
            if (videoPlayerTop.currentPlaylist != null)
            {
                videoPlayerTop.currentPlaylist.clear();
            }

            WMPLib.IWMPPlaylist playlist = videoPlayerTop.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            foreach (string file in e)
            {
                media = videoPlayerTop.newMedia(file);
                playlist.appendItem(media);
            }

            videoPlayerTop.currentPlaylist = playlist;
            videoPlayerTop.Ctlcontrols.play();
        }

        private void V_OnBotVideoSelected(object sender, string[] e)
        {
            if (videoPlayerBottom.currentPlaylist != null)
            {
                videoPlayerBottom.currentPlaylist.clear();
            }

            WMPLib.IWMPPlaylist playlist = videoPlayerBottom.playlistCollection.newPlaylist("myplaylist");
            WMPLib.IWMPMedia media;
            foreach (string file in e)
            {
                media = videoPlayerBottom.newMedia(file);
                playlist.appendItem(media);
            }

            videoPlayerBottom.currentPlaylist = playlist;
            videoPlayerBottom.Ctlcontrols.play();
        }

        private void button7_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            var controls = numbersTable.Controls.Cast<CounterToken>().ToArray();

            numbersTable.Controls.Clear();
            populateTokens();

            for (int i = 0; i < controls.Length; i++)
            {
                controls[i].Dispose();
            }
        }
    }
}
