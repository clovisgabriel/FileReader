using FileReader.Core;

namespace FileReader.Cli;

/// <summary>
/// Entry point for the File Reader CLI application.
/// </summary>
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n######### File Reader #########");

            Console.WriteLine("Select file type:");
            Console.WriteLine("1 - Text");
            Console.WriteLine("2 - XML");
            Console.WriteLine("3 - JSON");
            Console.WriteLine("0 - Exit\n");

            var type = Console.ReadLine();

            if (type == "0")
                break;

            Console.WriteLine("\nUse encryption? (y/n)");
            bool useEncryption = Console.ReadLine()?.Trim().ToLower() == "y";

            Console.WriteLine("\nUse role-based security? (y/n)");
            bool useSecurity = Console.ReadLine()?.Trim().ToLower() == "y";

            UserRole role = UserRole.User;

            if (useSecurity)
            {
                Console.WriteLine("Enter role (Admin/User):");

                if (!Enum.TryParse<UserRole>(Console.ReadLine(), true, out role))
                {
                    Console.WriteLine("Invalid role. Defaulting to User.");
                    role = UserRole.User;
                }
            }

            Console.WriteLine("\nEnter the full file path (e.g., C:\\folder\\file.txt):\n");
            var path = Console.ReadLine();

            try
            {
                IFileReader reader = BuildReader(type, useEncryption, useSecurity, role);

                var result = reader.Read(path!);

                Console.WriteLine("\n--- OUTPUT ---");
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }
    }

    /// <summary>
    /// Builds the appropriate file reader based on user input,
    /// applying decorators for encryption and role-based security if requested.
    /// </summary>
    static IFileReader BuildReader(string? type, bool useEncryption, bool useSecurity, UserRole role)
    {
        IFileReader reader = type switch
        {
            "1" => new TextFileReader(),
            "2" => new XmlFileReader(),
            "3" => new JsonFileReader(),
            _ => throw new Exception("Invalid file type selection.")
        };

        if (useEncryption)
        {
            reader = new EncryptedFileReader(
                reader,
                new ReverseEncryptionStrategy());
        }

        if (useSecurity)
        {
            reader = new SecureFileReader(reader, role);
        }

        return reader;
    }
}