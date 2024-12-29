using MediatR;

namespace HalfbitZadanie.Commands.Employee;

public class UpdateEmployeeCommand : IRequest
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public UpdateEmployeeCommand(int employeeId, string firstName, string lastName, string email)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}