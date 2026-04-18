using FileReader.Core;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("###### File Reader ######\n\n");

        // Get base folder of running application
        var basePath = AppContext.BaseDirectory;

        // Sample files
        string textFile = Path.Combine(basePath, "Files", "textFile.txt");
        string xmlFile = Path.Combine(basePath, "Files", "xmlFile.xml");
        string encryptedFile = Path.Combine(basePath, "Files", "encryptedFile.txt");
        string jsonFile = Path.Combine(basePath, "Files", "jsonFile.json");

        Console.WriteLine("1. TEXT FILE READING (v1)");
        TestTextFile(textFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("2. XML FILE READING (v2)");
        TestXml(xmlFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("3. ENCRYPTED TEXT FILE (v3)");
        TestEncryptedText(encryptedFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("4. XML + SECURITY (AUTHORIZED, USER ROLE = ADMIN) (v4)");
        TestXmlWithSecurity(xmlFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("5. XML + ENCRYPTION + SECURITY (AUTHORIZED, USER ROLE = ADMIN) (v5)");
        TestXmlEncryptedWithSecurity(xmlFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("6. TEXT + SECURITY (v6)");
        TestTextFileWithSecurity(textFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("7. JSON FILE READING (v7)");
        TestJsonFile(jsonFile);

        Console.WriteLine("\n----------------------------------------------\n");

        Console.WriteLine("8. ENCRYPTED JSON FILE READING (v8)");

        TestEncryptedJson(jsonFile);

        Console.WriteLine("\n----------------------------------------------\n");
    }

    // V1 - Test a simple text file reader
    static void TestTextFile(string path)
    {
        IFileReader reader = new TextFileReader();
        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    // V2 - Test an xml file reader
    static void TestXml(string path)
    {
        IFileReader reader = new XmlFileReader();
        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    // v3 - Text an encrypted text file reader
    static void TestEncryptedText(string path)
    {
        IFileReader reader =
            new EncryptedFileReader(
                new TextFileReader(),
                new ReverseEncryptionStrategy());

        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    // V4 - Test an xml file with security
    static void TestXmlWithSecurity(string path)
    {
        IFileReader reader =
            new SecureFileReader(
                new XmlFileReader(),
                UserRole.Admin); // Change UserRole to see unauthorized access exception. 

        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    // V5 - Test an xml encrypted file with security
    static void TestXmlEncryptedWithSecurity(string path)
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

    // V6 - Test a text file with security
    static void TestTextFileWithSecurity(string path)
    {
        IFileReader reader =
        new SecureFileReader(
            new TextFileReader(),
            UserRole.Admin); // Change UserRole to see unauthorized access exception. 

        Console.WriteLine(reader.Read(path));
    }

    // V7 - Test a json file reader
    static void TestJsonFile(string path)
    {
        IFileReader reader = new TextFileReader();
        var result = reader.Read(path);

        Console.WriteLine(result);
    }

    // V8 - Test an encrypted json file
    static void TestEncryptedJson(string path)
    {
        IFileReader reader =
            new EncryptedFileReader(
                new JsonFileReader(),
                new ReverseEncryptionStrategy());

        Console.WriteLine(reader.Read(path));
    }
}