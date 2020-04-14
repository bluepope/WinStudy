using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleKeyHooker.CustomKeyHook
{
    class KeyHook
    {
        /*
 WH_JOURNALRECORD = 0,
    WH_JOURNALPLAYBACK = 1,
    WH_KEYBOARD = 2,
    WH_GETMESSAGE = 3,
    WH_CALLWNDPROC = 4,
    WH_CBT = 5,
    WH_SYSMSGFILTER = 6,
    WH_MOUSE = 7,
    WH_HARDWARE = 8,
    WH_DEBUG = 9,
    WH_SHELL = 10,
    WH_FOREGROUNDIDLE = 11,
    WH_CALLWNDPROCRET = 12,
    WH_KEYBOARD_LL = 13,
    WH_MOUSE_LL = 14
     */

        private const int WH_GETMESSAGE = 3;
        private const int WH_KEYBOARD_LL = 13;

        private const int WM_PAINT = 15;
        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);


        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)

            {

                int vkCode = Marshal.ReadInt32(lParam);

                Console.WriteLine((Keys)vkCode);

            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        public void Run()
        {
            _hookID = SetHook(_proc);

            Application.Run();

            UnhookWindowsHookEx(_hookID);
        }
    }
}
