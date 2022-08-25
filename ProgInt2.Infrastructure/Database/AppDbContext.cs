using Microsoft.EntityFrameworkCore;
using ProgInt2.Domain.Entities;

namespace ProgInt2.Infrastructure.Database
{
    public class AppDbContext : DbContext
    {
        /* - COMMANDS
                - MIGRATIONS
                    dotnet ef migrations add <MigrationTitle> // IN ProgInt2.Infrastructure
                        OR
                    dotnet ef migrations add <MigrationTitle> --project .\ProgInt2.Infrastructure\

                - UPDATE DATABASE (AFTER EACH MIGRATION)
                    dotnet ef database update
        */

        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ALTER DATASOURCE TO READ DATABASE PATH IN EXECUTION
            // AND MOVE DATABASE TO DATABASE FOLDER

            optionsBuilder.UseSqlite(connectionString: @"DataSource=C:\Users\Aroldo Jales\Documents\Code\Vscode\IFPI\PROGINT2\ProgInt2\ProgInt2.Infrastructure\SQLiteDatabase.db; Cache=Shared");
        }
    }
}