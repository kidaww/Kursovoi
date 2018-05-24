using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //класс для получения ифно и управления клавиатурой
    class Keyboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetActiveWindow(); //HWND, дескриптор окна
        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr GetKeyboardLayout(uint id); //HKL, дискриптор текущей расскладки
        [DllImport("user32.dll")]
        static extern uint GetKeyboardLayoutList(int nBuff, [Out] IntPtr[] lpList); //список дескрипторов, наверное
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr ActivateKeyboardLayout(IntPtr hkl, uint Flags); //для смены раскладки, флаг для Reorder(1-0)

        public static  IntPtr   nowLangHand; //текущий дескриптор расскладки
        public static  IntPtr[] allLangHandList; //массив всех дескрипторов расскладки

        public static  IntPtr _RUS = (IntPtr)68748313; //дескриптор русского
        public static IntPtr _ENG = (IntPtr)67699721; //дескриптор английского

        public Keyboard()
        {
            nowLangHand = GetKeyboardLayout(0);//номер текущего дескриптора 
            uint allLangHandCount = GetKeyboardLayoutList(0, null); /* Нуль нужен, что бы получить число, необходимое для размещения всех дескриптеров */
            allLangHandList = new IntPtr[allLangHandCount]; //массив дескрипторов

            GetKeyboardLayoutList(allLangHandList.Length, allLangHandList); //Заполнение массива дескрипторами
            //if (allLangHandCount > 2) MessageBox.Show("В вашей системе установлено более двух языков. Программа поддерживает только руссский и английский!");
        }
        //смена языков, если их всего два
        public void ChangeKeyLayout()
        {
            if (nowLangHand == allLangHandList[0])
                ActivateKeyboardLayout(allLangHandList[1], 1); //переключение расскладки
            else
                ActivateKeyboardLayout(allLangHandList[0], 1);

            nowLangHand = GetKeyboardLayout(0);//номер текущего дескриптора
            //lLangHand.Text = nowLangHand.ToString();
        }
        //установка расскладки, рус или англ
        public void setKeyLayout(IntPtr lang)
        {
            if ((lang == _RUS) || (lang == _ENG))
            {
                ActivateKeyboardLayout(lang, 1);
            }
            else
            {
                throw new Exception("Данный дескриптор не поддерживается");
            }
        }
        
        
    }
}
