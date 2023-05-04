using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class Search
{
    private static IInvertedIndex _invertedIndex;
    private static IQueryParser _queryParser;
    private static IFileReader _fileReader;
    private static ISearchEngine _searchEngine;

    public Search(IInvertedIndex invertedIndex, IFileReader fileReader, IQueryParser queryParser,
        ISearchEngine searchEngine)
    {
        _invertedIndex = invertedIndex;
        _queryParser = queryParser;
        _fileReader = fileReader;
        _searchEngine = searchEngine;
    }

    public List<string> SearchMain(string directoryPath, string queryString)
    {
        // QueryParser queryParser = new QueryParser(queryString);
        Dictionary<string, List<string>> parseQuery = _queryParser.ParseQueryToListOfKey(queryString);

        // ToDo
        // FileReader fileReader = new FileReader(directoryPath: directoryPath, multi: true);


        // InvertedIndex invertedIndex = new InvertedIndex();

        SearchEngine searchEngine =
            new SearchEngine();
        List<string> result =
            searchEngine.InvertedIndexSearch(_invertedIndex.InvertedFileDictIndex(_fileReader.MultiFileToDict(directoryPath)),
                parseQuery[QueryParser.optionalKey],
                parseQuery[QueryParser.requireKey],
                parseQuery[QueryParser.noKey]);

        return result;
    }

    public static void PrintResult(List<string> searchResult)
    {
        Printer printer = new Printer();
        printer.WriteListOfStringToConsole(searchResult);
    }
}