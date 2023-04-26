namespace FullTextSearch.Abstraction;

public interface IInvertedIndex
{
    Dictionary<string, List<string>> InvertedFileDictIndex(Dictionary<string, string> filesDictionary);
}