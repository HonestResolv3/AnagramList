using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AnagramList
{
    class Program
    {
        /**
         * We can test out AnagramList here
         */
        static void Main()
        {
            // This test involves having multiple words that all are anagrams to "mary"

            // .FindMatch(string word) returns a List which has string objects inside it
            string[] test1 = { "mary", "tea", "java", "goog", "eat", "army", "gary", "ramy", "myra", "mary" };
            string word1 = "mary";

            // Create a new AnagramList DataStructure that will hold our words
            AnagramList list1 = new AnagramList(test1);

            // We call the .FindMatch(string word) method and see if there's any matches
            // Here we are expecting 
            List<string> matches = list1.FindMatch(word1);
            Debug.Assert(matches != null);
            WriteMatches(matches, word1);


            // This test involves having no words at all
            // We repeat the above process again
            string[] test2 = { };
            string word2 = "empty";

            AnagramList list2 = new AnagramList(test2);

            matches = list2.FindMatch(word2);
            Debug.Assert(matches == null);
            WriteMatches(matches, word2);

            // This test involves having words but there are no matches for part of a word
            // Similar to the first two, it uses the above process
            string[] test3 = { "testing", "works", "maybe", "yes", "no" };
            string word3 = "test";

            AnagramList list3 = new AnagramList(test3);

            matches = list3.FindMatch(word3);
            Debug.Assert(matches == null);
            WriteMatches(matches, word3);
        }

        /**
         * A method to write the results of the FindMatch() method call
         */
        static void WriteMatches(List<string> array, string word)
        {
            if (array == null)
                Console.WriteLine("\n" + word + " was not found in this AnagramList");
            else
            {
                Console.Write("[");
                foreach (string s in array)
                    Console.Write(s + ", ");
                Console.Write("]\n");
            }
        }
    }
}
