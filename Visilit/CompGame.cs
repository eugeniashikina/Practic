using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visilit
{
    public class CompGame
    {
        private string[] alf = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };

        private string word;
        private string shifr;
        private int ErrorAnswer;

        public CompGame(string word, string shifr)
        {
            this.word = word;
            this.shifr = shifr;
            ErrorAnswer = 0;
        }

        public void PlayGame()
        {
            Random R = new Random();
            List<int> word = new List<int>();
            int chek = R.Next(0, 33);
            if (!word.Contains(chek))
            {
                word.Add(chek);
                if (proverka(alf[chek]) == false)
                    ErrorAnswer++;
            }
        }

        private bool proverka(string letter)
        {
            bool fg = false;
            char[] slovo = shifr.ToCharArray();
            for (int i = 0; i < word.Length; i++)
            {
                if (letter == word[i].ToString())
                {
                    for (int j = 0; j < slovo.Length; j++)
                    {
                        if (i == j)
                        {
                            slovo[j] = letter[0];
                            shifr = new string(slovo);
                        }
                    }
                    fg = true;
                }
            }
            return fg;
        }

        public int RetunrError()
        {
            return ErrorAnswer;
        }

        public string ReturnShift()
        {
            return shifr;
        }
    }
}
