using System.Text;
using FullTextSearch.Abstraction;

namespace FullTextSearch.Classes;

public class FileReader : IFileReader
{
    public string filePath;
    public bool multi;
    public Encoding encoding;
    public string directoryPath;
    public string fileType;

    public FileReader(Encoding encoding, string filePath = null, string directoryPath = null, bool multi = false,
        string fileType = "txt")
    {
        this.filePath = filePath;
        this.multi = multi;
        this.encoding = encoding;
        this.directoryPath = directoryPath;
        this.fileType = fileType;
    }

    public string FileToString()
    {
        if (multi)
        {
            throw new Exception("Multi is true");
        }

        string fileString = File.ReadAllText(this.filePath, this.encoding);
        return fileString;
    }

    public Dictionary<string, string> MultiFileToDict()
    {
        if (!multi)
        {
            throw new Exception("Multi is false");
        }
        
        
        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();

        DirectoryInfo directory = new DirectoryInfo(this.directoryPath);
        FileInfo[] files = directory.GetFiles("*."+fileType);

        foreach (FileInfo file in files)
        {
            string fileName = file.Name;
            string fileContent = File.ReadAllText(file.FullName); //خواندن محتوای فایل
            filesDictionary.Add(fileName, fileContent); //افزودن نام و محتوای فایل به دیکشنری
        }

        return filesDictionary;

    }
}