namespace gamelib_backend.Infrastructure.Domain.DbSettings {
    public class PostgresDbSettings {
        public string Host { get; set; } = "localhost";
        public string Port { get; set; } = "5433";
        public string DbName { get; set; } = "postgres";
        public string Username { get; set; } = "postgres";
        public string Password { get; set; } = "postgres";

        public string GetConnectionString() {
            var builder = new List<string>();

            builder.Add("Host=" + Host);
            builder.Add("Port=" + Port);
            builder.Add("Database=" + DbName);
            builder.Add("Username=" + Username);
            builder.Add("Password=" + Password);

            var connectionString = string.Join(';', builder);

            return connectionString;
        }
    }
}
