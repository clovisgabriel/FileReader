namespace FileReader.Core;

/// <summary>
/// Decorator that adds encryption support to any file reader.
/// </summary>
public class EncryptedFileReader : IFileReader
{
    private readonly IFileReader _fileReader;
    private readonly IEncryptionStrategy _encryptionStrategy;

    /// <summary>
    /// Initializes a new instance of EncryptedFileReader.
    /// </summary>
    /// <param name="fileReader">The file reader.</param>
    /// <param name="encryptionStrategy">The encryption strategy used for decryption.</param>
    public EncryptedFileReader(IFileReader fileReader, IEncryptionStrategy encryptionStrategy)
    {
        _fileReader = fileReader;
        _encryptionStrategy = encryptionStrategy;
    }

    /// <summary>
    /// Reads an encrypted file and decrypts its content.
    /// </summary>
    /// <param name="path">The path of the encrypted file.</param>
    /// <returns>The decrypted file content.</returns>
    public string Read(string path)
    {
        var content = _fileReader.Read(path);
        return _encryptionStrategy.Decrypt(content);
    }
}