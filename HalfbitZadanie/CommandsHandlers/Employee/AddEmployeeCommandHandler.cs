using HalfbitZadanie.Commands.Employee;
using MediatR;
namespace HalfbitZadanie.CommandsHandlers.Employee;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, Models.Employee>
{
   // private readonly ApplicationDbContext _context;

    public AddEmployeeCommandHandler()
    {
    }

    public async Task<Models.Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
        var employee = new Models.Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };
        // _context.Employees.Add(employee);
        // await _context.SaveChangesAsync(cancellationToken);
        return employee;
    }
}