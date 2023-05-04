using System.Text;

namespace FullTextSearch.Abstraction;

public interface IFileReader
{
    string FileToString(string filePath, Encoding? encoding = null);

    Dictionary<string, string> MultiFileToDict(string directoryPath, string fileType = "txt",
        Encoding? encoding = null);
}