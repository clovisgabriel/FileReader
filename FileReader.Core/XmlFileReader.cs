using System.IO;
using System.Xml.Linq;

namespace FileReader.Core;

public class XmlFileReader : IFileReader
{
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