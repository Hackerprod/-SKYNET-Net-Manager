using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace lolo
{
    public class Hook
    {
        private enum HookType
        {
            WH_JOURNALRECORD,
            WH_JOURNALPLAYBACK,
            WH_KEYBOARD,
            WH_GETMESSAGE,
            WH_CALLWNDPROC,
            WH_CBT,
            WH_SYSMSGFILTER,
            WH_MOUSE,
            WH_HARDWARE,
            WH_DEBUG,
            WH_SHELL,
            WH_FOREGROUNDIDLE,
            WH_CALLWNDPROCRET,
            WH_KEYBOARD_LL,
            WH_MOUSE_LL
        }

        public struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;

            public uint scanCode;

            public uint flags;

            public uint time;

            public IntPtr extraInfo;
        }

        private delegate int HookProc(int code, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        public delegate void KeyDownEventDelegate(KeyboardHookEventArgs e);

        public delegate void KeyUpEventDelegate(KeyboardHookEventArgs e);

        private int WM_KEYDOWN = 256;

        private int WM_KEYUP = 257;

        private int WM_SYSKEYDOWN = 260;

        private int WM_SYSKEYUP = 261;

        private bool _ispaused;

        public KeyDownEventDelegate KeyDownEvent = delegate
        {
        };

        public KeyUpEventDelegate KeyUpEvent = delegate
        {
        };

        private HookProc _hookproc;

        private IntPtr _hhook;

        public string Name
        {
            get;
            private set;
        }

        public bool isPaused
        {
            get
            {
                return _ispaused;
            }
            set
            {
                if (value != _ispaused && value)
                {
                    StopHook();
                }
                if (value != _ispaused && !value)
                {
                    StartHook();
                }
                _ispaused = value;
            }
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(HookType idHook, HookProc lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll")]
        private static extern int UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern int CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam);

        public Hook(string name)
        {
            Name = name;
            StartHook();
        }

        private void StartHook()
        {
            Trace.WriteLine($"Starting hook '{Name}'...", $"Hook.StartHook [{Thread.CurrentThread.Name}]");
            _hookproc = this.HookCallback;
            _hhook = SetWindowsHookEx(HookType.WH_KEYBOARD_LL, _hookproc, GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
            if (_hhook == IntPtr.Zero)
            {
                new Win32Exception(Marshal.GetLastWin32Error());
            }
        }

        private void StopHook()
        {
            Trace.WriteLine($"Stopping hook '{Name}'...", $"Hook.StartHook [{Thread.CurrentThread.Name}]");
            UnhookWindowsHookEx(_hhook);
        }

        private int HookCallback(int code, IntPtr wParam, ref KBDLLHOOKSTRUCT lParam)
        {
            int result = 0;
            try
            {
                if (isPaused)
                {
                    return result;
                }
                if (code < 0)
                {
                    return result;
                }
                if (wParam.ToInt32() == WM_SYSKEYDOWN || wParam.ToInt32() == WM_KEYDOWN)
                {
                    KeyDownEvent(new KeyboardHookEventArgs(lParam));
                }
                if (wParam.ToInt32() != WM_SYSKEYUP && wParam.ToInt32() != WM_KEYUP)
                {
                    return result;
                }
                KeyUpEvent(new KeyboardHookEventArgs(lParam));
                return result;
            }
            finally
            {
                result = CallNextHookEx(IntPtr.Zero, code, wParam, ref lParam);
            }
        }

        ~Hook()
        {
            StopHook();
        }
    }
    public class KeyboardHookEventArgs
    {
        private enum VirtualKeyStates
        {
            VK_LWIN = 91,
            VK_RWIN = 92,
            VK_LSHIFT = 160,
            VK_RSHIFT = 161,
            VK_LCONTROL = 162,
            VK_RCONTROL = 163,
            VK_LALT = 164,
            VK_RALT = 165
        }

        private const int KEY_PRESSED = 32768;

        public Keys Key
        {
            get;
            private set;
        }

        public bool isAltPressed
        {
            get
            {
                if (!isLAltPressed)
                {
                    return isRAltPressed;
                }
                return true;
            }
        }

        public bool isLAltPressed
        {
            get;
            private set;
        }

        public bool isRAltPressed
        {
            get;
            private set;
        }

        public bool isCtrlPressed
        {
            get
            {
                if (!isLCtrlPressed)
                {
                    return isRCtrlPressed;
                }
                return true;
            }
        }

        public bool isLCtrlPressed
        {
            get;
            private set;
        }

        public bool isRCtrlPressed
        {
            get;
            private set;
        }

        public bool isShiftPressed
        {
            get
            {
                if (!isLShiftPressed)
                {
                    return isRShiftPressed;
                }
                return true;
            }
        }

        public bool isLShiftPressed
        {
            get;
            private set;
        }

        public bool isRShiftPressed
        {
            get;
            private set;
        }

        public bool isWinPressed
        {
            get
            {
                if (!isLWinPressed)
                {
                    return isRWinPressed;
                }
                return true;
            }
        }

        public bool isLWinPressed
        {
            get;
            private set;
        }

        public bool isRWinPressed
        {
            get;
            private set;
        }

        [DllImport("user32.dll")]
        private static extern short GetKeyState(VirtualKeyStates nVirtKey);

        internal KeyboardHookEventArgs(Hook.KBDLLHOOKSTRUCT lParam)
        {
            Key = (Keys)lParam.vkCode;
            isLAltPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_LALT) & 0x8000) || Key == Keys.LMenu);
            isRAltPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_RALT) & 0x8000) || Key == Keys.RMenu);
            isLCtrlPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_LCONTROL) & 0x8000) || Key == Keys.LControlKey);
            isRCtrlPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_RCONTROL) & 0x8000) || Key == Keys.RControlKey);
            isLShiftPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_LSHIFT) & 0x8000) || Key == Keys.LShiftKey);
            isRShiftPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_RSHIFT) & 0x8000) || Key == Keys.RShiftKey);
            isLWinPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_LWIN) & 0x8000) || Key == Keys.LWin);
            isRWinPressed = (Convert.ToBoolean(GetKeyState(VirtualKeyStates.VK_RWIN) & 0x8000) || Key == Keys.RWin);
            Keys[] keys = new Keys[8]
            {
                Keys.LMenu,
                Keys.RMenu,
                Keys.LControlKey,
                Keys.RControlKey,
                Keys.LShiftKey,
                Keys.RShiftKey,
                Keys.LWin,
                Keys.RWin
            };
            /*
            if (keys.Contains(Key))
            {
                Key = Keys.None;
            }
            */
        }

        public override string ToString()
        {
            return $"Key={Key}; Win={isWinPressed}; Alt={isAltPressed}; Ctrl={isCtrlPressed}; Shift={isShiftPressed}";
        }
    }
}
