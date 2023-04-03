using DSoft.Common.Shared.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace DSoft.Common.Shared;

/// <summary>
/// https://stackoverflow.com/questions/38795103/encrypt-string-in-net-core
/// </summary>
public class AesCipherService : ICipherService
{
    private const string DefaultCipherKey = "cipherkey#skylar";

    public string Decrypt(string cipherText, string keyString)
    {
        var fullCipher = Convert.FromBase64String(cipherText);

        var iv = new byte[16];
        var cipher = new byte[fullCipher.Length - iv.Length];

        Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
        Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length); ;
        var key = Encoding.UTF8.GetBytes(keyString);

        using var aesAlg = Aes.Create();
        using var decryption = aesAlg.CreateDecryptor(key, iv);
        string result;
        using (var msDecrypt = new MemoryStream(cipher))
        {
            using var csDecrypt = new CryptoStream(msDecrypt, decryption, CryptoStreamMode.Read);
            using var srDecrypt = new StreamReader(csDecrypt);
            result = srDecrypt.ReadToEnd();
        }

        return result;
    }

    public string GenerateCipherKey(string key)
    {
        var tmpKey = $"{key}@{DefaultCipherKey}";
        return tmpKey.Substring(0, 16);
    }

    public string Encrypt(string text, string keyString)
    {
        var key = Encoding.UTF8.GetBytes(keyString);

        using var aesAlg = Aes.Create();
        using var encryption = aesAlg.CreateEncryptor(key, aesAlg.IV);
        using var msEncrypt = new MemoryStream();
        using (var csEncrypt = new CryptoStream(msEncrypt, encryption, CryptoStreamMode.Write))
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            swEncrypt.Write(text);
        }

        var iv = aesAlg.IV;

        var decryptedContent = msEncrypt.ToArray();

        var result = new byte[iv.Length + decryptedContent.Length];

        Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
        Buffer.BlockCopy(decryptedContent, 0, result, iv.Length, decryptedContent.Length);

        return Convert.ToBase64String(result);
    }
}