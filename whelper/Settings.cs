using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using dwimI64;

namespace whelper
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            
        }
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        public bool IsHelperOn { get; private set; }
        public Keys ToggleKey { get; private set; }
        public Dictionary<Keys, Func<bool>> hotkeysFunc = new Dictionary<Keys, Func<bool>>();
       // public Items Instance { get; private set; }
        public bool TriggerOn { get; private set; }
        public bool GlowEspOn { get; private set; }
        public bool BunnyOn { get; private set; }
        public bool RadarEspOn { get; private set; }
        private Thread Trigger;
        private Thread Glow;
        private Thread Bunny;
        private Thread NoRc;
        public bool tonce = false;
        public bool gonce = false;
        public bool bonce = false;
        public bool nonce = false;
        public bool shown = false;
        private Thread key;
        private Thread func;
        private float factor;
        //  static Program Logger ;
        private void Settings_Load(object sender, EventArgs e)
        {
            Trigger = new Thread(Program.LaunchTrigger);
            Glow = new Thread(Program.LaunchGlow);
            Bunny = new Thread(Program.LaunchBunny);
            
            func = new Thread(OnOffCheck);
            NoRc = new Thread(Program.LaunchNoRec);
            key = new Thread(KeyCheck);
            key.Start();
            this.TopMost = true;
            //func.Start();
        }

       
        public void Valid() {
            if (TriggerOn && !tonce) { Trigger.Start(); tonce = true; }
            else if (!TriggerOn && tonce) Trigger.Interrupt(); 
            if (GlowEspOn && !gonce) { Glow.Start(); gonce = true; }
            else if (!GlowEspOn && gonce) Glow.Interrupt();
            if (BunnyOn && !bonce) { Bunny.Start(); bonce = true; }
            else if (!BunnyOn && bonce) Bunny.Interrupt();
        }
        private void OnOffCheck() {
            while (!TriggerOn) if(tonce) Trigger.Join();
            while (!GlowEspOn) if(gonce) Glow.Join();
            while (!BunnyOn) if(bonce) Bunny.Join();
        }
        private void KeyCheck() {
            while (true)
            {
                while (GetAsyncKeyState(Keys.NumPad1) != 0)
                {
                    if (!TriggerOn && !tonce)
                    {
                        
                        
                        bunifuiOSSwitch1.Value = true;
                        Console.Beep(412, 10);
                    }
                    else if (TriggerOn && tonce)
                    {
                        
                        bunifuiOSSwitch1.Value = false;
                        Console.Beep(412, 10);
                    }
                    else if (!TriggerOn && tonce)
                    {
                        bunifuiOSSwitch1.Value = true;
                    }

                }
                while (GetAsyncKeyState(Keys.NumPad2) != 0)
                {
                    if (!GlowEspOn && !gonce)
                    {


                        bunifuiOSSwitch2.Value = true;
                        Console.Beep(412, 10);
                    }
                    else if (GlowEspOn && gonce)
                    {

                        bunifuiOSSwitch2.Value = false;
                        Console.Beep(412, 10);
                    }
                    else if (!GlowEspOn && gonce)
                    {
                        bunifuiOSSwitch2.Value = true;
                    }

                }
                while (GetAsyncKeyState(Keys.NumPad3) != 0)
                {
                    if (!BunnyOn && !bonce)
                    {
                       
                        bunifuiOSSwitch3.Value = true;
                        Console.Beep(412, 10);
                    }
                    else if (BunnyOn && bonce)
                    {
                        BunnyOn = false;
                        bunifuiOSSwitch3.Value = false;
                        Console.Beep(412, 10);


                    }
                    else if (!BunnyOn && bonce)
                    {
                        bunifuiOSSwitch3.Value = true;
                    }

                }
                while (GetAsyncKeyState(Keys.NumPad4) != 0)
                {
                    if (!RadarEspOn && !nonce)
                    {
                      
                        
                        bunifuiOSSwitch4.Value = true;
                        Console.Beep(412, 10);
                    }
                    else if (RadarEspOn && nonce)
                    {
                        
                        bunifuiOSSwitch4.Value = false;
                        Console.Beep(412, 10);
                    }
                    else if (!RadarEspOn && nonce)
                    {
                        bunifuiOSSwitch4.Value = true;
                    }

                }
            }
        }
        private void BunifuiOSSwitch1_OnValueChange(object sender, EventArgs e)
        {
            TriggerOn = bunifuiOSSwitch1.Value;
            
            if (TriggerOn && !tonce)
            {
                Trigger.Start();
                tonce = true;
            }
            else if (TriggerOn && tonce)
            {
                Trigger.Resume();
            }
            else if (!TriggerOn && tonce) {
                Trigger.Suspend();
            }
            

        }

        private void BunifuiOSSwitch2_OnValueChange(object sender, EventArgs e)
        {
            GlowEspOn = bunifuiOSSwitch2.Value;
            
            if (GlowEspOn && !gonce)
            {
                Glow.Start();
                gonce = true;
            }
            else if (GlowEspOn && gonce)
            {
                Glow.Resume();
            }
            else if (!GlowEspOn && gonce)
            {
                Glow.Suspend();
            }
            
        }

        private void BunifuiOSSwitch3_OnValueChange(object sender, EventArgs e)
        {
            BunnyOn = bunifuiOSSwitch3.Value;
            
            if (BunnyOn && !bonce)
            {
                Bunny.Start();
                bonce = true;
            }
            else if (BunnyOn && bonce)
            {
                Bunny.Resume();
            }
            else if (!BunnyOn && bonce)
            {
                Bunny.Suspend();
            }
            
        }

        private void BunifuiOSSwitch4_OnValueChange(object sender, EventArgs e)
        {
            RadarEspOn = bunifuiOSSwitch4.Value;
            
            if (RadarEspOn && !nonce)
            {
                NoRc.Start();
                nonce = true;
            }
            else if (RadarEspOn && nonce)
            {
                NoRc.Resume();
            }
            else if (!RadarEspOn && nonce)
            {
                NoRc.Suspend();
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            /* Dll d = Dll.GetInstance;
             CodeResult c = d.Inject(Program.m.Current.ProcessName, Directory.GetCurrentDirectory() + @"\schanger\nSkinz.dll");
             if (c == CodeResult.Failed)
             {
                 Console.WriteLine("Failed injecting dll.");
             }
             else if (c == CodeResult.FileNotFound) Console.WriteLine("File not found!");
             else if (c == CodeResult.ProcessNotFound) Console.WriteLine("Invalid process");
             else if (c == CodeResult.Success) Console.WriteLine("Injected press INSERT in game!");*/
            dwimI64.Dll d = new dwimI64.Dll(Directory.GetCurrentDirectory() + @"\schanger\nSkinz.dll", "csgo");
            if (!d.Inject()) Console.WriteLine("Injecting failed!");
            else Console.WriteLine("Injected!");
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.Red;
            colorDialog1.ShowHelp = true;
            colorDialog1.AllowFullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.OK) {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }
        private void BunifuSlider1_ValueChanged(object sender, EventArgs e)
        {
            
        }
       

        private void Button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.BackColor == Color.Red || pictureBox1.BackColor == SystemColors.Control) return;
            else
            {
                Program.ChangeGlowColor(pictureBox1.BackColor); Console.WriteLine("Informatzuy dlya chita obnovlena uspeshno!");
            }
        }

        private void Settings_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (KeyValuePair<Keys, Func<bool>> keys in hotkeysFunc) {
                if (e.KeyCode == keys.Key) keys.Value();
            }
        }
    }
}
