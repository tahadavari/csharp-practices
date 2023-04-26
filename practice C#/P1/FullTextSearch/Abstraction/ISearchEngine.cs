namespace FullTextSearch.Abstraction;

public interface ISearchEngine
{
    public List<string> InvertedIndexSearch(List<string> optionalKey, List<string> requireKey, List<string> noKey);

    public List<string> OptionalKeySearch(List<string> optionalKey);

    public List<string> RequireKeySearch(List<string> requireKey);

    public List<string> NoKeySearch(List<string> noKey);
}