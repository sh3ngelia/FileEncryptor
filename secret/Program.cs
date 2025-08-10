namespace secret
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "aaaaa";
            string encrypted = FileEncrypt.Encrypt(text, "ad");
            Console.WriteLine($"Encrypted: {encrypted}");
            string decrypted = FileEncrypt.Decrypt(encrypted, "da");
            Console.WriteLine($"Decrypted: {decrypted}");

            // FileStreamOperations.ReadFromFileAndEncriptAndWrite("D:\\test\\test.txt", "D:\\test\\test.txt",text,"ad");
            // FileStreamOperations.ReadFromFileAndDecryptAndWrite("D:\\test\\test.txt", "D:\\test\\test.txt", text, "ad");
        }
    }
}