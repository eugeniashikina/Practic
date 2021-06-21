﻿using System.Collections.Generic;

namespace Visilit
{
    /// <summary>
    /// бд
    /// </summary>
    public class DataBase
    {
        /// <summary>
        /// категории со входящими в них словами
        /// </summary>
        private string[] животные = { "жираф", "сурикат", "гепард", "пингвин", "опоссум", "медведь", "муравьед", "рысь", "гиена", "динозавр" };
        private string[] ягоды = { "клубника", "черника", "арбуз", "малина", "крыжовник", "облепиха", "морошка", "голубика", "ежевика", "черешня" };
        private string[] города = { "амстердам", "лондон", "стокгольм", "вронеж", "париж", "адыгейск", "балашиха", "донецк", "иркутск", "мирный" };
        private string[] марки_авто = { "тойота", "мерседес", "бентли", "инфинити", "лада", "ауди", "бмв", "порше", "лексус", "форд" };
        private string[] одежда = { "свитшот", "пуловер", "куртка", "худи", "джинсы", "носки", "футболка", "шорты", "майка", "толстовка" };

        /// <summary>
        /// возврат выбранной категории
        /// </summary>
        /// <param name="number">номер выбранной категории</param>
        /// <returns>категория</returns>
        public string[] returnCategory(int number)
        {
            List<string[]> category = new List<string[]>() { животные, ягоды, города, марки_авто, одежда };
            return category[number];
        }
    }
}
