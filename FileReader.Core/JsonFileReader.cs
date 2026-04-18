using System.IO;
using System.Text.Json;

namespace FileReader.Core;

/// <summary>
/// Reads JSON files and returns content as a string.
/// </summary>
public class JsonFileReader : IFileReader
{
    /// <summary>
    /// Reads a JSON file from the given path.
    /// </summary>
    /// <param name="path">The path of the JSON file.</param>
    /// <returns>The JSON content as a string.</returns>
    public string Read(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be null or empty.");

        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");

        var json = File.ReadAllText(path);

        using var doc = JsonDocument.Parse(json);

        return JsonSerializer.Serialize(doc.RootElement, new JsonSerializerOptions
        {
            WriteIndented = true
        });
    }
}