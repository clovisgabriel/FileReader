namespace FileReader.Core;

/// <summary>
/// Simple encryption strategy that reverses a string.
/// Used for demonstration purposes only.
/// </summary>
public class ReverseEncryptionStrategy : IEncryptionStrategy
{
    /// <summary>
    /// Decrypts a string by reversing its characters.
    /// </summary>
    /// <param name="input">The reversed encrypted string.</param>
    /// <returns>The original readable string.</returns>
    public string Decrypt(string input)
    {
        return new string(input.Reverse().ToArray());
    }
}