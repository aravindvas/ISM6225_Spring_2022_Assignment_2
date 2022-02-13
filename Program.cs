/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK
*/

using System;
using System.Collections.Generic;

namespace ISM6225_Assignment_2_Spring_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 1, 3, 5, 6 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");
            
            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit, a ball, the hit BALL, flew far after, it was the hit.";
            string[] banned = { "hit", "ball"};
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is \'{0}\'", commonWord);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 2, 3, 3 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "112233";
            string guess = "013234";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is : {0}", hint);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            string s = "eccbbbbdec";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 4, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "bbbcccdddaaa";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();
            
            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "[{(}])";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();
            
            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();
           
        }
        /*
         Question 5:
         You are given a string s. We want to partition the string into as many parts as possible so that each letter appears in at most one part.
         Return a list of integers representing the size of these parts.
         Example 1:
         Input: s = "ababcbacadefegdehijhklij"
         Output: [9,7,8]
         Explanation:
         The partition is "ababcbaca", "defegde", "hijhklij".
         This is a partition so that each letter appears in at most one part.
         A partition like "ababcbacadefegde", "hijhklij" is incorrect, because it splits s into less parts.
         */

        public static List<int> PartitionLabels(string s)
        {
            try
            {
                int x = -1;
                int maxValue = 0;
                int[] lastIndex = new int[s.Length];
                List<int> divStringsIndex = new List<int>();
                List<string> divStrings = new List<string>();
                for (int j = 0; j < s.Length; j++)
                {
                    lastIndex[j] = s.LastIndexOf(s[j]);
                }
                //storing all the last occurances in the given string
                for (int i = 0; i<s.Length; i++)
                {
                    if (maxValue != i)
                    {
                        maxValue = Math.Max(maxValue, lastIndex[i]);
                        //getting the max value before it matches i
                    }
                    if (maxValue == i)
                    {
                        maxValue = s.LastIndexOf(s[i]);
                        if (i != 0)
                        {
                            divStrings.Add(s.Substring(x + 1, maxValue - x));
                            x = i;
                            //getting rid of the 1st execution
                        }
                    }
                }

                for(int k = 0; k<divStrings.Count; k++)
                {
                    divStringsIndex.Add(divStrings[k].Length);
                    //storing all the lengths of seperated strings in a list 
                }
                return divStringsIndex;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /*
        Question 8
        International Morse Code defines a standard encoding where each letter is mapped to a series of dots and dashes, as follows:
        •	'a' maps to ".-",
        •	'b' maps to "-...",
        •	'c' maps to "-.-.", and so on.
        For convenience, the full table for the 26 letters of the English alphabet is given below:
        [".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."]
        Given an array of strings words where each word can be written as a concatenation of the Morse code of each letter.
        •	For example, "cab" can be written as "-.-..--...", which is the concatenation of "-.-.", ".-", and "-...". We will call such a concatenation the transformation of a word.
        Return the number of different transformations among all words we have.

        Example 1:
        Input: words = ["gin","zen","gig","msg"]
        Output: 2
        Explanation: The transformation of each word is:
        "gin" -> "--...-."
        "zen" -> "--...-."
        "gig" -> "--...--."
        "msg" -> "--...--."
        There are 2 different transformations: "--...-." and "--...--.".
        */

        public static int UniqueMorseRepresentations(string[] words)
            {
                try
                {
                    string alpha = "abcdefghijklmnopqrstuvwxyz";
                    string[] concatedMorse = new string[words.Length];
                    List<string> disctictMorse = new List<string>();
                    int total = 0;
                    string[] morseGiven = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                    //storing the given morse values to an array
                    Dictionary<char, string> alphaMorse = new Dictionary<char, string>();
                    for(int i = 0; i<26; i++)
                    {
                        alphaMorse[alpha[i]] = morseGiven[i];
                        //assigning the values of charecters in alphabets to respective morse codes 
                    }
                    for(int j = 0; j<words.Length; j++)
                    {
                        for(int k = 0; k<words[j].Length; k++)
                        {
                            concatedMorse[j] = string.Concat(concatedMorse[j], alphaMorse[words[j][k]]);
                            //concating morse codes for a charecters in a given string
                        }  
                    }
                    for(int l = 0; l< concatedMorse.Length; l++)
                    {
                        if (!disctictMorse.Contains(concatedMorse[l]))
                        {
                            disctictMorse.Add(concatedMorse[l]);
                            //if a string is not found, then adding it to a new list, to get distinct values
                        }
                    }
                    total = disctictMorse.Count;
                    return total;
                    //returning distinct values of morse codes found after converting a string to morse code
                }
                catch (Exception)
                {
                    throw;
                }

            }
            /*

            Question 7:
            Given a string bulls_string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.
            An input string is valid if:
                1.	Open brackets must be closed by the same type of brackets.
                2.	Open brackets must be closed in the correct order.

            Example 1:
            Input: bulls_string = "()"
            Output: true
            Example 2:
            Input: bulls_string  = "()[]{}"
            Output: true
            Example 3:
            Input: bulls_string  = "(]"
            Output: false
            */

            public static bool IsValid(string bulls_string10)
        {
            try
            {
                bool validBoolChar = false;                
                if (bulls_string10.Contains('(') && bulls_string10.Contains(')'))
                {
                    //checking for the valid charecters of a string
                    validBoolChar = false;
                    validBoolChar = bulls_string10.IndexOf(')') > bulls_string10.IndexOf('(');
                    //if found checking whether they are closed in a correct order
                }
                if (bulls_string10.Contains('[') && bulls_string10.Contains(']'))
                {
                    validBoolChar = false;
                    validBoolChar = bulls_string10.IndexOf(']') > bulls_string10.IndexOf('[');
                }
                if (bulls_string10.Contains('{') && bulls_string10.Contains('}'))
                {
                    validBoolChar = false;
                    validBoolChar = bulls_string10.IndexOf('}') > bulls_string10.IndexOf('{');
                }
                return validBoolChar;
                //returning the final boolean after going through all validations
            }
            catch (Exception)
            {
                throw;
            }


        }
        /*
       Question 6
       You are given a string s of lowercase English letters and an array widths denoting how many pixels wide each lowercase English letter is. Specifically, widths[0] is the width of 'a', widths[1] is the width of 'b', and so on.
       You are trying to write s across several lines, where each line is no longer than 100 pixels. Starting at the beginning of s, write as many letters on the first line such that the total width does not exceed 100 pixels. Then, from where you stopped in s, continue writing as many letters as you can on the second line. Continue this process until you have written all of s.
       Return an array result of length 2 where:
            •	result[0] is the total number of lines.
            •	result[1] is the width of the last line in pixels.

       Example 1:
       Input: widths = [10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], s = "abcdefghijklmnopqrstuvwxyz"
       Output: [3,60]
       Explanation: You can write s as follows:
                    abcdefghij  	 // 100 pixels wide
                    klmnopqrst  	 // 100 pixels wide
                    uvwxyz      	 // 60 pixels wide
                    There are a total of 3 lines, and the last line is 60 pixels wide.
        Example 2:
        Input: widths = [4,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10,10], 
        s = "bbbcccdddaaa"
        Output: [2,4]
        Explanation: You can write s as follows:
                     bbbcccdddaa  	  // 98 pixels wide
                     a           	 // 4 pixels wide
                     There are a total of 2 lines, and the last line is 4 pixels wide.
        */

        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {
                string alpha = "abcdefghijklmnopqrstuvwxyz";
                int sum = 0, lines=1;
                Dictionary<char, int> stWidth = new Dictionary<char, int>();
                //initializing a dictonary to store widths of the alphabets
                for(int x = 0; x<26; x++)
                {
                    stWidth[alpha[x]] = widths[x];
                    //assigning widths to respective alphabets using dictonaries
                }
                for(int y = 0; y<s.Length; y++)
                {
                    if (alpha.Contains(s[y]))
                    //if alphabets contains the given string, adding their respective widths 
                    {
                        if(sum <= 100)
                        {
                            sum += stWidth[s[y]];
                        }
                        if(sum > 100)
                        {
                            sum = stWidth[s[y]];
                            lines++;
                        }
                    }
                    
                }
                return new List<int>() {lines, sum};
                //returning a list that contains lines and sum
            }
            catch (Exception)
            {
                throw;
            }

        }

        /*
        
        Question 4:
        You are playing the Bulls and Cows game with your friend.
        You write down a secret number and ask your friend to guess what the number is. When your friend makes a guess, you provide a hint with the following info:
        •	The number of "bulls", which are digits in the guess that are in the correct position.
        •	The number of "cows", which are digits in the guess that are in your secret number but are located in the wrong position. Specifically, the non-bull digits in the guess that could be rearranged such that they become bulls.
        Given the secret number secret and your friend's guess guess, return the hint for your friend's guess.
        The hint should be formatted as "xAyB", where x is the number of bulls and y is the number of cows. Note that both secret and guess may contain duplicate digits.
 
        Example 1:
        Input: secret = "1807", guess = "7810"
        Output: "1A3B"
        Explanation: Bulls relate to a '|' and cows are underlined:
        "1807"
          |
        "7810"
        */

        public static string GetHint(string secret, string guess)
        {
            try
            {
                int bulls=0, cows=0;
                string outHint;
                int[] guessIntArr = new int[10];
                int[] secretIntArr = new int[10];
                for (int x = 0; x < secret.Length; x++)
                {
                    if (secret[x] == guess[x])
                    //checking if the guest and secret index matches
                    {
                        bulls++;
                        //if matched increasing the bull count
                    }
                    else
                    {
                        //if not creating an array of integers and storing the count of respective itegers
                        guessIntArr[guess[x] - '0']++;
                        secretIntArr[secret[x] - '0']++;
                    }
                }
                for (int i = 0; i<10; i++)
                {
                    if(guessIntArr[i] != 0 && secretIntArr[i] != 0)
                    //if both doenot contain 0, it means there is a matching element but not alligned to the correct position 
                    {
                        cows++;
                        //so increasing number of cows
                    }
                }
                outHint = bulls+"A"+cows+"B";
                return outHint;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /*
        Question 3:
        Given an array of integers arr, a lucky integer is an integer that has a frequency in the array equal to its value.
        Return the largest lucky integer in the array. If there is no lucky integer return -1.
 
        Example 1:
        Input: arr = [2,2,3,4]
        Output: 2
        Explanation: The only lucky number in the array is 2 because frequency[2] == 2.
        Example 2:
        Input: arr = [1,2,2,3,3,3]
        Output: 3
        Explanation: 1, 2 and 3 are all lucky numbers, return the largest of them.
        Example 3:
        Input: arr = [2,2,2,3,3]
        Output: -1
        Explanation: There are no lucky numbers in the array.
         */

        public static int FindLucky(int[] arr)
        {
            try
            {
                int large = 1;
                int outLuck = -1;
                //if there is no lucky number in a given array, it is initially set to -1
                Dictionary<int, int> freqInt = new Dictionary<int, int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (freqInt.ContainsKey(arr[i]))
                    //counting the frequecy of given numbers in the array of numbers
                    {
                        freqInt[arr[i]]++;
                    }
                    else
                    {
                        freqInt[arr[i]] = 1;
                    }
                }
                foreach(KeyValuePair<int, int> x in freqInt)
                {
                    if(x.Key == x.Value)
                    //checking for the lucky numbers if the given numbers are matched with the frequency of the respective given numbers
                    {
                        if (large < x.Value)
                        //after finding lucky number finding the most freuently repeated number
                        {
                            large = x.Value;
                            outLuck = x.Key;
                            //returning the final output key
                        } 
                    }  
                }
                return outLuck;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /*
        Question 2
       
        Given a string paragraph and a string array of the banned words banned, return the most frequent word that is not banned.It is guaranteed there is at least one word that is not banned, and that the answer is unique.
        The words in paragraph are case-insensitive and the answer should be returned in lowercase.
        Example 1:
        Input: paragraph = "Bob hit a far ball, the hit BALL flew far after it was hit.", banned = ["hit"]
        Output: "ball"
        Explanation: "hit" occurs 3 times, but it is a banned word. "ball" occurs twice (and no other word does), so it is the most frequent non-banned word in the paragraph.
        Note that words in the paragraph are not case sensitive, that punctuation is ignored (even if adjacent to words, such as "ball,"), and that "hit" isn't the answer even though it occurs more because it is banned.
        Example 2:
        Input: paragraph = "a.", banned = []
        Output: "a"
        */

        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                int large = 1;
                bool exit = true;
                string op="";
                char[] missc = { '"', ' ', '!', '?', ',', ';', '.', '\'' };
                string[] str = paragraph.ToLower().Split(missc);
                //spliting the given paragraph into an array of strings by eliminating the delimmiters
                Dictionary<string, int> freq = new Dictionary<string, int>();
                //declaring a dictonary assigning key as strings and values as int 
                for (int i = 0; i<str.Length; i++)
                {
                    if (freq.ContainsKey(str[i]))
                    //checking whether the key is already in the dictonary
                    {
                        freq[str[i]]++;
                        //if found adding 1 to the value(frequency) for that specific key(string) which is found to be repeatative
                    }
                    else
                    {
                        freq[str[i]] = 1;
                        //if not found setting it to 1
                    }
                }
                foreach(KeyValuePair<string, int> x in freq)
                {
                    exit = true;
                    foreach (string y in banned)
                    //checking for the banned strings and empty strings
                    {
                        if ((x.Key == y) || (x.Key == ""))
                        {
                            exit = false;
                        }
                    }
                    if (exit)
                    {
                        if (large < x.Value)
                        //checking for the large value and passing it to the output
                        {
                            large = x.Value;
                            op = x.Key;
                        }
                    }
                            
                }
                return op;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /*
        
        Question 1:
        Given a sorted array of distinct integers and a target value, return the index if the target is found. If not, return the index where it would be if it were inserted in order.
        Note: The algorithm should have run time complexity of O (log n).
        Hint: Use binary search
        Example 1:
        Input: nums = [1,3,5,6], target = 5
        Output: 2
        Example 2:
        Input: nums = [1,3,5,6], target = 2
        Output: 1
        Example 3:
        Input: nums = [1,3,5,6], target = 7
        Output: 4
        */

        public static int SearchInsert(int[] nums, int target)
        {
            try
            {
                int x=0;
                for (int i = 0; i<nums.Length; i++)
                {
                    if(nums[i] == target)
                    {
                        x = Array.IndexOf(nums,target);
                        //finding the index of target value in the given array
                        break;
                    }
                    else if(target > nums[i])
                    //if not found setting it finding an index where it can fit if it was inside the given array
                    {
                        x = Array.IndexOf(nums, nums[i])+1;
                    }
                 
                }
                return x;
            }
            catch (Exception)
            {
                throw;
            }
        }

    
    
    }
}