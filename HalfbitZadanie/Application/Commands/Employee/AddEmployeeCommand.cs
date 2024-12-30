using MediatR;

namespace HalfbitZadanie.Commands.Employee;

public class AddEmployeeCommand : IRequest<Models.Employee>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public AddEmployeeCommand(string firstName, string lastName, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
    }
}