namespace PasswordPepper.Model;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
}