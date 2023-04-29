using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class SearchEngine : ISearchEngine
{
    private readonly Dictionary<string, List<string>> _invertedIndex;

    public SearchEngine(Dictionary<string, List<string>> invertedIndex)
    {
        this._invertedIndex = invertedIndex;
    }

    public List<string> InvertedIndexSearch(List<string> optionalKey, List<string> requireKey, List<string> noKey)
    {
        List<string> optionalResult = this.OptionalKeySearch(optionalKey);
        List<string> noResult = this.OptionalKeySearch(noKey);
        List<string> result = this.RequireKeySearch(requireKey);

        if (optionalKey.Count > 0)
            result = result.Intersect(optionalResult).ToList();

        foreach (string filePath in noResult)
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
            if (this._invertedIndex.TryGetValue(key, out var value))
            {
                foreach (string filePath in value)
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
            if (this._invertedIndex.TryGetValue(key, out var value))
            {
                foreach (string filePath in value)
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
            if (this._invertedIndex.TryGetValue(key, out var value))
            {
                foreach (string filePath in value)
                {
                    if (noResult.Contains(filePath))
                    {
                        noResult.Add(filePath);
                    }
                }
            }
        }

        return noResult;
    }
}