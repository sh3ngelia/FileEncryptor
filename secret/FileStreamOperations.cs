namespace secret;

static class FileStreamOperations
{
    public static void ReadFromFileAndEncryptAndWrite(string readPath, string writePath, string text, string password)
    {
        string forEncrypt = ReadFromFile(readPath);
        string encrypted = FileEncrypt.Encrypt(forEncrypt, password);
        WriteToFile(writePath, encrypted);
    }
    public static void ReadFromFileAndDecryptAndWrite(string readPath, string writePath, string text, string password)
    {
        string forDecrypt = ReadFromFile(readPath);
        string decrypted = FileEncrypt.Decrypt(forDecrypt, password);
        WriteToFile(writePath, decrypted);
    }

    private static void WriteToFile(string path, string text)
    {
        StreamWriter writer = new StreamWriter(path);
        writer.Write(text);
        writer.Close();
    }
    private static string ReadFromFile(string path)
    {
        StreamReader reader = new StreamReader(path);
        string read = reader.ReadToEnd();
        reader.Close();
        return read;
    }
}