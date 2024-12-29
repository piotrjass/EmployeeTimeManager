using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;
using HalfbitZadanie.Queries.TimeEntries;
using HalfbitZadanie.Repositories;
using MediatR;

namespace HalfbitZadanie.Handlers.TimeEntries
{
    public class GetTimeEntriesQueryHandler : IRequestHandler<GetTimeEntriesQuery, List<TimeEntry>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetTimeEntriesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<TimeEntry>> Handle(GetTimeEntriesQuery request, CancellationToken cancellationToken)
        {
            return await _employeeRepository.GetTimeEntriesByEmployeeIdAsync(request.EmployeeId);
        }
    }
}