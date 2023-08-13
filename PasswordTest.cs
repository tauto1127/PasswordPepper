namespace PasswordPepper;

public class PasswordTest
{
    private string salt = "aiueo";
    public PasswordTest(string pass)
    {
        byte[] saltHash = PasswordUtil.getInitialPasswordSalt(salt);
        byte[] passHash2 = PasswordUtil.getPasswordHashFromPepper(saltHash, pass);
    }
    
}