using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
                //s
                //Thread.Sleep(100);
                if (FindIn(word, word.Length) && Keyboard.nowLangHand == Keyboard._ENG)
                {
                    //Thread.Sleep(100);
                    string temp = word;
                    KeyInput.deleteInputed(word.Length);
                    KeyInput.InputWord(temp);
                    kb.ChangeKeyLayout();
                    //KeyInput.deleteInputed(inputed);
                }
                else if (!FindIn(word, word.Length) && Keyboard.nowLangHand == Keyboard._RUS)
                {
                    //Thread.Sleep(100);
                    //Thread.Sleep(200);
                    string temp = word;
                    KeyInput.deleteInputed(word.Length);
                    KeyInput.InputWord(toEng(temp));
                    kb.ChangeKeyLayout();
                }
                //e
                //KeyInput.InputWord(word);
                inputed = 0;
                word = "";
                //KeyInput.deleteInputed(3);
                //MessageBox.Show(word);
                //MessageBox.Show(FindIn(word).ToString());

                
            }
           /* else if (key == "back")
            {
                word = word.Remove(word.Length - 1);
            }*/
            else if (key.Length == 1)
            {
                //KeyInput.getScanCodeByName("KEY_H");
                word += key;
                inputed++;
                /*if (inputed == 3)
                {
                    Thread.Sleep(300);
                    if (FindIn(word, 3) && Keyboard.nowLangHand == Keyboard._ENG)
                    {
                        
                        KeyInput.deleteInputed(word.Length);
                        KeyInput.InputWord(word);
                        kb.ChangeKeyLayout();
                        //KeyInput.deleteInputed(inputed);
                    }
                    else if (!FindIn(word, 3) && Keyboard.nowLangHand == Keyboard._RUS)
                    {
                        
                        //Thread.Sleep(200);
                        KeyInput.deleteInputed(word.Length);
                        KeyInput.InputWord(toEng(word));
                        kb.ChangeKeyLayout();
                    }
                }*/
                /*
                KeyInput.deleteInputed(word.Length);

                if (Keyboard.nowLangHand == Keyboard._RUS)
                {
                    KeyInput.InputWord(toRus(word));
                }
                else if (Keyboard.nowLangHand == Keyboard._ENG)
                {
                    KeyInput.InputWord(toEng(word));
                }
                //MessageBox.Show("" + "w:" + word + ",k:" + key);*/ 
            } 
            else
            {
                switch(key)
                {
                    case "oemperiod":
                        {
                            word += ".";
                            break;
                        }
                    case "oemcomma":
                        {
                            word += ",";
                            break;
                        }
                }
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
        public bool FindIn(string word, int len)
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
                //MessageBox.Show(line_ru.Substring(0, len));
                if (line_ru.Length < len) continue;
                if (line_ru == word_ru) count_ru++;
            }
            while ((line_en = srEN.ReadLine()) != null)
            {
                if (line_en.Length < len) continue;
                if (line_en == word_en) count_en++;
            }

            /*MessageBox.Show(word_ru + "<- " + count_ru + "; " + word_en + "<- " + count_en);
            MessageBox.Show(word_ru + "<- " + count_ru + "; " + word_en + "<- " + count_en);
            MessageBox.Show(word_ru + "<- " + count_ru + "; " + word_en + "<- " + count_en);*/
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
