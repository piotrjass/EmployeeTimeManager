using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Queries.Employee;
using MediatR;

namespace HalfbitZadanie.Queries.QueriesHandlers;

public class GetAllEmployeesQueryHandler : IRequestHandler
    <GetAllEmployeesQuery, List<Models.Employee>>
{
    
    private readonly IEmployeeRepository _employeeRepository;

    public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    
    public async Task<List<Models.Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
    {
        return await _employeeRepository.GetAllEmployeesAsync();
    }
}