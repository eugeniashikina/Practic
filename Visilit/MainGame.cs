using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Visilit
{
    public partial class MainGame : Form
    {
        //экземпляр класса выбора категорий
        ChosseCategory cc = new ChosseCategory();
        //компьютер
        CompGame comp;
        //слова для игры с компьютером
        private string word, wordForComp;
        //алфавит
        private string[] alf = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        //размер кнопки
        private int buttonSize = 35;
        //изображения
        private List<Image> img;
        //кол-во ошибок
        private int attempt;

        /// <summary>
        /// записывает все изображения для виселицы
        /// </summary>
        public MainGame()
        {
            InitializeComponent();
            img = new List<Image>() { Properties.Resources._0, Properties.Resources._1, Properties.Resources._2_, Properties.Resources._3,
                Properties.Resources._4, Properties.Resources._5, Properties.Resources._6, Properties.Resources._7};
        }

        /// <summary>
        /// смена картинок в соответствии с ошибками
        /// </summary>
        private void errorAnswer()
        {
            attempt++;
            pictureBox1.Image = img[attempt];
        }

        /// <summary>
        /// выбор категории
        /// </summary>
        public void chosse(object sender, EventArgs e)
        {
            this.Hide();
            cc.ShowDialog();
            word = cc.WordForGame();
            wordForComp = cc.WordForGameForComp();
            shifr(word, wordForComp);
            comp = new CompGame(wordForComp, label5.Text);
            AddButtons();
            label1.Text = "Ваша категория: " + cc.CategoryForGame().ToString();
            this.Show();
            button1.Enabled = false;
        }

        /// <summary>
        /// обработчик события нажатия на кнопку
        /// </summary>
        private void obrobotchik(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            if (proverka(((Button)sender).Text) == true)
            {
                MessageBox.Show("Вы угадали букву");
                PlayGameWithComp();
            }
            else
            {
                MessageBox.Show("Вы не угадали букву");
                errorAnswer();
                PlayGameWithComp();
            }
            if (label2.Text == word)
            {
                MessageBox.Show("Вы выиграли");
                clear();
                button1.Enabled = true;
            }
            else if (wordForComp == label5.Text)
            {
                MessageBox.Show("Вы проиграли, компьютер выиграл");
                clear();
                MessageBox.Show("Выберите категорию");
                button1.Enabled = true;
            }
            else if (attempt == 7)
            {
                MessageBox.Show("Вы проиграли");
                clear();
                MessageBox.Show("Выберите категорию");
                button1.Enabled = true;
            }
            else if (comp.RetunrError() == 7)
            {
                MessageBox.Show("Компьютер проиграл, вы победили");
                clear();
            }
        }

        /// <summary>
        /// выполняет ход компьютера
        /// </summary>
        private void PlayGameWithComp()
        {
            comp.PlayGame();
            label5.Text = comp.ReturnShift();
            label4.Text = "Ошибки: " + comp.RetunrError() + " из 7";
        }

        /// <summary>
        /// очищает поле
        /// </summary>
        private void clear()
        {
            panel1.Controls.Clear();
            attempt = 0;
            label5.Text = "";
            label4.Text = "Ошибки";
            label2.Text = "";
            label1.Text = "Категории:";
            pictureBox1.Image = Properties.Resources._0;
            button1.Enabled = true;
        }

        /// <summary>
        /// проверка слова на наличие выбранной пользователем буквы
        /// </summary>
        /// <param name="letter">буква</param>
        /// <returns>да или нет</returns>
        private bool proverka(string letter)
        {
            bool fg = false;
            char[] slovo = label2.Text.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                if (letter == word[i].ToString())
                {
                    for (int j = 0; j < slovo.Length; j++)
                    {
                        if (i == j)
                        {
                            slovo[j] = letter[0];
                            label2.Text = new string(slovo);
                        }
                    }
                    fg = true;
                }
            }
            return fg;
        }

        /// <summary>
        /// шифрование слова символами
        /// </summary>
        /// <param name="word">слово для пользователя</param>
        /// <param name="wordForComp">слово для компьютера</param>
        private void shifr(string word, string wordForComp)
        {
            for (int i = 0; i < word.Length; i++)
                label2.Text += "*";
            for (int i = 0; i < wordForComp.Length; i++)
                label5.Text += "*";
        }

        /// <summary>
        /// добавление кнопок на панель
        /// </summary>
        private void AddButtons()
        {
            int numb = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Button button = new Button();
                    button.Text = alf[numb];
                    button.Location = new Point(j * buttonSize, i * buttonSize);
                    button.Size = new Size(buttonSize, buttonSize);
                    button.Click += obrobotchik;
                    panel1.Controls.Add(button);
                    numb++;
                }
            }
        }
    }
}
