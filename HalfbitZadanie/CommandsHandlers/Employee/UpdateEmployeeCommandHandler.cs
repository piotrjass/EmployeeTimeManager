using HalfbitZadanie.Commands.Employee;
using MediatR;

namespace HalfbitZadanie.CommandsHandlers.Employee;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
{
 //   private readonly ApplicationDbContext _context;

    public UpdateEmployeeCommandHandler()
    {
   //     _context = context;
    }

    public async Task Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
    {
       // var employee = await _context.Employees.FindAsync(new object[] { request.EmployeeId }, cancellationToken);
      //  if (employee == null)
      //  {
      //      throw new KeyNotFoundException("Employee not found");
      //  }

      //  employee.FirstName = request.FirstName;
      //  employee.LastName = request.LastName;
      //  employee.Email = request.Email;

      //  await _context.SaveChangesAsync(cancellationToken);

     //   return Unit.Value;
    }
}