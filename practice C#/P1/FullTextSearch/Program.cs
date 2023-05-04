using FullTextSearch.Classes;

public class Program
{
    static void Main(string[] args)
    {
        // PrintResult(Search());
    }
    //
    // public static List<string> Search()
    // {
    //     // string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearch\Texts";
    //     //
    //     // string queryString = Console.ReadLine();
    //     // QueryParser queryParser = new QueryParser(queryString);
    //     // Dictionary<string, List<string>> parseQuery = queryParser.ParseQueryToListOfKey();
    //     //
    //     // FileReader fileReader = new FileReader(directoryPath: directoryPath, multi: true);
    //     //
    //     // InvertedIndex invertedIndex = new InvertedIndex();
    //     //
    //     // SearchEngine searchEngine = new SearchEngine(invertedIndex.InvertedFileDictIndex(fileReader.MultiFileToDict()));
    //     // List<string> result =
    //     //     searchEngine.InvertedIndexSearch(parseQuery[QueryParser.optionalKey],
    //     //         parseQuery[QueryParser.requireKey],
    //     //         parseQuery[QueryParser.noKey]);
    //     //
    //     // return result;
    // }

    public static void PrintResult(List<string> searchResult)
    {
        Printer printer = new Printer();
        printer.WriteListOfStringToConsole(searchResult);
    }
}