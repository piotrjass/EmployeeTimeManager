using AutoFixture;
using HalfbitZadanie.Models;
using HalfbitZadanie.Repositories;
using Npgsql;

namespace Tests;

public class IntegrationTests
{
    private readonly EmployeesRepository _employeeRepository;
    private readonly IFixture _fixture;

    public IntegrationTests()
    {
        _fixture = new Fixture();
        _employeeRepository = new EmployeesRepository("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=EmployeeManager;");
    }
    
    [Fact]
    public async Task Should_AddEmployeeToDatabase()
    {
        // Arrange 
        var employee = _fixture.Create<Employee>();

        // Act 
        await _employeeRepository.AddEmployeeAsync(employee);

        // Assert - sprawdzamy, czy użytkownik został dodany do bazy danych
        var query = "SELECT COUNT(1) FROM Employees WHERE Email = @Email";
            
        using (var connection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=EmployeeManager;"))
        {
            await connection.OpenAsync();
            using (var cmd = new NpgsqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Email", employee.Email);
                var result = await cmd.ExecuteScalarAsync();
                Assert.Equal(1L, result);  
            }
        }
    }
    
    [Fact]
    public async Task Should_ThrowException_When_EmailAlreadyExists()
    {
        
        var employee2 = new Employee
        {
            FirstName = "Jane",
            LastName = "Smith",
            Email = "john.doe@example.com"
        };

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            async () => await _employeeRepository.AddEmployeeAsync(employee2)
        );

        Assert.StartsWith("Użytkownik z adresem e-mail", exception.Message);
        Assert.Contains("john.doe@example.com", exception.Message);
    }
}
