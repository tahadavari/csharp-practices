namespace FullTextSearch.Abstraction;

public interface ISearchEngine
{
    public List<string> InvertedIndexSearch(Dictionary<string, List<string>> invertedIndex,List<string> optionalKey, List<string> requireKey, List<string> noKey);

    public List<string> OptionalKeySearch(Dictionary<string, List<string>> invertedIndex,List<string> optionalKey);

    public List<string> RequireKeySearch(Dictionary<string, List<string>> invertedIndex,List<string> requireKey);

    public List<string> NoKeySearch(Dictionary<string, List<string>> invertedIndex,List<string> noKey);
}