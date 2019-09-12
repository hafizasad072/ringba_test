using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ringba_test.Helpers
{
    public static class StringHelper
    {
        // Read entire input file.
        private static string fileText = File.ReadAllText(AppConstants.Constants.FilePath);
        internal static void CountEachLetter()
        {
            // Group All Characters and then make count of each character.
            var alphabetsDetail = fileText.GroupBy(x => x)
                         .Select(x => new
                         {
                             Char = x.Key,
                             Count = x.Count()
                         });

            // Print Details
            foreach (var c in alphabetsDetail)
            {
                Console.WriteLine("Letter: {0}  Count: {1}", c.Char, c.Count);
            }
        }
        internal static void CountCapitalizedLetter()
        {

            int capitalizedCount = string.Join("", Regex
              .Matches(fileText, "[A-Z]")
              .OfType<Match>()
              .Select(match => match.Value)).Count();
            Console.WriteLine("Capital Letters Count: {0}", capitalizedCount);
        }
        internal static void CountMostCommanWord()
        {
            var CommanWord = SplitCamelCase()
              .GroupBy(c => c)
              .Select(c => new KeyValuePair<string, int>(c.Key.ToString(), c.Count()))
              .OrderByDescending(c => c.Value).FirstOrDefault();
            Console.WriteLine("Word: {0}  Count: {1}", CommanWord.Key, CommanWord.Value);
        }
        internal static void CountMostCommonPrefix()
        {
            //Varibales
            string commonPrefix = "", commonPrefixDisplay = "";
            int ASCII_A = 'A', ASCII_Z = 'Z' + 1, ASCII_a = 'a', ASCII_z = 'z' + 1, commonPrefixCount = 0;

            //Nested loop to find Prefix 
            for (int x = ASCII_A; x < ASCII_Z; x++)
            {
                for (int y = ASCII_a; y < ASCII_z; y++)
                {
                    string pd = ((char)x).ToString() + ((char)y).ToString();
                    string prefix = pd + "[a-z]";
                    int Count = Regex.Matches(fileText, prefix).Count;

                    // Update Count and PRefix Logic
                    if (Count == commonPrefixCount)
                    {
                        commonPrefix += commonPrefix == "" ? prefix : " " + prefix;
                    }
                    else if (Count > commonPrefixCount)
                    {
                        commonPrefix = prefix;
                        commonPrefixDisplay = pd;
                        commonPrefixCount = Count;
                    }
                }
            }
            Console.WriteLine("Most Common Prefix: {0}  Count: {1}", commonPrefixDisplay, commonPrefixCount);
        }
        private static string[] SplitCamelCase()
        {
            return Regex.Split(fileText, @"(?<!^)(?=[A-Z])");
        }
    }
}
