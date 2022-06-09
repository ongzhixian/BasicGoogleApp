using System.Security.Cryptography;
using System.Text;

namespace BasicGoogleApp.ConsoleApp.Helpers;

internal class RandomHelper
{
    static readonly RandomNumberGenerator rng = RandomNumberGenerator.Create();

    internal static string GenerateRandomDataBase64url(uint length)
    {
        byte[] bytes = new byte[length];

        rng.GetBytes(bytes);
        
        return Base64UrlEncodeNoPadding(bytes);
    }

    internal static string Base64UrlEncodeNoPadding(byte[] buffer)
    {
        string base64 = Convert.ToBase64String(buffer);

        // Converts base64 to base64url.
        base64 = base64.Replace("+", "-");
        base64 = base64.Replace("/", "_");

        // Strips padding.
        base64 = base64.Replace("=", "");

        return base64;
    }

    internal static byte[] Sha256Ascii(string text)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(text);

        using SHA256 sha256 = SHA256.Create();

        return sha256.ComputeHash(bytes);
    }
}
