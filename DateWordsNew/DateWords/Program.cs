using System;

namespace DateWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string date = Console.ReadLine();
            var analyzer = new Analayzer();
            var timeSpan = analyzer.Analyze(date);

            if (date.Contains("вперед"))
            {
                Console.WriteLine(DateTime.Now.Add(timeSpan)); 
            }
            if (date.Contains("назад"))
            {
                Console.WriteLine(DateTime.Now.Add(-timeSpan));
            }
        }
    }
}
