using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visilit
{
    public partial class ChosseCategory : Form
    {
        DataBase db = new DataBase();
        private string word;
        private string category;
       
        public ChosseCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChosseWord(db.returnCategory(0));
            category = button1.Text;
        }

        private void ChosseWord(string[] words)
        {
            Random R = new Random();
            int k = R.Next(0, words.Length);
            for (int i = 0; i < words.Length; i++)
                if (i == k)
                {
                    word = words[i];
                    break;
                }
            Close();
        }

        public string WordForGame()
        {
            return word;
        }
        public string CategoryForGame()
        {
            return category;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChosseWord(db.returnCategory(1));
            category = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChosseWord(db.returnCategory(2));
            category = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChosseWord(db.returnCategory(3));
            category = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChosseWord(db.returnCategory(4));
            category = button5.Text;
        }
    }
}
