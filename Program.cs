// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;

string str = "パスワード";
string salt = "塩あまり使わないので減らない";

Console.WriteLine("Hello, World!");

while (true)
{
    Console.WriteLine("操作番号を入力してください");
    int input;
    while (true)
    {
        input = Int16.Parse(Console.ReadLine());
        switch (input)
        {
            case 0:
                
                break;
        }
    }
    
}
//パスワードハッシュ計算
byte[] getPasswordHashWithSalt(string pass, string salt)
{
    using (var hmac = new HMACSHA256())
    {
        string 何か変化する値 = "20230203";//ユーザー作成日などがいいかも
        //データベースに保存されるパスワードソルト
        var passwordSaltOnDatabase = hmac.ComputeHash(
            Encoding.Unicode.GetBytes(何か変化する値 + salt));
        
        //実効パスワードソルと
        var actualPasswordSalt =
            Encoding.Unicode.GetString(passwordSaltOnDatabase) +
                                      PasswordPepper.PasswordSalt.Salt;
        //実効パスワードソルトとパスワードからパスワードハッシュを生成
        var passwordHash = hmac.ComputeHash(Encoding.Unicode.GetBytes(actualPasswordSalt + pass));
        return passwordHash;
    }
}
byte[] getNormalPasswordHash(string pass)
{
    var hmac = new HMACSHA256();
    var passwordByte = Encoding.Unicode.GetBytes(pass);
    return hmac.ComputeHash(passwordByte);
}

void putByte(byte[] str)
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

void putByteWithString(byte[] str)
{
    //文字列補完式
    Console.WriteLine($" \"{Encoding.Unicode.GetString(str)}\"のバイトシーケンスは");
    for (int i = 0; i < str.Length; i += 2)//Unicodeは2バイト使うっぽい
    {
        Console.WriteLine($"{Encoding.Unicode.GetString(new byte[]{str[i], str[i+1]})}：{str[i] + str[i+1]}");
    }
}

void putHash(byte[] str)
{
    
//16進数の文字列に変換
    Console.WriteLine(BitConverter.ToString(str).Replace("-", ""));
}