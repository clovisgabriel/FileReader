namespace FileReader.Core;

/// <summary>
/// Defines a contract for encryption/decryption strategies.
/// </summary>
public interface IEncryptionStrategy
{
    /// <summary>
    /// Decrypts an encrypted string into readable text.
    /// </summary>
    /// <param name="text">The encrypted text.</param>
    /// <returns>The decrypted string.</returns>
    string Decrypt(string text);
} 