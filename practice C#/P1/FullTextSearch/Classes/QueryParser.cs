using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class QueryParser : IQueryParser
{
 
    
    
    public const string requireKey = "requireKey";
    public const string optionalKey = "optionalKey";
    public const string noKey = "noKey";

    public QueryParser()
    {
    }

    public Dictionary<string, List<string>> ParseQueryToListOfKey(string queryString, string parseSplit = " ")
    {
        string[] searchQuery = queryString.Split(parseSplit);
        List<string> requireKeyList = new List<string>();
        List<string> optionalKeyList = new List<string>();
        List<string> noKeyList = new List<string>();

        foreach (string key in searchQuery)
        {
            if (key.StartsWith('+'))
            {
                optionalKeyList.Add(key.Substring(1));
            }
            else if (key.StartsWith('-'))
            {
                noKeyList.Add(key.Substring(1));
            }
            else
            {
                requireKeyList.Add(key);
            }
        }

        Dictionary<string, List<string>> parseQuery = new Dictionary<string, List<string>>();

        parseQuery.Add(optionalKey, optionalKeyList);
        parseQuery.Add(noKey, noKeyList);
        parseQuery.Add(requireKey, requireKeyList);


        return parseQuery;
    }
}