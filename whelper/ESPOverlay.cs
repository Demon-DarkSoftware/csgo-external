using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace whelper
{
    /// <summary>
    /// Rectangle struct!
    /// </summary>
    public struct RECT {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
    public partial class ESPOverlay : Form
    {
        public Size SizeWin { get; private set; }
        public Point StartLocation { get; private set; }
        public string TargettedWindow = "Counter-Strike Global Offensive";
        private RECT WindowRect;
        private Rectangle StaticsRect = new Rectangle();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public ESPOverlay()
        {
            InitializeComponent();
        }

        private void ESPOverlay_Load(object sender, EventArgs e)
        {
            IntPtr gameHandle = FindWindow(null, TargettedWindow);
            GetWindowRect(gameHandle, out WindowRect);
            SizeWin = new Size(WindowRect.Right - WindowRect.Left, WindowRect.Bottom - WindowRect.Top);
            this.TransparencyKey = Color.Gray;
            this.Size = SizeWin;
            this.Top = WindowRect.Top;
            this.Left = WindowRect.Left;
            this.DoubleBuffered = true;
            int iStyle = GetWindowLong(Handle, -20);
            SetWindowLong(Handle, -20, iStyle | 0x80000 | 0x20);

        }
    }
}
