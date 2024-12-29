using MediatR;

namespace HalfbitZadanie.Commands.Employee;

public class DeleteEmployeeCommand : IRequest<bool> // assuming it returns a bool indicating success or failure
{
    public int EmployeeId { get; }
    
    public DeleteEmployeeCommand(int employeeId)
    {
        EmployeeId = employeeId;
    }
}