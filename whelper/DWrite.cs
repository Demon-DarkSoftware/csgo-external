using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
//using D3D = SharpDX.DirectWrite;
//using D2D = SharpDX.Direct2D1;
using SharpDX.Win32;
using SharpDX.Direct3D11;
using SharpDX.Windows;
using SharpDX;
using SharpDX.Direct3D9;

namespace whelper
{
    public enum ObjectToDraw {

    }
    class DWriteText : IDisposable
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern void ReleaseDC(IntPtr hwnd, IntPtr dc);
        const int RDW_INVALIDATE = 0x0001;
        const int RDW_ALLCHILDREN = 0x0080;
        const int RDW_UPDATENOW = 0x0100;
        [DllImport("user32.dll")]
        
        static extern bool RedrawWindow(IntPtr hwnd, IntPtr rcUpdate, IntPtr regionUpdate, int flags);
        public string Current { get; private set; }
        public DWriteText Instance { get; set; }
        public bool Disposed { get; private set; }
        public Graphics UsedResource { get; private set; }
        public IntPtr DesktopPoint { get; private set; }
        public Size DesktopSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        public PointF Location = new PointF(0.0f, 0.0f);
        public SharpDX.Direct3D9.Font text;
        public RenderForm form;
        public SharpDX.Direct3D9.Device devc;
        bool drawn = false;
        bool running = false;
        public DWriteText(string toDraw) {
            Instance = this;
            Current = toDraw;
          /*  form = new RenderForm("Helper!");
            devc = new SharpDX.Direct3D9.Device(new Direct3D(), 0, DeviceType.Hardware, form.Handle, CreateFlags.HardwareVertexProcessing, new PresentParameters(form.Width, form.Height) { PresentationInterval = PresentInterval.One });
            text = new SharpDX.Direct3D9.Font(devc, new FontDescription()
            {
                Height = 72,
                Italic = false,
                CharacterSet = FontCharacterSet.Ansi,
                FaceName = "Arial",
                MipLevels = 0,
                OutputPrecision = FontPrecision.TrueType,
                PitchAndFamily = FontPitchAndFamily.Default,
                Quality = FontQuality.Antialiased,
                Weight = FontWeight.Bold
            });*/
        }
        ~DWriteText() {
            this.Dispose();
        }
        public void Draw(float x, float y) {
            if (x > DesktopSize.Width && y > DesktopSize.Height && x < DesktopSize.Width && y < DesktopSize.Height) return;
            Location = new PointF(x, y);
            IntPtr desk = GetDC(IntPtr.Zero);
            DesktopPoint = desk;
            Graphics g = Graphics.FromHdc(desk);
            UsedResource = g;
            SolidBrush s = new SolidBrush(Color.Green);
           // text.DrawText(null, Current, (int)x, (int)y, new SharpDX.Mathematics.Interop.RawColorBGRA(255, 255, 255, 100));
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Current, new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold), s, Location);
            g.Dispose();
            ReleaseDC(IntPtr.Zero, desk);
            running = true;
            drawn = true;
        }
     public void Draw(float x, float y, float width, float height, Color boxColor)
        {
            if (x > DesktopSize.Width && y > DesktopSize.Height && x < DesktopSize.Width && y < DesktopSize.Height) return;
            Location = new PointF(x, y);
            IntPtr desk = GetDC(IntPtr.Zero);
            DesktopPoint = desk;
            Graphics g = Graphics.FromHdc(desk);
            UsedResource = g;
            RectangleF rect = new RectangleF(new PointF(x, y), new SizeF(width, height));
            g.FillRectangle(new SolidBrush(boxColor), rect);
            SolidBrush s = new SolidBrush(Color.White);
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            g.DrawString(Current, new System.Drawing.Font("Century Gothic", 9, FontStyle.Bold), s, rect);
            g.Dispose();
            ReleaseDC(IntPtr.Zero, desk);
            running = true;
            drawn = true;
        }
        public void Dispose(bool res) {
            if (!Disposed) {
                if (res) {
                    UsedResource = null;
                    DesktopPoint = IntPtr.Zero;
                    DesktopSize = new Size(0, 0);
                    Current = null;
                    Location = new PointF(0.0f, 0.0f);
                    drawn = false;
                    Disposed = true;
                }
            }
            Disposed = true;
        }
      /*  public void Update(string newString) {
            if (!drawn) return;
           
                while (running) {
                    if (!running) break;
                    IntPtr desk = DesktopPoint;
                    DesktopPoint = desk;
                    Graphics g = Graphics.FromHdc(desk);
                    SolidBrush s = new SolidBrush(Color.Red);
                    g.DrawString(newString, new Font("Century Gothic", 10), s, Location);
                    g.Dispose();
                    ReleaseDC(IntPtr.Zero, desk);
                }
            
        }*/

        public void Stop() {
            running = false;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
