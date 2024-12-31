using HalfbitZadanie.Commands.TimeEntries;
using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Models;
using HalfbitZadanie.Repositories;
using MediatR;

namespace HalfbitZadanie.Handlers.TimeEntries
{
    public class UpdateTimeEntryCommandHandler : IRequestHandler<UpdateTimeEntryCommand, TimeEntry>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateTimeEntryCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<TimeEntry> Handle(UpdateTimeEntryCommand request, CancellationToken cancellationToken)
        {
            var updatedTimeEntry = new TimeEntry
            {
                EmployeeId = request.EmployeeId,
                Date = request.Date,
                HoursWorked = request.HoursWorked
            };

            return await _employeeRepository.UpdateTimeEntryAsync(request.EmployeeId, request.EntryId, updatedTimeEntry);
        }
    }
}