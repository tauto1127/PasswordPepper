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
}