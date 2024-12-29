using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;
using Npgsql;

namespace HalfbitZadanie.Repositories;

public class EmployeesRepository :IEmployeeRepository
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

            // SQL do pobrania wszystkich pracowników
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

            // SQL do pobrania pracownika na podstawie ID
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

    public Task AddEmployeeAsync(Employee employee)
    {
        throw new NotImplementedException();
    }

    public Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
    {
        throw new NotImplementedException();
    }
    
    public Task DeleteEmployeeAsync(int id)
    {
        throw new NotImplementedException();
    }
}