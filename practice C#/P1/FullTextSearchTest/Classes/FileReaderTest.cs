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

        FileReader fileReader = new FileReader();

        // Act
        string fileContent = fileReader.FileToString(filePath: file, Encoding.UTF8);

        // Assert
        Assert.Equal(text, fileContent);
    }


    [Fact]
    public void TestReadMultiFileToString()
    {
        // Arrange
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearchTest\Assest\";
        string fileBaseName = directoryPath + "example";
        string textBase = "Hello, world!";
        int fileCount = 5;

        for (int i = 0; i < fileCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(fileBaseName + i.ToString() + ".txt"))
            {
                writer.Write(textBase + i.ToString());
            }
        }


        FileReader fileReader = new FileReader();

        Dictionary<string, string> filesDictionary = new Dictionary<string, string>();

        DirectoryInfo directory = new DirectoryInfo(directoryPath);
        FileInfo[] files = directory.GetFiles();

        foreach (FileInfo file in files)
        {
            string fileName = file.Name;
            string fileContent = File.ReadAllText(file.FullName);
            filesDictionary.Add(fileName, fileContent);
        }


        // Act
        Dictionary<string, string> result = fileReader.MultiFileToDict(directoryPath);

        // Assert
        Assert.Equal(result, filesDictionary);


        for (int i = 0; i < fileCount; i++)
        {
            if (File.Exists(fileBaseName + i.ToString() + ".txt"))
            {
                File.Delete(fileBaseName + i.ToString() + ".txt");
            }
        }
    }
}