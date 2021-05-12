using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Visilit
{
    public partial class MainGame : Form
    {
        ChosseCategory cc = new ChosseCategory();
        private string word;
        private string[] alf = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        private int buttonSize = 35;
        private List<Image> img;
        private int attempt;

        public MainGame()
        {
            InitializeComponent();
            img = new List<Image>() { Properties.Resources._0, Properties.Resources._1, Properties.Resources._2_, Properties.Resources._3,
                Properties.Resources._4, Properties.Resources._5, Properties.Resources._6, Properties.Resources._7};
        }

        private void errorAnswer()
        {
            attempt++;
            pictureBox1.Image = img[attempt];
        }
        public void chosse(object sender, EventArgs e)
        {
            this.Hide();
            cc.ShowDialog();
            word = cc.WordForGame();
            shifr(word);
            AddButtons();
            label1.Text = "Ваша категория: " + cc.CategoryForGame().ToString();
            this.Show();
        }

        private void obrobotchik(object sender, EventArgs e)
        {
            ((Button)sender).Enabled = false;
            if (proverka(((Button)sender).Text) == true)
                MessageBox.Show("Вы угадали букву");
            else
            {
                MessageBox.Show("Вы не угадали букву");
                errorAnswer();
            }
            if (label2.Text == word)
            {
                MessageBox.Show("Вы выиграли");
                clear();
            }
            else if (attempt == 7)
            {
                MessageBox.Show("Вы проиграли");
                clear();
                MessageBox.Show("Выберите категорию");
            }

        }
        private void clear()
        {
            panel1.Controls.Clear();
            attempt = 0;
            label2.Text = "";
            label1.Text = "Категории:";
            pictureBox1.Image = Properties.Resources._0;
        }

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

        private void shifr(string word)
        {
            for (int i = 0; i < word.Length; i++)
                label2.Text += "*";
        }

        private void AddButtons()
        {
            int numb = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    Button button = new Button();
                    button.Text = alf[numb];
                    button.Location = new Point(j * buttonSize, i*buttonSize);
                    button.Size = new Size(buttonSize, buttonSize);
                    button.Click += obrobotchik;
                    panel1.Controls.Add(button);
                    numb++;
                }
            }
        }
    }
}
