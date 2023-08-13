using System.Security.Cryptography;
using System.Text;

namespace PasswordPepper;

public class PasswordUtil
{
    
//パスワードハッシュ計算
public static byte[] getPasswordHashWithSalt(string pass, string 変化する値)
{
    using (var hmac = new HMACSHA256())
    {
        string 何か変化する値 = "20230203";//ユーザー作成日などがいいかも
        //データベースに保存されるパスワードソルト
        var passwordSaltOnDatabase = hmac.ComputeHash(
            Encoding.Unicode.GetBytes(変化する値));
        
        //実効パスワードソルと
        var actualPasswordSalt =
            Encoding.Unicode.GetString(passwordSaltOnDatabase) +
                                      PasswordPepper.PasswordSalt.Salt;
        //実効パスワードソルトとパスワードからパスワードハッシュを生成
        var passwordHash = hmac.ComputeHash(Encoding.Unicode.GetBytes(actualPasswordSalt + pass));
        return passwordHash;
    }
}

public static byte[] getPasswordHashFromSalt(byte[] salt, string pass)
{
    var actualPasswordSalt = Encoding.Unicode.GetString(salt) + PasswordPepper.PasswordSalt.Salt;
    using (var hmac = new HMACSHA256())
    {
        return hmac.ComputeHash(Encoding.Unicode.GetBytes(actualPasswordSalt + pass));
    }
}

public static byte[] getInitialPasswordSalt(string 変化する値)
{
    using (var hmac = new HMACSHA256())
    {
        var passwordSaltOnDatabase = hmac.ComputeHash(Encoding.Unicode.GetBytes(変化する値));
        return passwordSaltOnDatabase;
    }
}
public static byte[] getNormalPasswordHash(string pass)
{
    var hmac = new HMACSHA256();
    var passwordByte = Encoding.Unicode.GetBytes(pass);
    return hmac.ComputeHash(passwordByte);
}

static void putByte(byte[] str)
{
    //文字列補完式
    Console.WriteLine($" \"{Encoding.GetEncoding(Encoding.Unicode.EncodingName).GetString(str)}\"のバイトシーケンスは");
    foreach (var VARIABLE in str)
    {
        Console.WriteLine(VARIABLE);
    }
    /*
     * バイトシーケンス:8桁の二進数の連続
     * 文字セット：使用する文字それぞれに数字を割り振っている
     */
}

static void putByteWithString(byte[] str)
{
    //文字列補完式
    Console.WriteLine($" \"{Encoding.Unicode.GetString(str)}\"のバイトシーケンスは");
    for (int i = 0; i < str.Length; i += 2)//Unicodeは2バイト使うっぽい
    {
        Console.WriteLine($"{Encoding.Unicode.GetString(new byte[]{str[i], str[i+1]})}：{str[i] + str[i+1]}");
    }
}

static void putHash(byte[] str)
{
    
//16進数の文字列に変換
    Console.WriteLine(BitConverter.ToString(str).Replace("-", ""));
}
}