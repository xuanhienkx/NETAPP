namespace BO.Core.DataCommon.Shared.Interfaces
{
    public interface ICipherService
    {
        string Encrypt(string text, string keyString);
        string Decrypt(string cipherText, string keyString);
        string GenerateCipherKey(string key);
    }
}