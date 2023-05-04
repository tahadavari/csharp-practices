using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class SearchEngine : ISearchEngine
{
    public List<string> InvertedIndexSearch(Dictionary<string, List<string>> invertedIndex, List<string> optionalKey,
        List<string> requireKey, List<string> noKey)
    {
        List<string> optionalResult = this.OptionalKeySearch(invertedIndex,optionalKey);
        List<string> noResult = this.OptionalKeySearch(invertedIndex,noKey);
        List<string> result = this.RequireKeySearch(invertedIndex,requireKey);

        if (optionalKey.Count > 0)
            result = result.Intersect(optionalResult).ToList();

        foreach (string filePath in noResult)
        {
            result.Remove(filePath);
        }

        return result;
    }

    public List<string> OptionalKeySearch(Dictionary<string, List<string>> invertedIndex,List<string> optionalKey)
    {
        List<string> optionalResult = new List<string>();
        foreach (string key in optionalKey)
        {
            if (invertedIndex.TryGetValue(key, out var value))
            {
                foreach (string filePath in value)
                {
                    optionalResult.Add(filePath);
                }
            }
        }

        return optionalResult;
    }

    public List<string> RequireKeySearch(Dictionary<string, List<string>> invertedIndex,List<string> requireKey)
    {
        Dictionary<string, List<string>> filePaths = new Dictionary<string, List<string>>();
        foreach (string key in requireKey)
        {
            if (invertedIndex.TryGetValue(key, out var value))
            {
                foreach (string filePath in value)
                {
                    if (filePaths.ContainsKey(filePath))
                    {
                        filePaths[filePath].Add(key);
                    }
                    else
                    {
                        filePaths[filePath] = new List<string> { key };
                    }
                }
            }
        }

        List<string> requireResult = new List<string>();
        foreach (var kvp in filePaths)
        {
            if (kvp.Value.Count == requireKey.Count)
            {
                requireResult.Add(kvp.Key);
            }
        }

        return requireResult;
    }


    public List<string> NoKeySearch(Dictionary<string, List<string>> invertedIndex,List<string> noKey)
    {
        List<string> noResult = new List<string>();
        foreach (string key in noKey)
        {
            if (invertedIndex.TryGetValue(key, out var value))
            {
                foreach (string filePath in value)
                {
                    noResult.Add(filePath);
                }
            }
        }

        return noResult;
    }
}