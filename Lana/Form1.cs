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
using System.IO.Ports;

namespace Lana
{
    public partial class Form1 : Form
    {

        SpeechSynthesizer s = new SpeechSynthesizer();
        Boolean wake = true;

        //SerialPort port = new SerialPort("Com3", 9600, Parity.None,8, StopBits.One);

        Choices list = new Choices();

        public Form1()
        {
            SpeechRecognitionEngine rec = new SpeechRecognitionEngine();

            list.Add(new string[] { "hello", "how are you", "computer", "what time is it", "open web", "thank you", "wake", "sleep", "restart", "update", "lights on", "lights off" });
            
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
            textBox1.AppendText(h + "\n");
        }

        private void rec_SpeachRecgnized(object sender, SpeechRecognizedEventArgs e)
        {

            string r = e.Result.Text;
            // sleep/wake doesnt work yet!!!!!!!!!!!

            //if (r == "wake")
            //{
            //    wake = true;
            //    label3.Text = "State: wake";
            //}
            //if (r == "sleep mode")
            //{
            //    wake = false;
            //    label3.Text = "State: sleep";
            //}

            // need arduino to opperate

            //if (r == "lights on")
            //{
            //    port.Open();
            //    port.WriteLine("A");
            //    port.Close();
            //}

            //if (r == "lights off")
            //{
            //    port.Open();
            //    port.WriteLine("B");
            //    port.Close();
            //}

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
            if (r == "computer")
            {

                say("Yes");
            }
            if (r == "what time is it")
            {

                say(DateTime.Now.ToString("h:mm tt"));
            }
            //if (r == "what is today")
            //{

            //    say(DateTime.Now.ToString("m/d/yyyy"));
            //}
            if (r == "open web")
            {

                say("Opening web");
                Process.Start("http://google.com");
            }
            if (r == "thank you")
            {

                say("Your Welcome");
            }
            textBox2.AppendText(r + "\n");
            }
        //}


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }








}
