using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    //класс для управления интернет-словарем
    class OnlineDictionary
    {
        //функция ввода буквы под слово
        public void AddKey(int key)
        {
            //переводим в букву, добавляем в строку
            //обращаемся к словарю за поиском (с третей буквы)
            //где больше соответсвий тот язык и оставляем
        }
        //функция очищения
        public void Complete()
        {
        }
        //функция поиска соответсвий в словаре
        public double FindIn()
        {
            return double.MinValue;
        }
        //функция конекта к словарю
        public void ConnectToDictionary(string word)
        {
            /*string word_en = "ghb";
            string word_ru = "при";
            string responsetext = new StreamReader(HttpWebRequest.Create("https://predictor.yandex.net/api/v1/predict.json/complete?key=pdct.1.1.20180202T124525Z.16e06e166f0ee320.d2b8d452a8ee60f06bf17ea7448092afa41aaa25&q=" + word_ru + "&lang=en").GetResponse().GetResponseStream()).ReadToEnd();
            MessageBox.Show(responsetext);*/

        }
    }
}
