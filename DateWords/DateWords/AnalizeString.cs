using System;
using System.Collections.Generic;
using System.Text;

namespace DateWords
{
    class AnalizeString
    {
        AnalizeWords analizewords = new AnalizeWords();

        #region // создание полей и свойств
        string incoming = null;
        string temp = null;
        int count = 0; // счетчик
        int result = 0; // результат окончательный в цифре
        //public string[] words = new string[20]; // массив слов
        Dictionary<int, string> ticks = new Dictionary<int, string>
        {
            [1] = "мин",
            [60] = "час",
            [1440] = "д"

        };
        List<string> list = new List<string>();

        public AnalizeString(string incoming)
        {
            this.incoming = incoming;
        }
        #endregion

        #region// метод для заполнения массива слов словами
        public void MethodFillingTheArray()
        {

            while (count != incoming.Length)
            {
                for (int i = count; i < incoming.Length; i++)
                {

                    if (incoming[i] != ' ')
                        {
                            temp += incoming[i];
                            count++;
                            if (i == incoming.Length - 1)
                            {
                                list.Add(temp);
                                temp = null;
                                break;
                            }
                        }
                    else
                        {
                            list.Add(temp);
                            temp = null;
                            count++;
                            break;
                        }
                }
            }
        }   
        
        #endregion

        #region // метод вывода нужного времени
    public DateTime MethodAnalizeList()
    {
        string wordtime = null; // слово времени (минута, час, день)
        DateTime dateTime = DateTime.Now;
        // цикл для получения цифры из слова и инициализация поля wordtime
        for (int i = list.ToArray().Length - 1; i >= 0; i--)
        {
            if (i == list.ToArray().Length - 2)
            {
                wordtime = list[i];
            }
            if (i != list.ToArray().Length - 1 && i != list.ToArray().Length - 2)
            {
                result += analizewords.MethodRoot(list[i]);
            }
        }
        // цикл движения вперед или назад
        foreach (var item in ticks)
        {
            if (wordtime.Contains(item.Value) && list.Contains("вперед"))
            {
                return DateTime.Now.AddMinutes((double)item.Key * result);
            }
            if (wordtime.Contains(item.Value) && list.Contains("назад"))
            {
                return DateTime.Now.AddMinutes(-(double)item.Key * result);
            }
        }

        return dateTime;
    }
    #endregion
    }

}





