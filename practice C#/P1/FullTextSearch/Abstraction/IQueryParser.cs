namespace FullTextSearch.Abstraction;

public interface IQueryParser
{
    Dictionary<string, List<string>> ParseQueryToListOfKey(string queryString, string parseSplit = " ");
}