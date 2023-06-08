using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Application.Core
{
    public class NumberWord:SimplePlus
    {
        public static string CountNumberOfWords(string q){
            string[] words = q.Trim().Split(' ');
            int consonants = 0;
            int vowels = 0;
            
            foreach (string word in words)
            {
                consonants += word.Count(c => char.IsLetter(c) && !"AEIOUaeiou".Contains(c));
                vowels += word.Count(c => "AEIOUaeiou".Contains(c));
            }            
            return $"{words.Length}-{consonants}-{vowels}";
        }
        public static bool ValidateCountNumberOfWords(string q){
                return !ValidateSumFormat(q) && !((q.Contains('?') || q.Contains('<'))) && (RandomResponse.ValidateRandomQuestions(q));

        }
    }
}