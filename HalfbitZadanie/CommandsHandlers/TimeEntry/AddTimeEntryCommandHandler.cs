using HalfbitZadanie.Commands.TimeEntries;
using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;
using HalfbitZadanie.Repositories;
using MediatR;

namespace HalfbitZadanie.Handlers.TimeEntries
{
    public class AddTimeEntryCommandHandler : IRequestHandler<AddTimeEntryCommand, TimeEntry>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public AddTimeEntryCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<TimeEntry> Handle(AddTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var newTimeEntry = new TimeEntry
            {
                EmployeeId = request.EmployeeId,
                Date = request.Date,
                HoursWorked = request.HoursWorked
            };

            await _employeeRepository.AddTimeEntryAsync(newTimeEntry);
            return newTimeEntry;
        }
    }
}