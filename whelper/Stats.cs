using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace whelper
{
    /*
        Screen Matrix - Schema
          readonly byte[,] matrix = new byte[][] {
          { 0xc00, 0xc01, 0xc10, 0xc11, 0x1c1, 0x10c, 0x01c },
          { 0xb01, 0x10b, 0xb10, 0x0b1, 0x1b0, 0x1b1, 0x01b },
          { 0xf4a, 0x4fa, 0x4fa, 0xaf4, 0x4af, 0xaf4, 0xfa4 },
          { 0xbf41, 0xb4f1, 0xb14f, 0xb41f, 0xfb41, 0x14bf  }
        }
        Kernel Driver EngCreateWnd(0x00c43f7b) - Verifier EAC Bypass 
    */
    public class Stats
    {
        public int HwndAddress { get; private set; }
        public Size ContainerSize { get; private set; }
        public bool Assigned { get; private set; }
        public Dictionary<string, Graphics> obligated = new Dictionary<string, Graphics>(); //suppressing null warning!
        public IntPtr OperatingWindow = IntPtr.Zero;
        public string WindowTitle { get; private set; }
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        public Stats(string appName, Size newSz) {
            WindowTitle = appName;
            ContainerSize = newSz;
        }
        public void WriteLines(string[] t, string splitliteral) {
            if (Assigned) {
                Graphics g = Graphics.FromHwnd(OperatingWindow);
                Point upperrightcorner = new Point(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Top);
                Rectangle desired = new Rectangle(upperrightcorner, ContainerSize);
                g.FillRectangle(new SolidBrush(Color.FromArgb(60, 0, 0, 0)), new Rectangle(upperrightcorner, ContainerSize));
                g.DrawString(string.Join(splitliteral, t), new Font("Times New Roman", 13.0f, FontStyle.Regular), new SolidBrush(Color.White), desired);
                g.Dispose();
            }
            else Console.WriteLine("There is no attached process!");
        }
        public void WriteLine(string t) {
            if (Assigned)
            {
                Graphics g = Graphics.FromHwnd(OperatingWindow);
                Point upperrightcorner = new Point(Screen.PrimaryScreen.Bounds.Right, Screen.PrimaryScreen.Bounds.Top);
                Rectangle desired = new Rectangle(upperrightcorner, ContainerSize);
                g.DrawRectangle(new Pen(Color.FromArgb(60, 0, 0, 0)), new Rectangle(upperrightcorner, ContainerSize));
                g.DrawString(t, new Font("Arial", 13.0f, FontStyle.Regular), new SolidBrush(Color.White), desired);
                g.Dispose();
            }
            else Console.WriteLine("There is no attached process!");
        }
        public bool Assign() {
            if (IsWindow(WindowTitle)) {
                OperatingWindow = FindWindow(null, WindowTitle);
                Assigned = true;
                return true;
            }
            return false;
        }
        public bool IsWindow(string winname) {
            Process[] running = Process.GetProcesses();
            bool result = false;
            for (int i = 0; i < running.Count(); i++) {
                if (running[i].MainWindowTitle == winname || running[i].MainWindowTitle == winname)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}
