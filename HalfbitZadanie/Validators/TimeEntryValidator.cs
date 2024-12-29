using FluentValidation;
using HalfbitZadanie.Models;

namespace HalfbitZadanie.Validators
{
    public class TimeEntryValidator : AbstractValidator<TimeEntry>
    {
        public TimeEntryValidator()
        {
            // Walidacja godziny pracy: musi być liczbą całkowitą z zakresu 1-24
            RuleFor(te => te.HoursWorked)
                .InclusiveBetween(1, 24)
                .WithMessage("Godziny pracy muszą być liczbą całkowitą w zakresie od 1 do 24.");

            // Walidacja daty pracy: nie może być późniejsza niż dzisiaj
            RuleFor(te => te.Date)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Data nie może być w przyszłości.");
        }
    }
}