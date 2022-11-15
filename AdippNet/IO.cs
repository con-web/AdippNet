using System.Text;

namespace AdippNet;

public static class IO
{
    public static string? ReadFromConsole()
    {
        Console.InputEncoding = Encoding.UTF8;
        return Console.ReadLine();
    }

    public static void WriteToConsole(string text)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine(text);
    }

    public static string ReadFromFile(string path)
    {
        return File.ReadAllText(path, Encoding.UTF8);
    }

    public static void WriteToFile(string path, string text)
    {
        File.WriteAllText(path, text, Encoding.UTF8);
    }
}