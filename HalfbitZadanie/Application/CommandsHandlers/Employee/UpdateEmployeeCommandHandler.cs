using HalfbitZadanie.Commands.Employee;
using HalfbitZadanie.IRepositories;
using MediatR;

namespace HalfbitZadanie.CommandsHandlers.Employee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Models.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Models.Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        if (employee == null)
        {
            return null; 
        }

       
        employee.FirstName = request.FirstName;
        employee.LastName = request.LastName;
        employee.Email = request.Email;

      
        await _employeeRepository.UpdateEmployeeAsync(request.EmployeeId, employee);

        return employee; 
    }
}
