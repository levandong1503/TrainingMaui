using System.Security.Cryptography;
using System.Text;

namespace TrainingMaui.Utils.Encrypted;

public class EncryptionHelper
{
    // Implement your AES encryption logic here
    // This is just a placeholder for demonstration purposes
    public static string AesEncrypt(string plain_text, string aesKey, string aesIv)
    {

        string encrypted_str;

        try
        {
            // Aesオブジェクトを作成
            using (Aes aes = Aes.Create())
            {
                // Encryptorを作成
                using ICryptoTransform encryptor =
                    aes.CreateEncryptor(Encoding.UTF8.GetBytes(aesKey), Encoding.UTF8.GetBytes(aesIv));
                // 出力ストリームを作成
                using MemoryStream out_stream = new();
                // 暗号化して書き出す
                using (CryptoStream cs = new(out_stream, encryptor, CryptoStreamMode.Write))
                {
                    using StreamWriter sw = new(cs);
                    // 出力ストリームに書き出し
                    sw.Write(plain_text);
                }
                // Base64文字列にする
                byte[] result = out_stream.ToArray();
                encrypted_str = Convert.ToBase64String(result);
            }

            return encrypted_str;
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    // Implement your AES decryption logic here
    // This is just a placeholder for demonstration purposes
    public static string AesDecrypt(string base64_text, string aesKey, string aesIv)
    {

        string plain_text;

        try
        {
            // Base64文字列をバイト型配列に変換
            byte[] cipher = Convert.FromBase64String(base64_text);

            // AESオブジェクトを作成
            using (Aes aes = Aes.Create())
            {
                // 復号器を作成
                using ICryptoTransform decryptor =
                    aes.CreateDecryptor(Encoding.UTF8.GetBytes(aesKey), Encoding.UTF8.GetBytes(aesIv));
                // 復号用ストリームを作成
                using MemoryStream in_stream = new(cipher);
                // 一気に復号
                using CryptoStream cs = new(in_stream, decryptor, CryptoStreamMode.Read);
                using StreamReader sr = new(cs);
                plain_text = sr.ReadToEnd();
            }
            return plain_text;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}
