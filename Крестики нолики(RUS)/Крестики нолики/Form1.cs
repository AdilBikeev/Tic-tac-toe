using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Media;

namespace Крестики_нолики
{
    public partial class Form1 : Form
    {
        string[] music = { "лсп-oxxxymiron-безумие.wav", "баста-сансара.wav", "jasmine-thompson-mad-world.wav" };
        int i = 0;
        private SoundPlayer _soundPlayer;

        public Form1()
        {
            InitializeComponent();
            // задаем обработчик события
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            

        }
      


        public void winner(string[,] a)//определяет победителя 
        {
            for (int i = 0; i < 3; i++)
            {
                if ((a[i, 0] == a[i, 1]) && (a[i, 0] == a[i, 2]))//проверка победы по горизонтали
                {
                    if (a[i, 0] == "X")
                    {
                        textBox1.Text = "Победили X !!!";
                        textBox3.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) + 1);
                    }
                    else
                    {
                        textBox1.Text = "Победили 0 !!!";
                        textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) + 1);
                    }
                }
            }
            if (((a[0, 0] == a[1, 1]) && (a[0, 0] == a[2, 2])) || ((a[0, 2] == a[1, 1]) && (a[0, 2] == a[2, 0])))//проверка выигрыша по диагоналям
            {
                if (a[1, 1] == "X")
                {
                    textBox1.Text = "Победили X !!!";
                    textBox3.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) + 1);
                }
                else
                {
                    textBox1.Text = "Победили 0 !!!";
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) + 1);
                }
            }       
            if ((a[0, 0] == a[1, 0]) && (a[0, 0] == a[2, 0]))//проверка выигрыша по вертикали
            {
                if (a[0, 0] == "X")
                {
                    textBox1.Text = "Победили X !!!";
                    textBox3.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) + 1);
                }
                else
                {
                    textBox1.Text = "Победили 0 !!!";
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) + 1);
                }
            }
            else if ((a[0, 1] == a[1, 1]) && (a[0, 1] == a[2, 1]))
            {
                if (a[0, 1] == "X")
                {
                    textBox1.Text = "Победили X !!!";
                    textBox3.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) + 1);
                }
                else
                {
                    textBox1.Text = "Победили 0 !!!";
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) + 1);

                }
            }
            else if ((a[0, 2] == a[1, 2]) && (a[0, 2] == a[2, 2]))
            {
                if (a[0, 2] == "X")
                {
                    textBox1.Text = "Победили X !!!";
                    textBox3.Text = Convert.ToString(Convert.ToInt32(textBox3.Text) + 1);
                }
                else
                {
                    textBox1.Text = "Победили 0 !!!";
                    textBox4.Text = Convert.ToString(Convert.ToInt32(textBox4.Text) + 1);

                }
            }
        }
        public void the_end(string [,]a, int flag = 0)//определяе конец игры
        {
            for (int i = 0; i < 3; i++)//проверка на конец игры
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((a[i, j] == "1") || (a[i, j] == "2") || (a[i, j] == "3") || (a[i, j] == "4") || (a[i, j] == "5") || (a[i, j] == "6") || (a[i, j] == "7") || (a[i, j] == "8") || (a[i, j] == "9")) { flag = 1; }//если хотяб одна клетка не заполнена
                }

            }
            if (flag == 0)//если все поле заполнено
            {
                textBox2.Text = "The End";
            }
        }
        public void game(string [,]a)//следит за процессом игры
        {
            winner(a);
            the_end(a);  
        }
        
        string [,]a = new string[3, 3]{ {"1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };//хранит инфор. об игровом поле
        
        int hod=1;//определяет чей ход
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End")&&(textBox2.Text != "Для начала New Game нажмите кнопку Start")&&(textBox1.Text != "Нажмите Start для начала игры")&&(textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            {
                if ((button1.Text!="X")&&(button1.Text !="0"))//проверка на то, что там уже был совершен ход
                {
                
                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[0, 0] = "0";
                        button1.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[0, 0] = "X";
                        button1.Text = "X";
                    }
                    hod++;
                    game(a);
                
                }   
                else
                {
                   textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            {
                if ((button2.Text != "X") && (button2.Text != "0"))//проверка на то, что там уже был совершен ход
                {
                
                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[0, 1] = "0";
                        button2.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[0, 1] = "X";
                        button2.Text = "X";
                    }
                    hod++;
                    game(a);
                
                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            {
                if ((button3.Text != "X") && (button3.Text != "0"))//проверка на то, что там уже был совершен ход
                {

                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[0, 2] = "0";
                        button3.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[0, 2] = "X";
                        button3.Text = "X";
                    }
                    hod++;
                    game(a);

                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
}

        private void button4_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            { 
                if ((button4.Text != "X") && (button4.Text != "0"))//проверка на то, что там уже был совершен ход
                {
                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[1, 0] = "0";
                        button4.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[1, 0] = "X";
                        button4.Text = "X";
                    }
                    hod++;
                    game(a);


                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            {
                if ((button5.Text != "X") && (button5.Text != "0"))//проверка на то, что там уже был совершен ход
                {

                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[1, 1] = "0";
                        button5.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[1, 1] = "X";
                        button5.Text = "X";
                    }
                    hod++;
                    game(a);
                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            { 
                if ((button6.Text != "X") && (button6.Text != "0"))//проверка на то, что там уже был совершен ход
                {
               
                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[1, 2] = "0";
                        button6.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[1, 2] = "X";
                        button6.Text = "X";
                    }
                    hod++;
                    game(a);               
                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
}
        private void button7_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            {
                if ((button7.Text != "X") && (button7.Text != "0"))//проверка на то, что там уже был совершен ход
                {

                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[2, 0] = "0";
                        button7.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[2, 0] = "X";
                        button7.Text = "X";
                    }
                    hod++;
                    game(a);


                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            { 
                if ((button8.Text != "X") && (button8.Text != "0"))//проверка на то, что там уже был совершен ход
                {

                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[2, 1] = "0";
                        button8.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[2, 1] = "X";
                        button8.Text = "X";
                    }
                    hod++;
                    game(a);


                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            if ((textBox2.Text != "The End") && (textBox2.Text != "Для начала New Game нажмите кнопку Start") && (textBox1.Text != "Нажмите Start для начала игры") && (textBox1.Text != "Победили X !!!") && (textBox1.Text != "Победили 0 !!!"))
            {
                if ((button9.Text != "X") && (button9.Text != "0"))//проверка на то, что там уже был совершен ход
                {

                    if (hod % 2 == 0)
                    {
                        textBox1.Text = "Ходят X";
                        a[2, 2] = "0";
                        button9.Text = "0";
                    }
                    else
                    {
                        textBox1.Text = "Ходят 0";
                        a[2, 2] = "X";
                        button9.Text = "X";
                    }
                    hod++;
                    game(a);

                }
                else
                {
                    textBox2.Text = "Здесь уже ходили !\nСделайте ход за исключением в занятых клетках !";
                }
            }
            else { textBox2.Text = "Для начала New Game нажмите кнопку Start"; }
        }

        private void button10_Click(object sender, EventArgs e)//кнопка start
        {
            textBox1.Text = "Ходят X";
            textBox2.Clear();
            a[0, 0] = "1"; a[0, 1] = "2"; a[0, 2] = "3"; a[1, 0] = "4"; a[1, 1] = "5"; a[1, 2] = "6"; a[2, 0] = "7"; a[2, 1] = "8"; a[2, 2] = "9";
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";
            hod = 1;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/goncharivskyy");
        }


        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text != "Stop")
            {
                i = 0;
                _soundPlayer = new SoundPlayer(music[i]);
                button11.Text = "Stop";
                button12.Text = "Play";
                button13.Text = "Play";
                _soundPlayer.Stop();

                _soundPlayer.Play();
            }
            else
            { 
                _soundPlayer.Stop();
                button11.Text = "Play";
            }
           
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button12.Text != "Stop")
            {
                i = 1;
                _soundPlayer = new SoundPlayer(music[i]);
                button12.Text = "Stop";
                button11.Text = "Play";
                button13.Text = "Play";
                _soundPlayer.Stop();

                _soundPlayer.Play();
            }
            else
            {
                _soundPlayer.Stop();
                button12.Text = "Play";
            }
           
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (button13.Text != "Stop")
            {
                i = 2;
                _soundPlayer = new SoundPlayer(music[i]);
                button13.Text = "Stop";
                button11.Text = "Play";
                button12.Text = "Play";
                _soundPlayer.Stop();

                _soundPlayer.Play();
            }
            else
            {
                _soundPlayer.Stop();
                button13.Text = "Play";
            }
        }
    }
}
