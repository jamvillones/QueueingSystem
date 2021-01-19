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

        //static bool active;
        static Thread t;

        static public void AddMessages(string message)
        {

            speeches.Enqueue(message);

            if (t == null)
            {
                Console.WriteLine("t");
                //t = new Thread(new ThreadStart(PlayMessages));
                t = new Thread(new ThreadStart(PlayMessages));
                t.Name = "voice_thread";
                t.Start();
                ////PlayMessages();
            }
        }

        static void PlayMessages()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                synth.SetOutputToDefaultAudioDevice();

                while (speeches.Count != 0)
                {
                    string c = speeches.Dequeue();

                    Prompt text = new Prompt("Now serving, " + c);
                    //Speak the contents of the prompt synchronously.
                    synth.Speak(text);
                    Console.WriteLine(Thread.CurrentThread.Name);
                }
            }

            t = null;
        }
    }
}
