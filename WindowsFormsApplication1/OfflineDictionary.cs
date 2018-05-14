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
        /// <summary>
        /// Метод ввода буквы под слово
        /// </summary>
        /// <param name="key">Код нажатой кнопки</param>
        private static StreamReader sr;
        static string word = "";
        public void AddKey(string key)
        {
            //MessageBox.Show(key);
            if (key == "Space")
            {
                //MessageBox.Show(word);
                //MessageBox.Show(FindIn(word).ToString());
            }
            else
            {
                word += key;
                //MessageBox.Show("" + "w:" + word + ",k:" + key); 
            }
        }
        //функция очищения
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

        }
        //функция поиска соответсвий в словаре
        public int FindIn(string word)
        {
            String line;
            int count = 0;
            while ((line = sr.ReadLine()) != null)
            {
                if (line.Contains(word)) count++;
            }
            return count;
        }
        //функция загрузки словаря
        public static void LoadDictionary()
        {
            sr = new StreamReader("slovar.txt", System.Text.Encoding.Default);

        }
    }
}
