namespace FullTextSearch.Classes;

public class Printer
{
    public void WriteListOfStringToConsole(List<string> listString)
    {
        Console.WriteLine(String.Join("\n", listString));
    }
}