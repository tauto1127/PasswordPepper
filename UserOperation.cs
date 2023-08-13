using System.Runtime.InteropServices.ComTypes;
using System.Text;

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
        _user.PasswordHash = PasswordUtil.getPasswordHashFromPepper(_user.PasswordSalt, _pass);
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
                var passwordHash = PasswordUtil.getPasswordHashFromPepper(_user.PasswordSalt, pass);
                if (Encoding.Unicode.GetString(passwordHash).Equals(Encoding.Unicode.GetString(_user.PasswordHash)))
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine("ユーザーが見つからない");
            }

            return false;
        }
    }
}