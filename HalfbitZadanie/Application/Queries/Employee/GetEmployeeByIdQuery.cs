using MediatR;
namespace HalfbitZadanie.Queries.Employee;
public class GetEmployeeByIdQuery : IRequest<Models.Employee>
{
    public int EmployeeId { get; set; }

    public GetEmployeeByIdQuery(int employeeId)
    {
        EmployeeId = employeeId;
    }
}