using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Keyboard kb = new Keyboard(); //в этот момент мы получаем дескриптор текущей расскладки, и других расскладок
        KeyHook kh;
        public Form1()
        {
            InitializeComponent();
            
            lLangHand.Text        = Keyboard.nowLangHand.ToString(); //выводим текущий дескриптор 
            
            //заносим все в листбокс
            lbAllLangHand.Items.Add("All Lang Hand List: ");
            foreach (var a in Keyboard.allLangHandList)
            {
                lbAllLangHand.Items.Add("-> " + a);
            }
        }
        
        //кнопка смены языка
        private void changeLangHand_Click(object sender, EventArgs e)
        {
            kb.ChangeKeyLayout();
            lLangHand.Text = Keyboard.nowLangHand.ToString();
            OnlineDictionary onl = new OnlineDictionary();
            onl.ConnectToDictionary("123");
        }
        //установить хук
        private void bSetHook_Click(object sender, EventArgs e)
        {
            kh = new KeyHook();
            kh.Run();
            OfflineDictionary.LoadDictionary();
            MessageBox.Show("Хук установлен");
            //KeyInput.play();
        }
        //снять хук
        private void bUnHook_Click(object sender, EventArgs e)
        {
            kh.Stop();
            MessageBox.Show("Хук удален");
        }
        //нужно использовать хуки
    }
}
