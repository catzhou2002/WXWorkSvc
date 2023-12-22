using System.Security.Cryptography;
using System.Text;

namespace WXWork3rd.Models;

internal static class Cryptography
{
    private const string Token = "6BEpuhh6kpkdMCKKB4zjBd";
    private const string EncodingAESKey = "FNMjoE4hM49mlhPA9eQ3zq0fPtyOeGYm2AilJwpmdFB";
    private static readonly byte[] _Key, _IV;
    static Cryptography()
    {
        _Key = Convert.FromBase64String(EncodingAESKey + "=");
        _IV = _Key.Take(16).ToArray();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="msgSignature"></param>
    /// <param name="timeStamp"></param>
    /// <param name="nonce"></param>
    /// <param name="encryptMsg"></param>
    /// <param name="decryptMsg"></param>
    /// <param name="receiveId">企业应用的回调，表示corpid
    /// 第三方事件的回调，表示suiteid
    /// 个人主体的第三方应用的回调，ReceiveId是一个空字符串</param>
    /// <returns></returns>
    internal static bool VerifyURL(string msgSignature, string timeStamp, string nonce, string encryptMsg, out string decryptMsg, out string receiveId)
    {


        var inputBytes = Encoding.UTF8.GetBytes(string.Join("", new List<string>
        {
            Token,timeStamp,nonce,encryptMsg
        }.OrderBy(ii => ii)));

        using var sha = SHA1.Create();
        var bytes = sha.ComputeHash(inputBytes);
        StringBuilder stringBuilder = new StringBuilder();
        foreach (var b in bytes)
            stringBuilder.Append(b.ToString("x2"));
        var sign = stringBuilder.ToString();
        if (msgSignature != sign)
        {
            decryptMsg = receiveId = "";
            return false;
        }
        return Decrypt(encryptMsg, out decryptMsg, out receiveId);
    }
    private static bool Decrypt(string input, out string decryptMsg, out string receiveId)
    {
        var toEncryptArray = Convert.FromBase64String(input);

        using var rm = Aes.Create();
        rm.Key = _Key;
        rm.IV = _IV;
        rm.Mode = CipherMode.CBC;
        rm.Padding = PaddingMode.PKCS7;
        try
        {

            ICryptoTransform decryptor = rm.CreateDecryptor(rm.Key, rm.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(toEncryptArray))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    List<byte> buffers = new List<byte>();
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        var count = csDecrypt.Read(buffer, 0, buffer.Length);
                        if (count > 0)
                            buffers.AddRange(buffer.Take(count));
                        if (count < 1024)
                            break;
                    }
                    var bytes = buffers.ToArray();
                    var lenBytes = new Span<byte>(bytes, 16, 4);
                    lenBytes.Reverse();
                    var len = BitConverter.ToInt32(lenBytes);
                    decryptMsg = Encoding.UTF8.GetString(bytes.Skip(20).Take(len).ToArray());
                    receiveId = Encoding.UTF8.GetString(bytes.Skip(20 + len).ToArray());
                    return true;
                }
            }
        }
        catch (Exception)
        {
            decryptMsg = receiveId = "";
            return false;
        }
    }

    internal static string GetJSSign(string jsapi_ticket, string noncestr, string timestamp, string url)
    {
        var str = $"jsapi_ticket={jsapi_ticket}&noncestr={noncestr}&timestamp={timestamp}&url={url}";
        using var sha = SHA1.Create();
        var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(str));
        var sb = new StringBuilder();
        foreach (var b in bytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }

}
