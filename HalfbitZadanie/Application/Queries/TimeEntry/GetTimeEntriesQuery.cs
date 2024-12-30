using MediatR;
using HalfbitZadanie.Models;

namespace HalfbitZadanie.Queries.TimeEntries
{
    public class GetTimeEntriesQuery : IRequest<List<TimeEntry>>
    {
        public int EmployeeId { get; }

        public GetTimeEntriesQuery(int employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}