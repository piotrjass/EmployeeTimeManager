using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Queries.Employee;
using MediatR;

namespace HalfbitZadanie.Queries.QueriesHandlers;

public class GetEmployeeByIdQueryHandler : IRequestHandler
    <GetEmployeeByIdQuery, Models.Employee>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<Models.Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        // Wywołanie metody repozytorium do pobrania pracownika na podstawie ID
        var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

        // Zwrócenie pracownika, jeśli istnieje, w przeciwnym razie null
        return employee;
    }
}