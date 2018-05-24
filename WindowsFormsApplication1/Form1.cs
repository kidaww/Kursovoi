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
using MaterialSkin.Controls;
using MaterialSkin;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MaterialForm
    {
        Keyboard kb = new Keyboard(); //в этот момент мы получаем дескриптор текущей расскладки, и других расскладок
        KeyHook kh;
        public Form1()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);

            notifyIcon1.Visible = false;

            //lLangHand.Text        = Keyboard.nowLangHand.ToString(); //выводим текущий дескриптор 
            lbConsole.Items.Add("Текущий дескриптор расскладки: " + Keyboard.nowLangHand.ToString());
            //заносим все в листбокс
            /*lbConsole.Items.Add("All Lang Hand List: ");
            foreach (var a in Keyboard.allLangHandList)
            {
                lbConsole.Items.Add("-> " + a);
            }*/
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.FormClosing += new FormClosingEventHandler(this.Form1_Shutdown);
        }

        private void Form1_Shutdown(object sender, EventArgs e)
        {
            kh.Stop();
            //MessageBox.Show("Хук удален");
            lbConsole.Items.Add("Хук удален!");
        }
        private void Form1_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;

            }
        }

        //кнопка смены языка
        private void changeLangHand_Click(object sender, EventArgs e)
        {
            kb.ChangeKeyLayout();
            //lLangHand.Text = Keyboard.nowLangHand.ToString();
            //OnlineDictionary onl = new OnlineDictionary();
            //onl.ConnectToDictionary("123");
        }
        //установить хук
        private void bSetHook_Click(object sender, EventArgs e)
        {
            kh = new KeyHook();
            kh.Run();
            //MessageBox.Show("Хук установлен");
            //
            //KeyInput.play();
        }
        //снять хук
        private void bUnHook_Click(object sender, EventArgs e)
        {
            
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kh = new KeyHook();
            kh.Run();
            //MessageBox.Show("Хук установлен");
            lbConsole.Items.Add("Хук установлен!");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            WindowState = FormWindowState.Normal;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //нужно использовать хуки
    }
}
