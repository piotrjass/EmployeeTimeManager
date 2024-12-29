using MediatR;

namespace HalfbitZadanie.Commands.Employee;

public class DeleteEmployeeCommand : IRequest
{
    public int EmployeeId { get; set; }

    public DeleteEmployeeCommand(int employeeId)
    {
        EmployeeId = employeeId;
    }
}