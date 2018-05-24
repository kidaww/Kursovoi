using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class KeyInput : Codes
    {
        static string _en = "qwertyuiop[]asdfghjkl;'zxcvbnm,.";
        static string _ru = "йцукенгшщзхъфывапролджэячсмитьбю";
        public static short getScanCodeByName(string name)
        {
            
            //получаю значение enum по имени
            ScanCodeShort elem = (ScanCodeShort)Enum.Parse(typeof(ScanCodeShort), name);
            //return elem;
            object val = Convert.ChangeType(elem, elem.GetTypeCode());
            return (short)val;
        }
        public static short getVirtualKeyShortByName(string name)
        {
            //получаю значение enum по имени
            VirtualKeyShort elem = (VirtualKeyShort)Enum.Parse(typeof(VirtualKeyShort), name);
            //return elem;
            object val = Convert.ChangeType(elem, elem.GetTypeCode());
            return (short)val;
        }
        public static void InputWord(string word)
        {
            INPUT[] pInputs = new INPUT[word.Length];
            //string[] array = new[] { word };
            for (int i = 0; i < pInputs.Length; i++)
            {
                string temp = "";
                switch (word[i].ToString())
                {
                    case ".":
                        {
                            temp = "OEM_PERIOD";
                            break;
                        }
                    case ",":
                        {
                            temp = "OEM_COMMA";
                            break;
                        }
                    case ";":
                        {
                            temp = "OEM_COMMA";
                            break;
                        }
                    default:
                        {
                            temp = "KEY_" + word[i].ToString().ToUpper();
                            break;
                        }
                }
                pInputs[i] = new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = (ScanCodeShort)getScanCodeByName(temp), wVk = (VirtualKeyShort)getVirtualKeyShortByName(temp) }
                    }
                };
            }
            tryInput(pInputs);
        }
        public static void deleteInputed(int count)
        {
            var pInputs = new[] {
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = ScanCodeShort.BACK, wVk = VirtualKeyShort.BACK }
                    }
                },
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = ScanCodeShort.BACK, wVk = VirtualKeyShort.BACK, dwFlags = KEYEVENTF.KEYUP }
                    }
                }
            };

            for (int i = 0; i < count; i++)
            {
                tryInput(pInputs);
            }

        }
        public static void tryInput(INPUT[] pInputs)
        {
            SendInput((uint)pInputs.Length, pInputs, INPUT.Size);
        }

        public static void play()
        {
            var pInputs = new[] {
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = ScanCodeShort.KEY_H, wVk = VirtualKeyShort.KEY_H }
                    }
                },
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = ScanCodeShort.KEY_H, wVk = VirtualKeyShort.KEY_H, dwFlags = KEYEVENTF.KEYUP }
                    }
                },
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = ScanCodeShort.KEY_I, wVk = VirtualKeyShort.KEY_I }
                    }
                },
                new INPUT
                {
                    type = InputType.KEYBOARD,
                    U = new InputUnion
                    {
                        ki = { wScan = ScanCodeShort.KEY_I, wVk = VirtualKeyShort.KEY_I, dwFlags = KEYEVENTF.KEYUP }
                    }
                }
            };


            Process[] processes = Process.GetProcessesByName("notepad");

            if (processes.Length == 0)
                throw new Exception("Could not find the notepad process; is notepad running?");

            IntPtr WindowHandle = processes[0].MainWindowHandle;
            ForceForegroundWindow(WindowHandle);

            Thread.Sleep(2500);
            SendInput((uint)pInputs.Length, pInputs, INPUT.Size);
        }

        private static void ForceForegroundWindow(IntPtr hWnd)
        {

            uint foreThread = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero);
            uint appThread = GetCurrentThreadId();
            if (foreThread != appThread)
            {
                var t = AttachThreadInput(foreThread, appThread, true);
                Console.WriteLine(t);
                SetForegroundWindow(hWnd);
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, ShowWindowCommands.Show);
                var t2 = AttachThreadInput(foreThread, appThread, false);
                Console.WriteLine(t2);
            }
            else
            {
                BringWindowToTop(hWnd);
                ShowWindow(hWnd, ShowWindowCommands.Show);
            }
        }

        [DllImport("kernel32.dll")]
        static extern uint GetCurrentThreadId();

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool BringWindowToTop(HandleRef hWnd);

        [DllImport("user32.dll")]
        static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);


        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);

        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            internal InputType type;
            internal InputUnion U;
            internal static int Size
            {
                get { return Marshal.SizeOf(typeof(INPUT)); }
            }
        }

        internal enum InputType : uint
        {
            MOUSE = 0,
            KEYBOARD = 1,
            HARDWARE = 2
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct InputUnion
        {
            [FieldOffset(0)]
            internal MOUSEINPUT mi;
            [FieldOffset(0)]
            internal KEYBDINPUT ki;
            [FieldOffset(0)]
            internal HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct KEYBDINPUT
        {
            internal VirtualKeyShort wVk;
            internal ScanCodeShort wScan;
            internal KEYEVENTF dwFlags;
            internal int time;
            internal UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct HARDWAREINPUT
        {
            internal int uMsg;
            internal short wParamL;
            internal short wParamH;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct MOUSEINPUT
        {
            internal int dx;
            internal int dy;
            internal int mouseData;
            internal MOUSEEVENTF dwFlags;
            internal uint time;
            internal UIntPtr dwExtraInfo;
        }
    }
}
