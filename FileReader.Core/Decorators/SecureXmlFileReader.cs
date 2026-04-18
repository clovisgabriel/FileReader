namespace FileReader.Core;

/// <summary>
/// Decorator that adds role-based security to XML file reading.
/// </summary>
public class SecureXmlFileReader : IFileReader
{
    private readonly IFileReader _xmlReader;
    private readonly UserRole _userRole;

    /// <summary>
    /// Initializes secure XML reader.
    /// </summary>
    /// <param name="xmlReader">The XML reader.</param>
    /// <param name="userRole">The role of the current user.</param>
    public SecureXmlFileReader(IFileReader xmlReader, UserRole userRole)
    {
        _xmlReader = xmlReader;
        _userRole = userRole;
    }

    /// <summary>
    /// Reads XML file content with role-based restrictions.
    /// </summary>
    /// <param name="path">The path to the XML file.</param>
    /// <returns>The XML content if access is allowed.</returns>
    public string Read(string path)
    {
        if (_userRole != UserRole.Admin)
        {
            throw new UnauthorizedAccessException("Only admin can read XML files.");
        }

        return _xmlReader.Read(path);
    }
}