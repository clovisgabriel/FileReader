using FileReader.Core;

/// <summary>
/// Provides example executions for all versions (v1–v9) of the file reader system.
/// </summary>
public static class ExamplesRunner
{
    /// <summary>
    /// Executes all example scenarios sequentially.
    /// </summary>
    public static void RunAll()
    {
        Console.WriteLine("###### File Reader - Examples Runner ######\n\n");

        // Get base folder of running application
        var basePath = AppContext.BaseDirectory;

        // Sample files
        string textFile = Path.Combine(basePath, "Files", "textFile.txt");
        string xmlFile = Path.Combine(basePath, "Files", "xmlFile.xml");
        string encryptedFile = Path.Combine(basePath, "Files", "encryptedFile.txt");
        string jsonFile = Path.Combine(basePath, "Files", "jsonFile.json");

        Console.WriteLine("1. TEXT FILE READING (v1)");
        RunTextFile(textFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("2. XML FILE READING (v2)");
        RunXml(xmlFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("3. ENCRYPTED TEXT FILE READING (v3)");
        RunEncryptedText(encryptedFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("4. XML FILE READING + SECURITY (AUTHORIZED, USER ROLE = ADMIN) (v4)");
        RunXmlWithSecurity(xmlFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("5. XML FILE READING + ENCRYPTION + SECURITY (AUTHORIZED, USER ROLE = ADMIN) (v5)");
        RunXmlEncryptedWithSecurity(xmlFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("6. TEXT FILE READING + SECURITY (v6)");
        RunTextFileWithSecurity(textFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("7. JSON FILE READING (v7)");
        RunJsonFile(jsonFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("8. ENCRYPTED JSON FILE READING (v8)");

        RunEncryptedJson(jsonFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("9. JSON FILE READING + SECURITY (AUTHORIZED, USER ROLE = ADMIN) (v9)");
        RunSecuredJson(jsonFile);

        Console.WriteLine("\n----------------------------------------------\n");
    }

    /// <summary>
    /// V1 - Reads a plain text file.
    /// </summary>
    static void RunTextFile(string path)
    {
        IFileReader reader = new TextFileReader();
        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    /// <summary>
    /// V2 - Reads an XML file.
    /// </summary>
    static void RunXml(string path)
    {
        IFileReader reader = new XmlFileReader();
        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    /// <summary>
    /// V3 - Reads an encrypted text file
    /// </summary>
    static void RunEncryptedText(string path)
    {
        IFileReader reader =
            new EncryptedFileReader(
                new TextFileReader(),
                new ReverseEncryptionStrategy());

        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    /// <summary>
    /// V4 - Reads an XML file with role-based security applied.
    /// </summary>
    static void RunXmlWithSecurity(string path)
    {
        IFileReader reader =
            new SecureFileReader(
                new XmlFileReader(),
                UserRole.Admin); // Change UserRole to see unauthorized access exception. 

        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    /// <summary>
    /// V5 - Reads an XML file with both encryption and security applied.
    /// </summary>
    static void RunXmlEncryptedWithSecurity(string path)
    {
        IFileReader reader =
            new SecureFileReader(
                new EncryptedFileReader(
                    new XmlFileReader(),
                    new ReverseEncryptionStrategy()),
                UserRole.Admin);

        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    /// <summary>
    /// V6 - Reads a text file with role-based security.
    /// </summary>
    static void RunTextFileWithSecurity(string path)
    {
        IFileReader reader =
        new SecureFileReader(
            new TextFileReader(),
            UserRole.Admin); // Change UserRole to see unauthorized access exception. 

        Console.WriteLine(reader.Read(path));
    }

    /// <summary>
    /// V7 - Reads a JSON file.
    /// </summary>
    static void RunJsonFile(string path)
    {
        IFileReader reader = new JsonFileReader();
        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    /// <summary>
    /// V8 - Reads an encrypted JSON file.
    /// </summary>
    static void RunEncryptedJson(string path)
    {
        IFileReader reader =
            new EncryptedFileReader(
                new JsonFileReader(),
                new ReverseEncryptionStrategy());

        Console.WriteLine(reader.Read(path));
    }

    /// <summary>
    /// V9 - Reads a JSON file with role-based security.
    /// </summary>
    static void RunSecuredJson(string path)
    {
        IFileReader reader =
            new SecureFileReader(
                new JsonFileReader(),
                UserRole.Admin); // Change UserRole to see unauthorized access exception. 

        Console.WriteLine(reader.Read(path));
    }
}