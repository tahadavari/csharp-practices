using System.Text;
using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class FileReader : IFileReader
{
    public string FileToString(string filePath, Encoding? encoding = null)
    {
        if (encoding is null)
        {
            encoding = Encoding.UTF8;
        }

        string fileString = File.ReadAllText(filePath, encoding);
        return fileString;
    }

    public Dictionary<string, string> MultiFileToDict(string directoryPath, string fileType = "txt",
        Encoding? encoding = null)
    {
        if (encoding is null)
        {
            encoding = Encoding.UTF8;
        }

        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();

        DirectoryInfo directory = new DirectoryInfo(directoryPath);
        FileInfo[] files = directory.GetFiles("*." + fileType);

        foreach (FileInfo file in files)
        {
            string fileName = file.Name;
            string fileContent = File.ReadAllText(file.FullName, encoding);
            filesDictionary.Add(fileName, fileContent);
        }

        return filesDictionary;
    }
}