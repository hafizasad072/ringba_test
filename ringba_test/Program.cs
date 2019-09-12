using ringba_test.Helpers;
using System;

namespace ringba_test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IOHelper.DownloadFile();

            Console.WriteLine("How many of each letter are in the file.");
            StringHelper.CountEachLetter();

            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("How many letters are capitalized in the file.");
            StringHelper.CountCapitalizedLetter();

            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("The most common word and the number of times it has been seen.");
            StringHelper.CountMostCommanWord();

            Console.WriteLine("-------------------------------------------------");

            Console.WriteLine("The most common 2 character prefix and the number of occurrences in the text file.");
            StringHelper.CountMostCommonPrefix();

            Console.ReadLine();
        }
    }
}
