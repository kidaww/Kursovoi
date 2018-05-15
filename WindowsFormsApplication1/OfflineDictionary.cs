using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //класс для управления локальным словарем
    class OfflineDictionary
    {
        static string _en = "qwertyuiop[]asdfghjkl;'zxcvbnm,.";
        static string _ru = "йцукенгшщзхъфывапролджэячсмитьбю";
        static List<char> alphaEn;
        static List<char> alphaRu;
        private static StreamReader srRU;
        private static StreamReader srEN;
        Keyboard kb = new Keyboard();
        static string word = "";
        static int inputed = 0;

        /// <summary>
        /// Метод ввода буквы под слово
        /// </summary>
        /// <param name="key">Код нажатой кнопки</param>
        public void AddKey(string key)
        {
            //MessageBox.Show(key);
            //MessageBox.Show(key);
            if (key == "space")
            {
                inputed = 0;
                word = "";
                /*KeyInput.tryBack();
                KeyInput.tryBack();
                KeyInput.tryBack();*/
                //MessageBox.Show(word);
                //MessageBox.Show(FindIn(word).ToString());
            }
            else if (key.Length == 1)
            {
                word += key;
                inputed++;
                if (inputed == 3)
                {
                    if (FindIn(word) && Keyboard.nowLangHand == Keyboard._ENG)
                    {
                        kb.ChangeKeyLayout();
                    }
                    else if (!FindIn(word) && Keyboard.nowLangHand == Keyboard._RUS)
                    {
                        kb.ChangeKeyLayout();
                    }
                }
                //MessageBox.Show("" + "w:" + word + ",k:" + key); 
            }
        }
        /*
        public static void Complete()
        {
            StreamReader sr = new StreamReader("ENRUS.txt");
            StreamWriter sw = new StreamWriter("slovar_en.txt");
            String line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                count++;
                if (count % 2 == 0) continue;
                sw.WriteLine(line);
            }
            MessageBox.Show("Completed!");

        }*/
        public static String toRus(string enl)
        {
            alphaEn = _en.ToList();
            alphaRu = _ru.ToList();
            string list = "";
            foreach (var a in enl)
            {
                list += alphaRu[alphaEn.IndexOf(Convert.ToChar(a))].ToString();
            }
            return list;
        }
        public static String toEng(string enl)
        {
            alphaEn = _en.ToList();
            alphaRu = _ru.ToList();
            string list = "";
            foreach (var a in enl)
            {
                list += alphaEn[alphaRu.IndexOf(Convert.ToChar(a))].ToString();
            }
            return list;
        }
        //функция поиска соответсвий в словаре
        public bool FindIn(string word)
        {
            String line_ru, line_en, word_ru, word_en;
            if (Keyboard.nowLangHand == Keyboard._ENG)
            {
                word_ru = toRus(word);
                word_en = word;
            }
            else
            {
                word_ru = word;
                word_en = toEng(word);
            }
            int count_ru = 0;
            int count_en = 0;
            LoadDictionary();
            while ((line_ru = srRU.ReadLine()) != null)
            {
                if (line_ru.Contains(word_ru)) count_ru++;
            }
            while ((line_en = srEN.ReadLine()) != null)
            {
                if (line_en.Contains(word_en)) count_en++;
            }
            
            return count_ru > count_en;
        }
        //функция загрузки словаря
        public static void LoadDictionary()
        {
            srRU = new StreamReader("slovar.txt", System.Text.Encoding.Default);
            srEN = new StreamReader("slovar_en.txt", System.Text.Encoding.Default);
        }
    }
}
