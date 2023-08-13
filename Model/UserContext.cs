using Microsoft.EntityFrameworkCore;

namespace PasswordPepper.Model;

public class UserContext : DbContext
{
    public string DbPath { get; set; }
    public UserContext()
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        DbPath = $"{path}{Path.DirectorySeparatorChar}users.db";
    }
    public DbSet<User>? User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //optionsBuilder.UseSqlite(@"Data Source=user.db"); なぜかこれだとUserテーブルが見つからない データベース消した時もこのエラーだから、データベースが見つからないだけかも
        optionsBuilder.UseSqlite($@"Data Source={DbPath}");
    }
}