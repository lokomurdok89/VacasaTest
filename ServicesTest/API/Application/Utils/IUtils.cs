
namespace API.Utils
{
    public interface IUtils
    {
#region  simple plus
        bool ValidateSumFormat(string input);        
        string GenerateSimplePlus(string input);

#endregion

#region Count the number of words-consonants-vowels
        string CountNumberOfWords(string q);
        bool ValidateCountNumberOfWords(string q);
#endregion

#region Combinations
        bool ValidateListFormatCombination(string q);
        string GenerateOutputList(string q);
#endregion
         
#region displaying these in a 2-D grid
         string VisualizeCharacters2D(string q);
         bool Validate2D(string q);
#endregion

        string GetRandomAnswer(string q);

    }
}