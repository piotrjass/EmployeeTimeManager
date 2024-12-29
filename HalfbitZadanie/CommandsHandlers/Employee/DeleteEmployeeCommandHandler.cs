using HalfbitZadanie.Commands.Employee;
using HalfbitZadanie.IRepositories;
using MediatR;

namespace HalfbitZadanie.CommandsHandlers.Employee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
{
    private readonly IEmployeeRepository _employeeRepository;

    public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);
        if (employee == null)
        {
            return false; 
        }
        await _employeeRepository.DeleteEmployeeAsync(request.EmployeeId);
        return true; 
    }
}