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
    public partial class MediaPlayerButtons : UserControl
    {
        public enum MediaCommandTypes { play, previous, next, stop}

        public event EventHandler<MediaCommandTypes> OnCommandIssued;
        public MediaPlayerButtons()
        {
            InitializeComponent();
        }
        //bool isPlaying = true;
        //public bool IsPlaying
        //{
        //    get
        //    {
        //        return isPlaying;
        //    }
        //    set
        //    {
        //        isPlaying = value;
        //        if (isPlaying)
        //        {
        //            button4.Image = Properties.Resources.pause_30px;
        //        }
        //        else
        //        {
        //            button4.Image = Properties.Resources.play_30px;
        //        }
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            OnCommandIssued?.Invoke(this, MediaCommandTypes.previous);
        }

        private void button4_Click(object sender, EventArgs e)
        {


            OnCommandIssued?.Invoke(this, MediaCommandTypes.play);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OnCommandIssued?.Invoke(this, MediaCommandTypes.next);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OnCommandIssued?.Invoke(this, MediaCommandTypes.stop);
        }
    }
}
