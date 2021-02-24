using System;
using System.Collections.Generic;
using System.Text;


namespace DateWords
{
    public class СonstructorWords
    {
         private readonly int    _returndigit;
         private readonly string _firstposition;
         private readonly string _firstsecondposition;
         private readonly string _secondposition; 
         private readonly string _thirdposition; 

        public СonstructorWords (int returndigit, string firstposition,string firstsecondposition, string secondposition, string thirdposition)
        {
            _returndigit = returndigit;
            _firstposition = firstposition;
            _firstsecondposition = firstsecondposition;
            _secondposition = secondposition;
            _thirdposition = thirdposition;
        }

        public string Getfirstsecondposition() => _firstposition + _firstsecondposition;
        public string GetSecondPosition() => _firstposition + _secondposition;
        public string GetThirdPosition() => _firstposition + _thirdposition;


        public bool ReceiveTime(string wordtime, out int digittime)
        {
            digittime = default;
            if (string.Equals(wordtime, Getfirstsecondposition(), StringComparison.OrdinalIgnoreCase))
            {

                digittime = _returndigit + 10;
                return true;
            }
            if (string.Equals(wordtime, GetSecondPosition(), StringComparison.OrdinalIgnoreCase))
            {

                digittime = _returndigit*10;
                return true;
            }
            if (string.Equals(wordtime, GetThirdPosition(), StringComparison.OrdinalIgnoreCase))
            {
                digittime = _returndigit * 100;
                return true;
            }
            if (string.Equals(wordtime, _secondposition, StringComparison.OrdinalIgnoreCase))
            {
                digittime = _returndigit*10;
                return true;
            }
            if (string.Equals(wordtime, _thirdposition, StringComparison.OrdinalIgnoreCase))
            {
                digittime = _returndigit*100;
                return true;
            }
            if (string.Equals(wordtime, _firstposition, StringComparison.OrdinalIgnoreCase))
            {
                digittime = _returndigit;
                return true;
            }
            if (wordtime.Contains(_firstposition))
            {
                digittime = _returndigit;
                return true;
            }
            return false;
        }
    }

    public class NormalNumber:INumberInterface<СonstructorWords>
    {
        private readonly List<СonstructorWords> _constructor = new List<СonstructorWords>
        {
              new СonstructorWords(1 , "од","иннадцать", "десять", "сто"),
              new СonstructorWords(2 , "дв","енадцать","адцать", "ести"),
              new СonstructorWords(3 , "три","надцать", "дцать", "ста"),
              new СonstructorWords(4, "четыр","надцать", "сорок", "еста"),
              new СonstructorWords(5 , "пят","надцать", "десят", "ьсот"),
              new СonstructorWords(6 , "шест","надцать", "десят", "ьсот"),
              new СonstructorWords(7 , "сем","надцать", "десят", "ьсот"),
              new СonstructorWords(8 , "восем","надцать", "десят", "ьсот"),
              new СonstructorWords(9 , "девят","надцать", "девяносто", "ьсот"),
        };

        public int GetIntDigit(string wordtime)
        {
            int timeValue = 0;
            foreach (var item in _constructor)
            {
                if (item.ReceiveTime(wordtime,out timeValue))
                {
                    break;
                }
            }
            return timeValue;
        }     
    }
}

