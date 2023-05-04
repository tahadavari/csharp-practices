using FullTextSearch.Abstraction;
using FullTextSearch.Classes;
using NSubstitute;

namespace FullTextSearchTest.Classes;

public class ProgramTest
{
    private readonly IFileReader _fileReader = Substitute.For<IFileReader>();
    private readonly IInvertedIndex _invertedIndex = Substitute.For<IInvertedIndex>();
    private readonly IPrinter _printer = Substitute.For<IPrinter>();
    private readonly IQueryParser _queryParser = Substitute.For<IQueryParser>();
    private readonly ISearchEngine _searchEngine = Substitute.For<ISearchEngine>();
    
    [Fact]
    public void TestSearch()
    {
        //Arrange
        var directoryPath = "E:\\mohaymen\\practice C#\\P1\\FullTextSearch\\Texts";
        string queryString = "sample query +string -search";
        
        var fakeParsedQuery = new Dictionary<string, List<string>>()
        {
            { QueryParser.optionalKey, new List<string>() },
            { QueryParser.requireKey, new List<string>() },
            { QueryParser.noKey, new List<string>() }
        };
        
        var fakeFileDictionary = new Dictionary<string, string>();
        var fakeResult = new List<string>() {};
        
        _queryParser.ParseQueryToListOfKey(queryString).Returns(fakeParsedQuery);
        _fileReader.MultiFileToDict(directoryPath).Returns(fakeFileDictionary);
        
        var fakeInvertedIndex = new Dictionary<string, List<string>>();
        _invertedIndex.InvertedFileDictIndex(fakeFileDictionary).Returns(fakeInvertedIndex);
        
        _searchEngine.InvertedIndexSearch(
            fakeInvertedIndex,
            fakeParsedQuery[QueryParser.optionalKey],
            fakeParsedQuery[QueryParser.requireKey],
            fakeParsedQuery[QueryParser.noKey]).Returns(fakeResult);
        
        
        // Act
        Search search = new Search(_invertedIndex,_fileReader,_queryParser,_searchEngine);
        List<string> capturedResult = search.SearchMain(directoryPath,queryString);
    
        // Assert
        Assert.Equal(fakeResult, capturedResult);
    }

}