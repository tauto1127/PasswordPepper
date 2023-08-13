namespace PasswordPepper;

public class PasswordTest
{
    private string salt = "aiueo";
    public PasswordTest(string pass)
    {
        byte[] saltHash = PasswordUtil.GetInitialPasswordSalt(salt);
        byte[] passHash2 = PasswordUtil.GetPasswordHashFromPepper(saltHash, pass, PasswordPepper.PasswordSalt.Pepper);
    }
    
}