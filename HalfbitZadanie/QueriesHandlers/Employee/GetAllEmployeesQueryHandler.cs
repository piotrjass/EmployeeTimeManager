using HalfbitZadanie.Queries.Employee;
using MediatR;

namespace HalfbitZadanie.Queries.QueriesHandlers;

public class GetAllEmployeesQueryHandler : IRequestHandler
    <GetAllEmployeesQuery, List<Models.Employee>>
{
    public Task<List<Models.Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}