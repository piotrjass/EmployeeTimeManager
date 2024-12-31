using System;
using FluentValidation;
using FluentValidation.Results;
using HalfbitZadanie.Models;
using HalfbitZadanie.Validators;
using Xunit;

namespace Tests
{
    public class ValidationUnitTests
    {
        [Fact]
        public void Should_ThrowValidationError_When_FirstNameIsEmpty()
        {
            // Arrange
            var employee = new Employee
            {
                FirstName = string.Empty, // Invalid input
                LastName = "Doe",
                Email = "john.doe@example.com"
            };

            var validator = new AddEmployeeValidator();

            // Act
            ValidationResult result = validator.Validate(employee);

            // Assert
            Assert.False(result.IsValid); // Walidacja powinna zakończyć się błędem
            Assert.Contains(result.Errors, e => e.ErrorMessage == "First name is required.");
        }
        
        [Fact]
        public void Should_ThrowValidationError_When_EmailIsInvalid()
        {
            // Arrange
            var employee = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "invalid-email" // Invalid email format
            };

            var validator = new AddEmployeeValidator();

            // Act
            ValidationResult result = validator.Validate(employee);

            // Assert
            Assert.False(result.IsValid); // Walidacja powinna zakończyć się błędem
            Assert.Contains(result.Errors, e => e.ErrorMessage == "Invalid email format.");
        }
    }
}