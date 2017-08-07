using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Diagnostics;

namespace Lana
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer s = new SpeechSynthesizer();
        Choices list = new Choices();

        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new string[] { "hello", "how are you", "lana", "what time is it", "open web", "thank you", "wake", "sleep mode", "restart", "update" });

            Grammar gr = new Grammar(new GrammarBuilder(list));

            try
            {
                rec.RequestRecognizerUpdate();
                rec.LoadGrammar(gr);
                rec.SpeechRecognized += rec_SpeachRecgnized;
                rec.SetInputToDefaultAudioDevice();
                rec.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch
            {
                return;
            }

            s.SelectVoiceByHints(VoiceGender.Female);

            s.Speak("Hello Lou");

            InitializeComponent();
        }

        public void restart()
        {
            Process.Start(@"C:\Users\LanaBot\Lana");
        }

        public void say(string h)
        {
            s.Speak(h);
        }

        private void rec_SpeachRecgnized(object sender, SpeechRecognizedEventArgs e)
        {

            string r = e.Result.Text;
            // sleep/wake doesnt work yet!!!!!!!!!!!
            //Boolean wake = true;

            //if (r == "wake") wake = true;
            //if (r == "sleep mode") wake = false;

            //if (wake == true)
            //{
            if (r == "restart" || r == "update")
            {
                restart();
            }

            // what i say
            if (r == "hello")
            {
                //what it should say
                say("Sup");
            }
            if (r == "how are you")
            {

                say("Awesome");
            }
            if (r == "lana")
            {

                say("Yes");
            }
            if (r == "what time is it")
            {

                say(DateTime.Now.ToString("h:mm tt"));
            }
            if (r == "open web")
            {

                say("Opening web");
                Process.Start("http://google.com");
            }
            if (r == "thank you")
            {

                say("Your Welcome");
            }
            // }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }








}
