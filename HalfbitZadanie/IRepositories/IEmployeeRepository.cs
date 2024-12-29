using HalfbitZadanie.Models;

namespace HalfbitZadanie.IRepositories;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(int id, Employee employee);  
    Task DeleteEmployeeAsync(int id);  
}