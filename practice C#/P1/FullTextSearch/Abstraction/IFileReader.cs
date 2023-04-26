using System.Text;

namespace FullTextSearch.Abstraction;

public interface IFileReader
{
    string FileToString();

    Dictionary<string, string> MultiFileToDict();
}