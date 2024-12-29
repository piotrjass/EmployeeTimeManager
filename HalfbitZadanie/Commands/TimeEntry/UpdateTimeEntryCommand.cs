using MediatR;
using HalfbitZadanie.Models;

namespace HalfbitZadanie.Commands.TimeEntries
{
    public class UpdateTimeEntryCommand : IRequest<TimeEntry>
    {
        public int EmployeeId { get; }
        public int EntryId { get; }
        public DateTime Date { get; }
        public int HoursWorked { get; }

        public UpdateTimeEntryCommand(int employeeId, int entryId, DateTime date, int hoursWorked)
        {
            EmployeeId = employeeId;
            EntryId = entryId;
            Date = date;
            HoursWorked = hoursWorked;
        }
    }
}