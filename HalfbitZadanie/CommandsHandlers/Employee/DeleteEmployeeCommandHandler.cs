using HalfbitZadanie.Commands.Employee;
using MediatR;

namespace HalfbitZadanie.CommandsHandlers.Employee;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
{
   // private readonly ApplicationDbContext _context;

    public DeleteEmployeeCommandHandler()
    {
      //  _context = context;
    }

    public async Task Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
     //   var employee = await _context.Employees.FindAsync(new object[] { request.EmployeeId }, cancellationToken);
     //   if (employee == null)
     //   {
      //      throw new KeyNotFoundException("Employee not found");
      //  }

      //  _context.Employees.Remove(employee);
      //  await _context.SaveChangesAsync(cancellationToken);

       // return Unit.Value;
    }
}