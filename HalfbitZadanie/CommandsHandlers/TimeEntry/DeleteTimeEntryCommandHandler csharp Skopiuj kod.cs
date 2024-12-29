using HalfbitZadanie.Commands.TimeEntries;
using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Repositories;
using MediatR;

namespace HalfbitZadanie.Handlers.TimeEntries
{
    public class DeleteTimeEntryCommandHandler : IRequestHandler<DeleteTimeEntryCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteTimeEntryCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteTimeEntryCommand request, CancellationToken cancellationToken)
        {
            await _employeeRepository.DeleteTimeEntryAsync(request.EmployeeId, request.EntryId);
            return true;
        }
    }
}