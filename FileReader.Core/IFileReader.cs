namespace FileReader.Core;

/// <summary>
/// Core abstraction for all file readers.
/// Every file type must implement this contract.
/// </summary>
public interface IFileReader
{
    /// <summary>
    /// Reads a file from the given path and returns its content as string.
    /// </summary>
    /// <param name="path">The path to the file to be read.</param>
    /// <returns>The content of the file as a string.</returns>
    string Read(string path);
}