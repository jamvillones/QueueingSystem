using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Threading;
using System.ComponentModel;

namespace QueServer
{
    public static class SpeechManager
    {
        static Queue<String> speeches = new Queue<string>();
        public static event EventHandler<bool> OnSpeechPlaying;
        static Thread t;

        static public void AddMessages(string message)
        {
            speeches.Enqueue(message);

            if (t == null)
            {
                t = new Thread(new ThreadStart(PlayMessages));
                t.Start();
            }
        }

        static void PlayMessages()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.SetOutputToDefaultAudioDevice();

                OnSpeechPlaying?.Invoke(null,true);

                while (speeches.Count != 0)
                {
                    string nextMessage = speeches.Dequeue();

                    Prompt text = new Prompt(nextMessage);

                    synth.Speak(text);
                }

                OnSpeechPlaying?.Invoke(null, false);
            }

            t = null;
        }
    }
}
