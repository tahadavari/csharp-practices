using FullTextSearch.Classes;
using Xunit.Abstractions;

namespace FullTextSearchTest.Classes;

public class SearchEngineTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public SearchEngineTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestInvertedIndexSearch()
    {
        
    }

    [Fact]
    public void TestRequireKeySearch()
    {
        // Arrange
        string queryString = "test require +key -search";
        QueryParser queryParser = new QueryParser(queryString);
        Dictionary<string, List<string>> parseQuery = queryParser.ParseQueryToListOfKey();

        string text1 = "test require";
        int resultCount = 2;
        
        string text2 = "test";
        int fileCount = 3;
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearchTest\Assest\";
        string filePath = directoryPath + "file";
        for (int i = 0; i < resultCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(filePath + i.ToString() + ".txt"))
            {
                writer.Write(text1);
            }
        }
        for (int i = 0; i < fileCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(filePath + i.ToString() + "f" + ".txt"))
            {
                writer.Write(text2);
            }
        }

        FileReader fileReader = new FileReader(directoryPath: directoryPath, multi: true);
        InvertedIndex invertedIndex = new InvertedIndex();
        SearchEngine searchEngine = new SearchEngine(invertedIndex.InvertedFileDictIndex(fileReader.MultiFileToDict()));

        // Act
        List<string> requireResult = searchEngine.RequireKeySearch(parseQuery[QueryParser.requireKey]);

        // Assert
        Assert.Equal(requireResult.Count, resultCount);
    }

    [Fact]
    public void TestNoKeySearch()
    {
        // Arrange
        string queryString = "test require +key -search";
        QueryParser queryParser = new QueryParser(queryString);
        Dictionary<string, List<string>> parseQuery = queryParser.ParseQueryToListOfKey();

        string text1 = "test require search";
        int resultCount = 2;
        
        string text2 = "test";
        int fileCount = 3;
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearchTest\Assest\";
        string filePath = directoryPath + "file";
        for (int i = 0; i < resultCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(filePath + i.ToString() + ".txt"))
            {
                writer.Write(text1);
            }
        }
        for (int i = 0; i < fileCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(filePath + i.ToString() + "f" + ".txt"))
            {
                writer.Write(text2);
            }
        }

        FileReader fileReader = new FileReader(directoryPath: directoryPath, multi: true);
        InvertedIndex invertedIndex = new InvertedIndex();
        SearchEngine searchEngine = new SearchEngine(invertedIndex.InvertedFileDictIndex(fileReader.MultiFileToDict()));

        // Act
        
        List<string> noResult = searchEngine.NoKeySearch(parseQuery[QueryParser.noKey]);

        // Assert
        Assert.Equal(noResult.Count, resultCount);
    }

    [Fact]
    public void TestOptionalKeySearch()
    {
        // Arrange
        string queryString = "test require +key -search";
        QueryParser queryParser = new QueryParser(queryString);
        Dictionary<string, List<string>> parseQuery = queryParser.ParseQueryToListOfKey();

        string text1 = "test require key";
        int resultCount = 2;
        
        string text2 = "test";
        int fileCount = 3;
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearchTest\Assest\";
        string filePath = directoryPath + "file";
        for (int i = 0; i < resultCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(filePath + i.ToString() + ".txt"))
            {
                writer.Write(text1);
            }
        }
        for (int i = 0; i < fileCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(filePath + i.ToString() + "f" + ".txt"))
            {
                writer.Write(text2);
            }
        }

        FileReader fileReader = new FileReader(directoryPath: directoryPath, multi: true);
        InvertedIndex invertedIndex = new InvertedIndex();
        SearchEngine searchEngine = new SearchEngine(invertedIndex.InvertedFileDictIndex(fileReader.MultiFileToDict()));

        // Act
        List<string> optionalResult = searchEngine.OptionalKeySearch(parseQuery[QueryParser.optionalKey]);

        // Assert
        Assert.Equal(optionalResult.Count, resultCount);
    }
}