namespace gamelib_backend.Infrastructure.Domain.DbSettings {
    public class PostgresDbSettings {
        public string Host { get; set; }
        public string Port { get; set; }
        public string DbName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public string GetConnectionString() {
            var builder = new List<string>();
            builder.Add("Host=" + Environment.GetEnvironmentVariable("DB_HOST") ?? Host);
            builder.Add("Port=" + Environment.GetEnvironmentVariable("DB_PORT") ?? Port);
            builder.Add("Database=" + Environment.GetEnvironmentVariable("DB_NAME") ?? DbName);
            builder.Add("Username=" + Environment.GetEnvironmentVariable("DB_USERNAME") ?? UserName);
            builder.Add("Password=" + Environment.GetEnvironmentVariable("DB_PASSWORD") ?? Password);
            
            var connectionString = string.Join(';', builder);
            
            return connectionString;
        }
    }
}
