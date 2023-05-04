using FullTextSearch.Classes;

namespace FullTextSearchTest.Classes;

public class QueryParserTest
{
    [Fact]
    public void TestParseQueryToListOfKey()
    {
        // Arrange
        string queryString = "Hello World +to +if +you -Programming";
        QueryParser queryParser = new QueryParser();

        // Act
        Dictionary<string, List<string>> result = queryParser.ParseQueryToListOfKey(queryString);
        
        

        // Assert
        Assert.Equal(2, result[QueryParser.requireKey].Count);
        Assert.Equal(3, result[QueryParser.optionalKey].Count);
        Assert.Equal(1, result[QueryParser.noKey].Count);
    }
}