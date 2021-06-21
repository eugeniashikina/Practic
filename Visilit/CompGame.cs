using System;
using System.Collections.Generic;

namespace Visilit
{
    /// <summary>
    /// игра компьютера
    /// </summary>
    public class CompGame
    {
        // алфавит
        private string[] alf = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
        //слово
        private string word;
        //шифрование слова 
        private string shifr;
        //ошибки, допущенные компьютером
        private int ErrorAnswer;

        /// <summary>
        /// передача компьютеру зашифрованного слова
        /// </summary>
        /// <param name="word">слово</param>
        /// <param name="shifr">зашифрованное слово</param>
        public CompGame(string word, string shifr)
        {
            this.word = word;
            this.shifr = shifr;
            ErrorAnswer = 0;
        }

        /// <summary>
        /// игра компьютера
        /// </summary>
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

        /// <summary>
        /// проверка слова на наличие выбранной пользователем буквы
        /// </summary>
        /// <param name="letter">буква</param>
        /// <returns>да или нет</returns>
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

        /// <summary>
        /// возвращает ошибки, допущенные компьютером
        /// </summary>
        /// <returns>ошибки</returns>
        public int RetunrError()
        {
            return ErrorAnswer;
        }

        /// <summary>
        /// возвращает зашифрованное слово
        /// </summary>
        /// <returns>зашифрованное слово</returns>
        public string ReturnShift()
        {
            return shifr;
        }
    }
}
