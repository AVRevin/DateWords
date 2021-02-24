using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DateWords
{
    
    public class Analayzer 
    {
        private readonly List<TimeDemension> _demensions = new List<TimeDemension>
        {
            new TimeDemension("минут", "а", "ы", "", TimeSpan.FromMinutes(1)),
            new TimeDemension("час", "", "a", "ов", TimeSpan.FromHours(1)),
            new TimeDemension("д", "ень", "ня", "ней", TimeSpan.FromHours(1))
        };
        private readonly NormalNumber normalNumber = new NormalNumber();

        public TimeSpan Analyze(string time)
        {
            TimeSpan result = default; 
            // [сто сорок одни] [час]
            foreach ((var number, var marker) in EnumerateTimeMarkers(time))
            {
                TimeSpan timeValue = default;
                foreach(var timeDemension in _demensions)
                {
                    if (timeDemension.ExtractTime(marker, out timeValue))
                    {
                        break;
                    }
                }
                if (timeValue == default)
                {
                    continue;
                }

                result += timeValue * number;
                
            }

            return result;
        }

        private IEnumerable<(int number, string marker)> EnumerateTimeMarkers(string time)
        {

            int value = 0;
            foreach(var entry in time.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                
                var currentPoint = normalNumber.GetIntDigit(entry);
                value += currentPoint;
                if (currentPoint == 0)
                {
                    yield return (value, entry);
                    value = 0;
                }
            }
        }
    }

    public class TimeDemension
    {
        private readonly string _root;
        private readonly string _oneEnding;
        private readonly string _fewEndings; // 2-4
        private readonly string _manyEndings; // 5-20 
        private readonly TimeSpan _time;

        public TimeDemension(string root, string oneEnding, string fewEndings, string manyEndings, TimeSpan time)
        {
            _root = root;
            _oneEnding = oneEnding;
            _fewEndings = fewEndings;
            _manyEndings = manyEndings;
            _time = time;
        }

        public string GetOneNoun() => _root + _oneEnding;
        public string GetFewNoun() => _root + _fewEndings;
        public string GetManyNoun() => _root + _manyEndings;

        public bool ExtractTime(string timeDemension, out TimeSpan time)
        {
            time = default;
            if (string.Equals(timeDemension, GetOneNoun(), StringComparison.OrdinalIgnoreCase) ||
                string.Equals(timeDemension, GetFewNoun(), StringComparison.OrdinalIgnoreCase) ||
                string.Equals(timeDemension, GetManyNoun(), StringComparison.OrdinalIgnoreCase))
            {
                time = _time;
                return true;
            }
            return false;
        }
    }

}





