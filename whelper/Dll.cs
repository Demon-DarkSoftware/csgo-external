using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace whelper
{
    public enum CodeResult
    {
        Failed = 1,
        Success = 2,
        FileNotFound = 3,
        ProcessNotFound = 4
    }


    public sealed class Dll
    {
        // Fields
        private static readonly IntPtr ZeroValue = IntPtr.Zero;
        private static Dll status;

        // Methods
        private Dll()
        {
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        public CodeResult Inject(string processName, string dllName)
        {
            CodeResult fileNotFound;
            if (!File.Exists(dllName))
            {
                fileNotFound = CodeResult.FileNotFound;
            }
            else
            {
                uint pToBeInjected = 0;
                Process[] processes = Process.GetProcesses();
                int index = 0;
                while (true)
                {
                    if (index < processes.Length)
                    {
                        if (processes[index].ProcessName != processName)
                        {
                            index++;
                            continue;
                        }
                        pToBeInjected = (uint)processes[index].Id;
                    }
                    fileNotFound = (pToBeInjected != 0) ? (this.injectBase(Program.m.Handle, dllName) ? CodeResult.Success : CodeResult.Failed) : CodeResult.ProcessNotFound;
                    break;
                }
            }
            return fileNotFound;
        }

        private bool injectBase(IntPtr handle, string dllName)
        {
            bool flag2;
            IntPtr hProcess = handle;
            if (hProcess == ZeroValue)
            {
                flag2 = false;
            }
            else
            {
                IntPtr procAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                if (procAddress == ZeroValue)
                {
                    flag2 = false;
                }
                else
                {
                    IntPtr lpBaseAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (IntPtr)dllName.Length, 0x3000, 0x40);
                    if (lpBaseAddress == ZeroValue)
                    {
                        flag2 = false;
                    }
                    else
                    {
                        byte[] bytes = Encoding.ASCII.GetBytes(dllName);
                        if (WriteProcessMemory(hProcess, lpBaseAddress, bytes, (uint)bytes.Length, 0) == 0)
                        {
                            flag2 = false;
                        }
                        else if (CreateRemoteThread(hProcess, IntPtr.Zero, ZeroValue, procAddress, lpBaseAddress, 0, IntPtr.Zero) == ZeroValue)
                        {
                            flag2 = false;
                        }
                        else
                        {
                            CloseHandle(hProcess);
                            flag2 = true;
                        }
                    }
                }
            }
            return flag2;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

        // Properties
        public static Dll GetInstance
        {
            get
            {
                if (ReferenceEquals(status, null))
                {
                    status = new Dll();
                }
                return status;
            }
        }
    }


}
