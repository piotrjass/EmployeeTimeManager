using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;
using Npgsql;

namespace HalfbitZadanie.Repositories;

public class EmployeesRepository : IEmployeeRepository
{

    private readonly string _connectionString;

    public EmployeesRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private NpgsqlConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        var employees = new List<Employee>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

        
            var query = "SELECT Id, FirstName, LastName, Email FROM Employees";

            using (var command = new NpgsqlCommand(query, connection))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3)
                        });
                    }
                }
            }
        }

        return employees;
    }

    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        Employee employee = null;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

        
            var query = "SELECT Id, FirstName, LastName, Email FROM Employees WHERE Id = @Id";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("Id", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        employee = new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3)
                        };
                    }
                }
            }
        }

        return employee;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = @"
            INSERT INTO Employees (FirstName, LastName, Email)
            VALUES (@FirstName, @LastName, @Email)
            RETURNING Id;";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);

                employee.Id = (int)await command.ExecuteScalarAsync(); 
            }
        }
    }

    public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = @"
            UPDATE Employees
            SET FirstName = @FirstName, LastName = @LastName, Email = @Email
            WHERE Id = @Id
            RETURNING Id, FirstName, LastName, Email;";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Employee
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3)
                        };
                    }
                }
            }
        }

        return null;
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = "DELETE FROM Employees WHERE Id = @Id";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);

                await command.ExecuteNonQueryAsync(); 
            }
        }
    }

    public async Task<List<TimeEntry>> GetTimeEntriesByEmployeeIdAsync(int employeeId)
    {
        var timeEntries = new List<TimeEntry>();

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = "SELECT Id, EmployeeId, Date, HoursWorked FROM TimeEntries WHERE EmployeeId = @EmployeeId";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        timeEntries.Add(new TimeEntry
                        {
                            Id = reader.GetInt32(0),
                            EmployeeId = reader.GetInt32(1),
                            Date = reader.GetDateTime(2),
                            HoursWorked = reader.GetInt32(3)
                        });
                    }
                }
            }
        }

        return timeEntries;
    }


    public async Task<TimeEntry> GetTimeEntryByIdAsync(int employeeId, int entryId)
    {
        TimeEntry timeEntry = null;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = "SELECT Id, EmployeeId, Date, HoursWorked FROM TimeEntries WHERE EmployeeId = @EmployeeId AND Id = @EntryId";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@EntryId", entryId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        timeEntry = new TimeEntry
                        {
                            Id = reader.GetInt32(0),
                            EmployeeId = reader.GetInt32(1),
                            Date = reader.GetDateTime(2),
                            HoursWorked = reader.GetInt32(3)
                        };
                    }
                }
            }
        }

        return timeEntry;
    }

 public async Task AddTimeEntryAsync(TimeEntry timeEntry)
        {
            // walidacja czy pracownik istnieje
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "SELECT COUNT(1) FROM Employees WHERE Id = @EmployeeId";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", timeEntry.EmployeeId);

                    var count = (long)await command.ExecuteScalarAsync();

                    if (count == 0)
                    {
                        throw new InvalidOperationException("Pracownik o podanym identyfikatorze nie istnieje.");
                    }
                }
            }
            // Walidacja, czy pracownik ma już wpis w tej samej dacie

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                
                var query = @"
                SELECT COUNT(1)
               FROM TimeEntries
                  WHERE EmployeeId = @EmployeeId
                AND Date = @Date
                  ";
                
                
                
                using (var command = new NpgsqlCommand(query, connection))
                {
                    var data = new DateTime(timeEntry.Date.Year, timeEntry.Date.Month, timeEntry.Date.Day, 0, 0, 0);
                    command.Parameters.AddWithValue("@EmployeeId", timeEntry.EmployeeId);
                    command.Parameters.AddWithValue("@Date", data);  
                    var count = (long)await command.ExecuteScalarAsync();
                    
                    
                    if (count > 0)
                    {
                        throw new InvalidOperationException("Pracownik już ma zarejestrowane godziny pracy w tej dacie.");
                    }
                }
            }


            // Walidacja godziny pracy
            if (timeEntry.HoursWorked < 1 || timeEntry.HoursWorked > 24)
            {
                throw new ArgumentOutOfRangeException(nameof(timeEntry.HoursWorked), "Godziny pracy muszą być liczbą całkowitą w zakresie od 1 do 24.");
            }

            // Jeśli walidacja przeszła, dodajemy wpis
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var query = "INSERT INTO TimeEntries (EmployeeId, Date, HoursWorked) VALUES (@EmployeeId, @Date, @HoursWorked)";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", timeEntry.EmployeeId);
                    command.Parameters.AddWithValue("@Date", timeEntry.Date);
                    command.Parameters.AddWithValue("@HoursWorked", timeEntry.HoursWorked);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    public async Task<TimeEntry> UpdateTimeEntryAsync(int employeeId, int entryId, TimeEntry updatedTimeEntry)
    {
        TimeEntry updated = null;

        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = "UPDATE TimeEntries SET Date = @Date, HoursWorked = @HoursWorked WHERE EmployeeId = @EmployeeId AND Id = @EntryId";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@EntryId", entryId);
                command.Parameters.AddWithValue("@Date", updatedTimeEntry.Date);
                command.Parameters.AddWithValue("@HoursWorked", updatedTimeEntry.HoursWorked);

                var rowsAffected = await command.ExecuteNonQueryAsync();

                if (rowsAffected > 0)
                {
                    updated = new TimeEntry
                    {
                        Id = entryId,
                        EmployeeId = employeeId,
                        Date = updatedTimeEntry.Date,
                        HoursWorked = updatedTimeEntry.HoursWorked
                    };
                }
            }
        }

        return updated;
    }

    public async Task DeleteTimeEntryAsync(int employeeId, int entryId)
    {
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            var query = "DELETE FROM TimeEntries WHERE EmployeeId = @EmployeeId AND Id = @EntryId";

            using (var command = new NpgsqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                command.Parameters.AddWithValue("@EntryId", entryId);

                await command.ExecuteNonQueryAsync();
            }
        }
    }
}