using System.Text;
using FullTextSearch.Classes;

namespace FullTextSearchTest.Classes;

public class InvertedIndexTest
{
    [Fact]
    public void TestInvertedIndexFromDictFile()
    {
        // Arrange
        string directoryPath = @"E:\mohaymen\practice C#\P1\FullTextSearchTest\Assest\";
        string fileBaseName = directoryPath + "example";
        string textBase = "Hello";
        string fileType = "txt";
        string baseName = "test";
        int fileCount = 5;
        
        
        Dictionary<string, string> fileDict = CreateFilesAndToDictionary(directoryPath, fileType,
            baseName, textBase, fileCount);
        
        

        // Act
        InvertedIndex invertedIndex = new InvertedIndex();
        Dictionary<string, List<string>> result = invertedIndex.InvertedFileDictIndex(fileDict);

        // Assert
        Assert.Equal(5, result["Hello"].Count);
    }

    private Dictionary<string, string> CreateFilesAndToDictionary(string directoryPath, string fileType,
        string baseName, string textBase, int fileCount)
    {
        string fileBaseName = directoryPath + baseName;

        for (int i = 0; i < fileCount; i++)
        {
            using (StreamWriter writer = new StreamWriter(fileBaseName + i.ToString() + "." + fileType))
            {
                writer.Write(textBase);
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

        return fileReader.MultiFileToDict(directoryPath);
    }
}