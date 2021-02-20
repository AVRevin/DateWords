using System;

namespace DateWords
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalizeString analizeString = new AnalizeString(Console.ReadLine());
            analizeString.MethodFillingTheArray();
            Console.WriteLine(analizeString.MethodAnalizeList());
        }
    }
}
