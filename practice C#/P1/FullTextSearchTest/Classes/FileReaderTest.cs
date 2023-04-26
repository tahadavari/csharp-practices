using System.Text;
using FullTextSearch.Classes;

namespace FullTextSearchTest.Classes;

public class FileReaderTest
{
    [Fact]
    public void TestReadFileToString()
    {
        // Arrange
        string file = "example.txt";
        string text = "Hello, world!";

        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.Write(text);
        }

        FileReader fileReader = new FileReader(Encoding.UTF8, filePath: file, multi: false);

        // Act
        string fileContent = fileReader.FileToString();

        // Assert
        Assert.Equal(text, fileContent);
    }

    [Fact]
    public void TestRaiseExceptionReadFileToStringButMultiIsTrue()
    {
        // Arrange
        FileReader fileReader = new FileReader(Encoding.UTF8, multi: true);

        // Act
        var exception = Assert.Throws<Exception>(() => fileReader.FileToString());

        // Assert
        Assert.Equal("Multi is true", exception.Message);
    }


    [Fact]
    public void TestReadMultiFileToString()
    {
        // Arrange
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearchTest\Assest\";
        string fileBaseName = directoryPath+"example";
        string textBase = "Hello, world!";
        int fileCount = 5;

        for (int i = 0; i < fileCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(fileBaseName+i.ToString()+".txt"))
            {
                writer.Write(textBase+i.ToString());
            }
        }

        

        FileReader fileReader = new FileReader(Encoding.UTF8, directoryPath: directoryPath, multi: true);

        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();

        DirectoryInfo directory = new DirectoryInfo(directoryPath);
        FileInfo[] files = directory.GetFiles();

        foreach (FileInfo file in files)
        {
            string fileName = file.Name;
            string fileContent = File.ReadAllText(file.FullName); //خواندن محتوای فایل
            filesDictionary.Add(fileName, fileContent); //افزودن نام و محتوای فایل به دیکشنری
        }
        

        // Act
        Dictionary<string, string> result = fileReader.MultiFileToDict();

        // Assert
        Assert.Equal(result, filesDictionary);
        
        
        
        for (int i = 0; i < fileCount; i++)
        {
            if(File.Exists(fileBaseName+i.ToString()+".txt"))
            {
                File.Delete(fileBaseName+i.ToString()+".txt");
            }
        }
    }

    [Fact]
    public void TestRaiseExceptionReadMultiFileToDictButMultiIsFalse()
    {
        // Arrange
        FileReader fileReader = new FileReader(Encoding.UTF8);

        // Act
        var exception = Assert.Throws<Exception>(() => fileReader.MultiFileToDict());

        // Assert
        Assert.Equal("Multi is false", exception.Message);
    }
}