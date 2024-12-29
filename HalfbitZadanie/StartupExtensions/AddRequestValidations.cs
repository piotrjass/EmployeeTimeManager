using FluentValidation.AspNetCore;
using HalfbitZadanie.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace HalfbitZadanie.Extensions
{
    public static class ValidationExtensions
    {
        public static IServiceCollection AddRequestValidations(this IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddEmployeeValidator>());
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<TimeEntryValidator>());

            return services;
        }
    }
}