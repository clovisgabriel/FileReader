using System.IO;

namespace FileReader.Core;

public class TextFileReader : IFileReader
{
    public string Read(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be null or empty.");

        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");

        return File.ReadAllText(path);
    }
}