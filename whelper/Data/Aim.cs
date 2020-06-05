using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using whelper;
namespace whelper.Data
{

    public class Aim
    {
        private Items m;
        private IntPtr moduleAddr;
        private IntPtr engineAddr;
        private int localPlayer;
        private int localPlayerTeam;
        private float mouseSensitivity;
        private int flags;
        private const int entityOffset = 0x10;
        private bool toggle = !true;
        private int engineState = 0x00;
        public bool Toggle { get; set; }
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        public enum MouseEventFlags : uint
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010,
            WHEEL = 0x00000800,
            XDOWN = 0x00000080,
            XUP = 0x00000100
        }
        public enum MouseEventDataXButtons : uint
        {
            XBUTTON1 = 0x00000001,
            XBUTTON2 = 0x00000002
        }
        public static PointF Center = new PointF(Screen.PrimaryScreen.Bounds.Width * 0.5f, Screen.PrimaryScreen.Bounds.Height * 0.5f);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);
        public Aim() {
            m = Program.m;
            this.moduleAddr = m.GetInsufficentMaterials("client_panorama.dll");
            this.engineAddr = m.GetInsufficentMaterials("engine.dll");
            this.engineState = m.DeployRope<int>((IntPtr)engineAddr + Statics.signatures.dwClientState);
        }
        public void GetLocalPlayer() {
            localPlayer = m.DeployRope<int>(moduleAddr + Statics.signatures.dwLocalPlayer); //Getting our player structure!
            //mask = xx??xx?x
        }
        public float GetMouseSensitivity() {
            mouseSensitivity = m.DeployRope<float>(moduleAddr + Statics.signatures.dwSensitivity);
            return mouseSensitivity;
        }
        public int GetPlayerTeam() {
            localPlayerTeam = m.DeployRope<int>((IntPtr)localPlayer + Statics.netvars.m_iTeamNum);
            return localPlayerTeam;
        }
        public int GetEntityBase(int i) {
            int result = m.DeployRope<int>(moduleAddr + Statics.signatures.dwEntityList + (i * entityOffset));
            return result;
        }
        public int GetEntityTeam(int i) {
            return m.DeployRope<int>((IntPtr)GetEntityBase(i) + Statics.netvars.m_iTeamNum);
        }
        public void SetSensitivity(float x) {
            m.CraftRope<float>(moduleAddr + Statics.signatures.dwSensitivity, x);
        }
        public void SetAngles(float[] angles) {
            if (engineAddr != null) {
                m.CraftRope<float>((IntPtr)engineState + Statics.signatures.dwClientState_ViewAngles, angles[0]);
                m.CraftRope<float>((IntPtr)engineState + Statics.signatures.dwClientState_ViewAngles + 0x4, angles[1]);
                m.CraftRope<float>((IntPtr)engineState + Statics.signatures.dwClientState_ViewAngles + 0x8, angles[2]);
            }
        }
        public int GetEntityInCross() {
            int ourResult = 0x00;
            if ((IntPtr)localPlayer != null) {
                ourResult = m.DeployRope<int>((IntPtr)localPlayer + Statics.netvars.m_iCrosshairId);
            }
            return ourResult;
        }
        public bool IsDead(int playaNum) {
            int entity = GetEntityBase(playaNum);
            int health = m.DeployRope<int>((IntPtr)entity + Statics.netvars.m_iHealth);
            bool dormant = m.DeployRope<bool>((IntPtr)entity + Statics.netvars.m_lifeState);
            return dormant;
        }
        public float[] GetPlayerPunch() {
            float[] pos = new float[] { 0.0f, 0.0f, 0.0f };
            pos[0] = m.DeployRope<float>(((IntPtr)localPlayer + Statics.netvars.m_viewPunchAngle));
            pos[1] = m.DeployRope<float>(((IntPtr)localPlayer + Statics.netvars.m_viewPunchAngle) + 0x4);
            pos[2] = m.DeployRope<float>(((IntPtr)localPlayer + Statics.netvars.m_viewPunchAngle) + 0x8);
            return
               pos;
                
        }
        public float[] GetPlayerPosition() {
            float[] pos = new float[] { 0.0f, 0.0f, 0.0f };
            pos[0] = m.DeployRope<float>(((IntPtr)localPlayer + Statics.netvars.m_vecOrigin));
            pos[1] = m.DeployRope<float>(((IntPtr)localPlayer + Statics.netvars.m_vecOrigin) + 0x4);
            pos[2] = m.DeployRope<float>(((IntPtr)localPlayer + Statics.netvars.m_vecOrigin) + 0x8);
            return pos;
        }
        
        public float[] GetBonePosition(int entityId) {
            float[] result = new float[] { 0.0f, 0.0f, 0.0f };
            int boneMatrix = 0x00;
            int entity = GetEntityBase(entityId);
            if (entity != 0x00) {
                boneMatrix = m.DeployRope<int>((IntPtr)entity + Statics.netvars.m_dwBoneMatrix);
                result[0] = m.DeployRope<float>((IntPtr)boneMatrix + 0x30 * 10 + 0x0c);
                result[1] = m.DeployRope<float>((IntPtr)boneMatrix + 0x30 * 10 + 0x1c);
                result[2] = m.DeployRope<float>((IntPtr)boneMatrix + 0x30 * 10 + 0x2c);
            }
            return result;
        }
        public float[] CalculateAngle(float[] src, float[] dst) {
            float[] punch = GetPlayerPunch();
            float[] angles = new float[] { 0.0f, 0.0f, 0.0f};
            double[] delta = { (src[0] - dst[0]), (src[1] - dst[1]), (src[2] - (dst[2] - 61)) };
            double hyp = Math.Sqrt(Math.Pow(delta[0], 2) + Math.Pow(delta[1], 2));
            angles[0] = (float)(Math.Atan(delta[2] / hyp) * 57.295779513082f - punch[0] * 2.0f);
            angles[1] = (float)(Math.Atan(delta[1] / delta[0]) * 57.295779513082f - punch[1] * 2.0f);
            angles[2] = 0.0f;
            if (delta[0] >= 0.0f) {
                angles[1] += 180.0f;
            }
            return angles;
        }

        public void InitialLoop() {


            toggle = true;
            while (true) {
                GetLocalPlayer();
                /*if (mouseSensitivity == 0.0f || mouseSensitivity < 0.0f)
                    GetMouseSensitivity();*/

                int entityInCross = GetEntityInCross();
                /*if (GetAsyncKeyState(System.Windows.Forms.Keys.XButton1) < 0 && entityInCross < 64 && entityInCross > 0 && GetEntityTeam(entityInCross - 1) != GetPlayerTeam()) {
                    mouse_event((uint)MouseEventFlags.LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    Thread.Sleep(10);
                    mouse_event((uint)MouseEventFlags.LEFTUP, 0, 0, 0, UIntPtr.Zero);
                    Thread.Sleep(10);
                }*/
                //while (GetAsyncKeyState(Keys.LButton) != 0) {
                    if (entityInCross < 64 && entityInCross > 0 && GetEntityTeam(entityInCross - 1) != GetPlayerTeam() && IsDead(entityInCross - 1) != true) {
                        //SetSensitivity((mouseSensitivity * 0.5f));
                        float[] headPos = GetBonePosition(entityInCross - 1);
                        
                        float[] myPos = GetPlayerPosition();
                        float[] aimAngles = CalculateAngle(myPos, headPos);
                        SetAngles(aimAngles);
                        
                        Program.Print($"My pos: {myPos[0]}; {myPos[1]}; {myPos[2]}\nHead Pos: {headPos[0]}; {headPos[1]}; {headPos[2]}\nCalculated Angles: {aimAngles[0]}; {aimAngles[1]}; {aimAngles[2]}");
                    }
                    
                //}
                Thread.Sleep(1);
            }
            

        }
    }
}
