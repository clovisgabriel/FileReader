using System.IO;

namespace FileReader.Core;

/// <summary>
/// Provides functionality to read text files.
/// </summary>
public class TextFileReader : IFileReader
{
    /// <summary>
    /// Reads a text file.
    /// </summary>
    /// <param name="path">The path of the text file.</param>
    /// <returns>The content of the file as a string.</returns>
    public string Read(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be null or empty.");

        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");

        return File.ReadAllText(path);
    }
}