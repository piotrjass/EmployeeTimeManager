using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;

namespace HalfbitZadanie.Repositories;

public class EmployeesRepository :IEmployeeRepository
{
    public Task<List<Employee>> GetAllEmployeesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Employee> GetEmployeeByIdAsync(int id)
    {
        throw new NotImplementedException();
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