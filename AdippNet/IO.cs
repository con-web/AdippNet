namespace AdippNet;

public static class IO
{
    
    public static Stream GetStdinStream()
    {
        return Console.OpenStandardInput();
    }

    public static Stream GetStdoutStream()
    {
        return Console.OpenStandardOutput();
    }

    public static Stream GetReadFileStream(string path)
    {
        return File.OpenRead(path);
    }

    public static Stream GetWriteFileStream(string path)
    {
        return File.OpenWrite(path);
    }
}