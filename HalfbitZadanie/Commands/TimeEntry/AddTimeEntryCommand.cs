using MediatR;
using HalfbitZadanie.Models;

namespace HalfbitZadanie.Commands.TimeEntries
{
    public class AddTimeEntryCommand : IRequest<TimeEntry>
    {
        public int EmployeeId { get; }
        public DateTime Date { get; }
        public int HoursWorked { get; }

        public AddTimeEntryCommand(int employeeId, DateTime date, int hoursWorked)
        {
            EmployeeId = employeeId;
            Date = date;
            HoursWorked = hoursWorked;
        }
    }
}