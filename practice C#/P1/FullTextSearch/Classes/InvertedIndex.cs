using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class InvertedIndex : IInvertedIndex
{
    public Dictionary<string, List<string>> InvertedFileDictIndex(Dictionary<string, string> filesDictionary)
    {
        Dictionary<string, List<string>> invertedIndex = new Dictionary<string, List<string>>();

        
        foreach (KeyValuePair<string, string> file in filesDictionary)
        {
            string[] words = file.Value.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                if (!invertedIndex.ContainsKey(word))
                {
                    invertedIndex[word] = new List<string>();
                }

                invertedIndex[word].Add(file.Key);
            }
        }

        return invertedIndex;
    }
}