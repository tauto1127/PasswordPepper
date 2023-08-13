using System.Runtime.InteropServices.ComTypes;

namespace PasswordPepper.Model;

public class UserOperation
{
    public static bool AddUser()
    {

        User _user = new User();
        string _pass;
        DateTime created;
        Console.WriteLine("ユーザー名を入力してください");
        _user.Name = Console.ReadLine();
        Console.WriteLine("パスワードを入力してください");
        _pass = Console.ReadLine();
        _user.CreatedDateTime = DateTime.Now;
        _user.PasswordSalt = PasswordUtil.getInitialPasswordSalt(_user.CreatedDateTime.ToString());
        _user.PasswordHash = PasswordUtil.getPasswordHashFromSalt(_user.PasswordSalt, _pass);
        using (var _context = new UserContext())
        {
            _context.User.Add(_user);
            _context.SaveChanges();   
        }
        return true;
    }

    public static bool DeleteUser(string name)
    {
        using (var _context = new UserContext())
        {
            var _user = _context.User.Single(x => x.Name.Equals(name));
            if (_user != null)
            {
                _context.Remove(_user);
                _context.SaveChanges();    
            }
            else
            {
                return false;
            }
            
            return true;
        }

    }

    public static bool Login(string name, string pass)
    {
        using (var _context = new UserContext())
        {
            var _user = _context.User.SingleOrDefault(x => x.Name.Equals(name));
            if (_user != null)
            {
                var passwordHash = PasswordUtil.getPasswordHashFromSalt(_user.PasswordSalt, pass);
                _context.Add(new User()
                {
                    Name = name + "パスワード確認", PasswordHash = passwordHash, PasswordSalt = new byte[0],
                    CreatedDateTime = DateTime.Now
                });
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("ユーザーが見つからない");
            }

            return false;
        }
    }
}