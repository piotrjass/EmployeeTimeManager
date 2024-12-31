using Npgsql;

namespace HalfbitZadanie.Infrastructure.StartupExtensions
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeDbAsync(this IApplicationBuilder app, string connectionString)
        {
            using var connection = new NpgsqlConnection(connectionString);
            await connection.OpenAsync();

            // Tworzenie tabeli employees, jeśli nie istnieje
            await CreateTableIfNotExists(connection, "employees", @"
                CREATE TABLE IF NOT EXISTS employees (
                    id SERIAL PRIMARY KEY,
                    firstname VARCHAR(100),
                    lastname VARCHAR(100),
                    email VARCHAR(100) UNIQUE NOT NULL
                );
            ");

            // Tworzenie tabeli timeentries, jeśli nie istnieje
            await CreateTableIfNotExists(connection, "timeentries", @"
                CREATE TABLE IF NOT EXISTS timeentries (
                    id SERIAL PRIMARY KEY,
                    employee_id INT REFERENCES employees(id) ON DELETE CASCADE,
                    start_time TIMESTAMP NOT NULL,
                    end_time TIMESTAMP NOT NULL,
                    description TEXT
                );
            ");
        }

        // Metoda pomocnicza, która wykonuje zapytanie tworzenia tabeli, jeśli ta nie istnieje
        private static async Task CreateTableIfNotExists(NpgsqlConnection connection, string tableName, string createTableQuery)
        {
            using var command = new NpgsqlCommand(createTableQuery, connection);
            await command.ExecuteNonQueryAsync();
            Console.WriteLine($"Table '{tableName}' is ready.");
        }
    }
}
