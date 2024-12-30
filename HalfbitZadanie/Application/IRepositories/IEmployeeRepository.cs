using HalfbitZadanie.Models;

namespace HalfbitZadanie.IRepositories;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
    Task<Employee> GetEmployeeByIdAsync(int id);
    Task AddEmployeeAsync(Employee employee);
    Task<Employee> UpdateEmployeeAsync(int id, Employee employee);  
    Task DeleteEmployeeAsync(int id);  
    
    
    // Zarządzaenie czasem pracy
    Task<List<TimeEntry>> GetTimeEntriesByEmployeeIdAsync(int employeeId);
    Task<TimeEntry> GetTimeEntryByIdAsync(int employeeId, int entryId);
    Task AddTimeEntryAsync(TimeEntry timeEntry);
    Task<TimeEntry> UpdateTimeEntryAsync(int employeeId, int entryId, TimeEntry updatedTimeEntry);
    Task DeleteTimeEntryAsync(int employeeId, int entryId);
}