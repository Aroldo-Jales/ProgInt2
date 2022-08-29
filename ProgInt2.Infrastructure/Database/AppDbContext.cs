using Microsoft.EntityFrameworkCore;
using ProgInt2.Domain.Entities;
using ProgInt2.Infrastructure.Database.Helpers;
namespace ProgInt2.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        /* - COMMANDS
                - MIGRATIONS
                    dotnet ef migrations add <MigrationName> --project .\ProgInt2.Infrastructure\ -o DataBase/SQLite/Migrations

                - UPDATE DATABASE (AFTER EACH MIGRATION)
                    dotnet ef database update
        */
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {                        
            optionsBuilder.UseSqlite(connectionString: String.Format(@"DataSource={0}; Cache=Shared", AppDirectories.getDatabasePath));
        }
    }
}