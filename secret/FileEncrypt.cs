using System.Text;

namespace secret;

static class FileEncrypt
{
    private static int GenerateKey(string password)
    {
        int key = 0;

        for (int i = 0; i < password.Length; i++)
        {
            int ascii = (int)password[i];
            int num = (char)password[i % password.Length];

            // 17 რენდომზე აღებული კენტი რიცხვია
            int part = ((ascii * num) + (ascii * (i + 1))) % 17;

            key += part;
        }

        return Math.Abs(key);
    }

    public static string Encrypt(string text, string password)
    {
        IsPasswordNull(password);
        int key = GenerateKey(password);
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            // shift გვჭირდება, რადგან ერთი სიმბოლო პირველ პოზიციაზე სხვანაირად
            // იშიფრება ვიდრე მესამე პოზიციაზე.
            // 17 უბრალოდ რენდომ კენტი რიცხვია
            int shift = (key + i * 17);
            char original = text[i];

            char c = (char)(original + shift);
            sb.Append(c);
        }

        return sb.ToString();
    }

    private static void IsPasswordNull(string password)
    {
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password), "Password cannot be null.");
        }
    }

    public static string Decrypt(string text, string password)
    {
        IsPasswordNull(password);
        int key = GenerateKey(password);
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < text.Length; i++)
        {
            int shift = (key + i * 17);
            char encryptedChar = text[i];

            char c = (char)(encryptedChar - shift);
            sb.Append(c);
        }

        return sb.ToString();
    }
}