using FluentValidation;
using HalfbitZadanie.Models;

namespace HalfbitZadanie.Validators;


public class AddEmployeeValidator : AbstractValidator<Employee>
{
    public AddEmployeeValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name cannot exceed 50 characters.")
            .Matches("^[A-Za-z]+$").WithMessage("First name can only contain letters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name cannot exceed 50 characters.")
            .Matches("^[A-Za-z]+$").WithMessage("Last name can only contain letters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x)
            .Must(x => !string.IsNullOrWhiteSpace(x.FirstName) || !string.IsNullOrWhiteSpace(x.LastName))
            .WithMessage("At least one of the fields: First Name or Last Name must be filled.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email cannot exceed 100 characters.");

        RuleFor(x => x.FirstName)
            .MinimumLength(2).WithMessage("First name must be at least 2 characters long.");

        RuleFor(x => x.LastName)
            .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.");
    }
}
