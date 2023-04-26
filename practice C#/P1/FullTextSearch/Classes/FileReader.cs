using System.Text;
using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class FileReader : IFileReader
{
    private readonly string _filePath;
    private readonly  bool _multi;
    private readonly Encoding _encoding;
    private readonly string _directoryPath;
    private readonly string _fileType;

    public FileReader(Encoding? encoding = null, string filePath = null, string directoryPath = null, bool multi = false,
        string fileType = "txt")
    {
        this._filePath = filePath;
        this._multi = multi;
        this._encoding = encoding ?? Encoding.UTF8;
        this._directoryPath = directoryPath;
        this._fileType = fileType;
    }

    public string FileToString()
    {
        if (_multi)
        {
            throw new Exception("Multi is true");
        }

        string fileString = File.ReadAllText(this._filePath, this._encoding);
        return fileString;
    }

    public Dictionary<string, string> MultiFileToDict()
    {
        if (!_multi)
        {
            throw new Exception("Multi is false");
        }
        
        
        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();

        DirectoryInfo directory = new DirectoryInfo(this._directoryPath);
        FileInfo[] files = directory.GetFiles("*."+_fileType);

        foreach (FileInfo file in files)
        {
            string fileName = file.Name;
            string fileContent = File.ReadAllText(file.FullName); 
            filesDictionary.Add(fileName, fileContent); 
        }

        return filesDictionary;

    }
}