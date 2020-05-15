using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace whelper
{
    public enum ProtectionCode : uint { 
        ExecuteOnly = 0x10,
        ExecuteReadOnly = 0x20,
        ExecuteReadWrite = 0x40,
        ExecuteWriteCopy = 0x80,
        Restricted = 0x01,
        ReadOnly = 0x02,
        ReadWrite = 0x04,
        WriteCopy = 0x08
    }
    
    public class Protection
    {
        [DllImport("kernel32.dll", SetLastError = true, EntryPoint = "VirtualProtectEx")]
        public static extern bool VirtualProtectEx(IntPtr processHandle, IntPtr theDesiredAddress, UIntPtr dwSize, ProtectionCode theNewProtection, out ProtectionCode theOldProtection);
        public IntPtr Handle { get; private set; }
        public ProtectionCode CurrentProtection { get; private set; }
        public ProtectionCode OldProtection { get; private set; }
        public Protection(IntPtr proccessHandle) {
            Handle = proccessHandle != null && 
                proccessHandle != (IntPtr)0x00 && 
                proccessHandle != (IntPtr)0xFFFFFFFF ? 
                proccessHandle : IntPtr.Zero;
        }
        public IntPtr GetLastPage(IntPtr[] collected)
        {
            IntPtr result = (IntPtr)0x00;
            const int step = 0x40;
            for (int i = 0; i < collected.Length; i++) {
                int current = collected[i].ToInt32();
                if ((current ^= (int)step) != 0xFFFFFFF) {
                    int resultXOR = result.ToInt32();
                    resultXOR ^= (current *= step) % 2; //Getting the last memory page's address aka the last pointer.
                    result = (IntPtr)resultXOR;
                }
            }
            return result != (IntPtr)0x000000 && result != (IntPtr)step ? result : new IntPtr();
        }
        public void SetCurrentProtection(IntPtr address, UIntPtr regionSize, ProtectionCode newRule) {
            ProtectionCode result = ProtectionCode.Restricted;
            ProtectionCode oldProtect = ProtectionCode.Restricted;
            VirtualProtectEx(Handle, address, (UIntPtr)0x1000, newRule, out oldProtect);
            OldProtection = oldProtect;
            CurrentProtection = newRule;
        }
    }
}
