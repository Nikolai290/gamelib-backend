namespace gamelib_backend.Infrastructure.Domain.DbSettings {
    public class PostgresDbSettings {
        public string Host { get; set; } = "localhost";
        public string Port { get; set; } = "5433";
        public string DbName { get; set; } = "postgres";
        public string UserName { get; set; } = "postgres";
        public string Password { get; set; } = "postgres";

        public static string GetConnectionString(PostgresDbSettings instance) {
            var builder = new List<string>();
            builder.Add("Host=" + Environment.GetEnvironmentVariable("DB_HOST") ?? instance.Host);
            builder.Add("Port=" + Environment.GetEnvironmentVariable("DB_PORT") ?? instance.Port);
            builder.Add("Database=" + Environment.GetEnvironmentVariable("DB_NAME") ?? instance.DbName);
            builder.Add("Username=" + Environment.GetEnvironmentVariable("DB_USERNAME") ?? instance.UserName);
            builder.Add("Password=" + Environment.GetEnvironmentVariable("DB_PASSWORD") ?? instance.Password);
            
            var connectionString = string.Join(';', builder);
            
            return connectionString;
        }
    }
}
