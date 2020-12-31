using System;
using System.Collections.Generic;
using System.Linq;

namespace AnagramList
{
    public class AnagramList
    {
        /**
         * We do not want this information being accessible outside of it's class, it holds the words the user entered in
         */
        private readonly List<string> data;

        /**
         * Creates a new AnagramList that the user can add words into
         */
        public AnagramList()
        {
            data = new List<string>();
        }

        /**
         * Creates a new AnagramList with elements inside of it
         */
        public AnagramList(string[] elements)
        {
            data = new List<string>();
            foreach (string s in elements)
                data.Add(s);
        }

        /**
         * A method to add a new word into the AnagramList
         */
        public void Add(string element)
        {
            data.Add(element);
        }

        /**
         * A method that finds a matching word and any anagrams of that word
         * An Anagram is defined as "a word, phrase, or name formed by rearranging the letters of another, such as cinema, formed from iceman." - Oxford Languages
         */
        public List<string> FindMatch(string word)
        {
            // Check is there was nothing entered into the AnagramList, return null if so
            if (data.Count == 0)
                return null;

            // Iterate through each element of the AnagramList
            for (int i = 0; i < data.Count; i++)
            {
                // Check if there is a match to the exact word the user wants
                if (data[i].Equals(word))
                {
                    // Create a new List that holds strings which will hold matches that we find if they are anagrams and/or the word itself
                    List<string> matches = new List<string>
                    {

                        // Add the match into the List
                        data[i]
                    };

                    // Turn the match into a character array and sort it
                    char[] arr = data[i].ToCharArray();
                    Array.Sort(arr);

                    // Iterate through every element of the collection again (except ignore the index the word was found at first)
                    for (int j = 0; j < data.Count; j++)
                    {
                        // Ignore if the indexes match
                        if (i == j)
                            continue;

                        // Create a new character array of the object at index j and sort it
                        char[] ar = data[j].ToCharArray();
                        Array.Sort(ar);

                        // We use sorting for both arrays here cause then they both are equal in terms of characters occuring in sequential order

                        // We use System.Linq to check for equality in two arrays, in terms of their content
                        if (arr.SequenceEqual(ar))
                            // Add the match if it is an anagram
                            matches.Add(data[j]);
                    }

                    // We return ithe new List we created
                    return matches;
                }
            }

            // No matches were found so we return null to represent that
            return null;
        }
    }
}
