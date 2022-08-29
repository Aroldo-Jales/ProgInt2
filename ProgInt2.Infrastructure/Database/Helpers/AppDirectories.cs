namespace ProgInt2.Infrastructure.Database.Helpers
{
    public static class AppDirectories
    {
        public static string getDatabasePath
        {
            get
            {
                string path = Directory.GetCurrentDirectory();                  
                return path.Substring(0, path.LastIndexOf("ProgInt2.Api"))+@"ProgInt2.Infrastructure\Database\SQLite\AppDatabase.db";
            }            
        }
    }
}