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
        public VideoOptions()
        {
            InitializeComponent();
        }

        public event EventHandler<string[]> OnTopVideoSelected;
        public event EventHandler<string[]> OnBotVideoSelected;
        public event EventHandler<int> OnTopVolumeChanged;
        public event EventHandler<int> OnBotVolumeChanged;

        private void VideoOptions_Load(object sender, EventArgs e)
        {
            var settings = Properties.Settings.Default;
            normalVol.Value = settings.NormalVolume;
            speechVol.Value = settings.TalkingVolume;
            bottomVol.Value = settings.BottomVolume;

        }
        Properties.Settings settings = Properties.Settings.Default;
        private void normalVol_Scroll(object sender, EventArgs e)
        {
            //var settings = Properties.Settings.Default;
            settings.NormalVolume = normalVol.Value;
            settings.Save();

            OnTopVolumeChanged?.Invoke(this, normalVol.Value);
        }

        private void speechVol_Scroll(object sender, EventArgs e)
        {
            //var settings = Properties.Settings.Default;
            settings.TalkingVolume = speechVol.Value;
            settings.Save();


        }

        private void bottomVol_Scroll(object sender, EventArgs e)
        {
            //var settings = Properties.Settings.Default;
            settings.BottomVolume = bottomVol.Value;
            settings.Save();

            OnBotVolumeChanged?.Invoke(this, bottomVol.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OnTopVideoSelected?.Invoke(this, dialog.FileNames);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OnBotVideoSelected?.Invoke(this, dialog.FileNames);
            }
        }
    }
}
