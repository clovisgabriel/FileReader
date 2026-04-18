using System.IO;
using System.Xml.Linq;

namespace FileReader.Core;

/// <summary>
/// Provides functionality to read XML files.
/// </summary>
public class XmlFileReader : IFileReader
{
    /// <summary>
    /// Reads an XML file and converts it into a string representation.
    /// </summary>
    /// <param name="path">The path of the XML file.</param>
    /// <returns>The XML content as a formatted string.</returns>
    public string Read(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Path cannot be null or empty.");

        if (!File.Exists(path))
            throw new FileNotFoundException($"File not found: {path}");

        var doc = XDocument.Load(path);
        return doc.ToString();
    }
}