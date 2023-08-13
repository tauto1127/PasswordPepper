// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography;
using System.Text;
using PasswordPepper.Model;

string str = "パスワード";

Console.WriteLine("Hello, World!");

while (true)
{
    Console.WriteLine(
        "0:ユーザーの追\n" + 
        "1:ユーザーの削除"
        );
    Console.WriteLine("操作番号を入力してください");
    int input;
    while (true)
    {
        input = Int16.Parse(Console.ReadLine());
        switch (input)
        {
            case 0:
                if (UserOperation.AddUser())
                {
                    Console.WriteLine("完了しました");
                }
                else
                {
                    Console.WriteLine("失敗しました");
                }
                
                break;
            case 1:
                Console.WriteLine("名前を入力してください");
                var _name = Console.ReadLine();
                if (UserOperation.DeleteUser(_name))
                {
                    Console.WriteLine("完了しました");
                }
                else
                {
                    Console.WriteLine("失敗しました");
                }

                break;
        }
    }
    
}