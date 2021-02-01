using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QueServer.Forms
{
    public partial class VideoOptions : Form
    {
        private AxWindowsMediaPlayer[] players;
        private AxWindowsMediaPlayer currentPlayer
        {
            get
            {
                return players[playerList.SelectedIndex];
            }
        }


        Properties.Settings settings = Properties.Settings.Default;

        public VideoOptions(params AxWindowsMediaPlayer[] p)
        {
            InitializeComponent();
            players = p;
        }

        private void VideoOptions_Load(object sender, EventArgs e)
        {
            if (players.Count() != 0)
            {
                playerList.Items.AddRange(players.Select(x => x.Name).ToArray());
            }
            playerList.SelectedIndex = 0;

            speechVol.Value = settings.TalkingVolume;
        }

        private void playerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            normalVol.Value = currentPlayer.settings.volume;
            //if (currentPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            //    mediaPlayerButtons3.IsPlaying = true;

            //else if (currentPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            //    mediaPlayerButtons3.IsPlaying = false;
        }

        private void speechVol_Scroll(object sender, EventArgs e)
        {
            var v = sender as TrackBar;
            settings.TalkingVolume = v.Value;
            settings.Save();
        }

        private void normalVol_Scroll(object sender, EventArgs e)
        {
            var v = sender as TrackBar;
            currentPlayer.settings.volume = v.Value;

            if (playerList.SelectedIndex == 0)
            {
                settings.TopVolume = v.Value;
            }
            else
            {
                settings.BottomVolume = v.Value;
            }
            settings.Save();
        }

        private void selectVideosBtn_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (currentPlayer.currentPlaylist != null)
                    currentPlayer.currentPlaylist.clear();

                WMPLib.IWMPPlaylist playlist = currentPlayer.playlistCollection.newPlaylist("myplaylist");
                WMPLib.IWMPMedia media;

                foreach (string file in dialog.FileNames)
                {
                    media = currentPlayer.newMedia(file);
                    playlist.appendItem(media);
                }

                currentPlayer.currentPlaylist = playlist;
                currentPlayer.Ctlcontrols.play();
            }
        }

        private void mediaPlayerButtons_OnCommandIssued(object sender, MediaPlayerButtons.MediaCommandTypes e)
        {
            var c = sender as MediaPlayerButtons;

            switch (e)
            {
                case MediaPlayerButtons.MediaCommandTypes.play:
                    if (currentPlayer.playState == WMPLib.WMPPlayState.wmppsPaused || currentPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
                        currentPlayer.Ctlcontrols.play();
                    else if (currentPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
                        currentPlayer.Ctlcontrols.pause();
                    break;
                case MediaPlayerButtons.MediaCommandTypes.previous:
                    currentPlayer.Ctlcontrols.previous();
                    break;
                case MediaPlayerButtons.MediaCommandTypes.next:
                    currentPlayer.Ctlcontrols.next();
                    break;
                case MediaPlayerButtons.MediaCommandTypes.stop:
                    currentPlayer.Ctlcontrols.stop();
                    break;
                default:
                    break;
            }
        }
    }
}
