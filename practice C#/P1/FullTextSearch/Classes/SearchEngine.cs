using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class SearchEngine : ISearchEngine
{
    public Dictionary<string, List<string>> invertedIndex;

    public SearchEngine(Dictionary<string, List<string>> invertedIndex)
    {
        this.invertedIndex = invertedIndex;
    }

    public List<string> InvertedIndexSearch(List<string> optionalKey, List<string> requireKey, List<string> noKey)
    {
        List<string> optionalResult = this.OptionalKeySearch(optionalKey);
        List<string> noResult = this.OptionalKeySearch(noKey);
        List<string> result = this.RequireKeySearch(requireKey);

        if (optionalKey.Count > 0)
            result = result.Intersect(optionalResult).ToList();

        foreach (string filePath in noKey)
        {
            result.Remove(filePath);
        }

        return result;
    }

    public List<string> OptionalKeySearch(List<string> optionalKey)
    {
        List<string> optionalResult = new List<string>();
        foreach (string key in optionalKey)
        {
            if (this.invertedIndex.ContainsKey(key))
            {
                foreach (string filePath in this.invertedIndex[key])
                {
                    optionalResult.Add(filePath);
                }
            }
        }

        return optionalResult;
    }

    public List<string> RequireKeySearch(List<string> requireKey)
    {
        List<string> requireResult = new List<string>();
        foreach (string key in requireKey)
        {
            if (this.invertedIndex.ContainsKey(key))
            {
                foreach (string filePath in this.invertedIndex[key])
                {
                    requireResult.Add(filePath);
                }
            }
        }

        return requireResult;
    }

    public List<string> NoKeySearch(List<string> noKey)
    {
        List<string> noResult = new List<string>();
        foreach (string key in noKey)
        {
            if (this.invertedIndex.ContainsKey(key))
            {
                foreach (string filePath in this.invertedIndex[key])
                {
                    if (noResult.Contains(filePath))
                    {
                        noResult.Remove(filePath);
                    }
                }
            }
        }

        return noResult;
    }
}