using MediatR;

namespace HalfbitZadanie.Commands.TimeEntries
{
    public class DeleteTimeEntryCommand : IRequest<bool>
    {
        public int EmployeeId { get; }
        public int EntryId { get; }

        public DeleteTimeEntryCommand(int employeeId, int entryId)
        {
            EmployeeId = employeeId;
            EntryId = entryId;
        }
    }
}