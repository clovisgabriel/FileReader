namespace FileReader.Core;

/// <summary>
/// Generic security decorator that adds role-based access control to any file reader.
/// </summary>
public class SecureFileReader : IFileReader
{
    private readonly IFileReader _fileReader;
    private readonly UserRole _userRole;

    /// <summary>
    /// Initializes a new instance of SecureFileReader.
    /// </summary>
    /// <param name="fileReader">The file reader.</param>
    /// <param name="userRole">The role of the current user.</param>
    public SecureFileReader(IFileReader fileReader, UserRole userRole)
    {
        _fileReader = fileReader;
        _userRole = userRole;
    }

    /// <summary>
    /// Reads file content if the user has permission.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <returns>File content.</returns>
    public string Read(string path)
    {
        if (_userRole != UserRole.Admin)
            throw new UnauthorizedAccessException("Access denied: only Admin can read files.");

        return _fileReader.Read(path);
    }
}