using MediatR;

namespace HalfbitZadanie.Commands.Employee;

public class UpdateEmployeeCommand : IRequest<Models.Employee> 
{
    public int EmployeeId { get; }
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    
    public UpdateEmployeeCommand(int employeeId, string firstName, string lastName, string email)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}