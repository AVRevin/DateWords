using System;
using System.Collections.Generic;
using System.Text;


namespace DateWords
{
    public class AnalizeWords
    {
        #region // Словари
        Dictionary<int, string> firstdictionary = new Dictionary<int, string>
        {
            [1] = "оди",
            [2] = "дв",
            [3] = "три",
            [4] = "чет",
            [5] = "пят",
            [6] = "шес",
            [7] = "сем",
            [8] = "вос",
            [9] = "дев",
            [10] = "дес",
            [40] = "сор",
            [100] = "сто",
        };
        Dictionary<int, string> seconddictionary = new Dictionary<int, string>
        {
            [11] = "одиннад",
            [12] = "двенад",
            [13] = "тринад",
            [14] = "четырнад",
            [15] = "пятнад",
            [16] = "шестнад",
            [17] = "семнад",
            [18] = "восемнад",
            [19] = "девятнад",
        };
        string[] endwords = new string[] { "надцать", "десят", "дцать", "рок", "вяносто", "сто", "двести", "триста", "реста", "сот" };
        int result = 0;
        #endregion

        #region // Метод для анализа слова и получения цифры
        public int MethodRoot(string word)
        {
            // Проверяем на второй десяток
            if (word.Contains(endwords[0]))
            {
                foreach (KeyValuePair<int, string> item in seconddictionary)
                {
                    if (word.Contains(item.Value) && word[0] == item.Value[0])
                    {
                        result = item.Key;
                        return result;
                    }
                }
            }
            // Проверяем на десятки
            if (word.Contains(endwords[1])|| word.Contains(endwords[2])|| word.Contains(endwords[3])|| word.Contains(endwords[4]))
            {
                foreach (KeyValuePair<int, string> item in firstdictionary)
                {
                    if (word.Contains(item.Value) && word[0] == item.Value[0])
                    {
                        if (item.Key==10||item.Key==40)
                        {
                            result = item.Key;
                            return result;
                        }
                        result = item.Key*10;
                        return result;
                    }
                }
            }
            // Проверяем на сотни
            if (word.Contains(endwords[5]) || word.Contains(endwords[6]) || word.Contains(endwords[7]) || word.Contains(endwords[8]) || word.Contains(endwords[9]))
            {
                foreach (KeyValuePair<int, string> item in firstdictionary)
                {
                    if (word.Contains(item.Value) && word[0] == item.Value[0])
                    {
                        if (item.Key == 100)
                        {
                            result = item.Key;
                            return result;
                        }
                        result = item.Key*100;
                        return result;
                    }
                }
            }
            // Проверяем на первый десяток
            foreach (KeyValuePair<int,string> item in firstdictionary)
            {
                if (word.Contains(item.Value)&&word[0]==item.Value[0])
                {
                   result = item.Key;
                   return result;
                }
            }
            return result;
        }
        #endregion
    }
}
