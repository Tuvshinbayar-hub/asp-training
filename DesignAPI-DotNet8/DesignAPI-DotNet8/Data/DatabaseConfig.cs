namespace DesignAPI_DotNet8.Data
{
    public class DatabaseConfig
    {
        public static string GetConnectionString()
        {
            var dbHost = Environment.GetEnvironmentVariable("DB_HOST_URL") ?? "localhost";
            var dbPort = Environment.GetEnvironmentVariable("DB_PORT") ?? "3306";
            var dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "database";
            var dbUser = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "username";
            var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "password";

            return $"Server={dbHost};Initial Catalog={dbName};Persist Security Info=False;User ID={dbUser};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        }
    }
}
