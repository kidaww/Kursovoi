using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //класс для утсановки хука для перехвата нажатий
    class KeyHook
    {
        
        private const int WH_KEYBOARD_LL = 13; //ID низкоуровневого перехвата клавиатуры
        private const int WM_KEYDOWN = 0x0100; //сообщение нажатия кнопки
        private static LowLevelKeyboardProc _proc = HookCallback; //делегат колбека
        private static Keyboard kb = new Keyboard();
        static string _en = "qwertyuiop[]asdfghjkl;'zxcvbnm,.";
        static string _ru = "йцукенгшщзхъфывапролджэячсмитьбю";
        static List<char> alphaEn;
        static List<char> alphaRu;
        private static IntPtr _hookID = IntPtr.Zero; //ид хука для обращения


        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }
        private delegate IntPtr LowLevelKeyboardProc( int nCode, IntPtr wParam, IntPtr lParam);
        
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            OfflineDictionary dic = new OfflineDictionary();
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                //MessageBox.Show(((Keys)vkCode).ToString()); //prev Console.WriteLine(Keys)vkCode
                if (((Keys)vkCode).ToString().Length > 1)
                {
                    //nothing
                }
                else if (Keyboard.nowLangHand == Keyboard._RUS)
                {
                    dic.AddKey( toRus(((Keys)vkCode).ToString().ToLower()) );
                }
                else
                {
                    dic.AddKey(((Keys)vkCode).ToString().ToLower());
                }
                
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        private static String toRus(string enl)
        {
            alphaEn = _en.ToList();
            alphaRu = _ru.ToList();
            return alphaRu[alphaEn.IndexOf(Convert.ToChar(enl))].ToString();
        }
        public void Stop()
        {
            UnhookWindowsHookEx(_hookID);
        }
        public void Run()
        {
            _hookID = SetHook(_proc);
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
    }
}
