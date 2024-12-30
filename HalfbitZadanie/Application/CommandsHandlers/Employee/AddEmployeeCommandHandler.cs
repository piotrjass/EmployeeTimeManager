using HalfbitZadanie.Commands.Employee;
using HalfbitZadanie.IRepositories;
using MediatR;
namespace HalfbitZadanie.CommandsHandlers.Employee;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Models.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Models.Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Models.Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };
        
        await _employeeRepository.AddEmployeeAsync(employee);
        return employee;
    }
}
