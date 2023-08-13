using Microsoft.EntityFrameworkCore;

namespace PasswordPepper.Model;

public class UserContext : DbContext
{
    /*
    public UserContext(DbContextOptions options) : base(options)
    {
        
    }*/
    public UserContext(){}

    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=user.db");
}