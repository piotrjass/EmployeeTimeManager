using AutoFixture;
using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;
using Moq;

namespace Tests;

public class EmployeesUnitTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IEmployeeRepository> _mockEmployeeRepository;
    
    public EmployeesUnitTests()
    {
        _fixture = new Fixture();
        _mockEmployeeRepository = new Mock<IEmployeeRepository>();
    }
    
    [Fact]
    public async Task Should_AddEmployeeToDatabase()
    {
        // Arrange
        var employee = _fixture.Create<Employee>();  

     
        _mockEmployeeRepository.Setup(repo => repo.AddEmployeeAsync(It.IsAny<Employee>()))
            .Returns(Task.CompletedTask);  

        // Act
        await _mockEmployeeRepository.Object.AddEmployeeAsync(employee);

        // Assert
        _mockEmployeeRepository.Verify(repo => repo.AddEmployeeAsync(It.Is<Employee>(e => e.Email == employee.Email)), Times.Once);
    }
    
    [Fact]
    public async Task Should_ThrowException_When_EmailAlreadyExists()
    {
        // Arrange
        var employee = _fixture.Create<Employee>();
        
        _mockEmployeeRepository.Setup(repo => repo.AddEmployeeAsync(It.IsAny<Employee>()))
            .ThrowsAsync(new InvalidOperationException("Użytkownik z tym e-mailem już istnieje."));

        // Act & Assert
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(
            async () => await _mockEmployeeRepository.Object.AddEmployeeAsync(employee)
        );

        Assert.Equal("Użytkownik z tym e-mailem już istnieje.", exception.Message);
        
        _mockEmployeeRepository.Verify(repo => repo.AddEmployeeAsync(It.IsAny<Employee>()), Times.Once);
    }
}