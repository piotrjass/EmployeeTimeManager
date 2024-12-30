using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HalfbitZadanie.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        {
       
            services.AddScoped<IEmployeeRepository>(sp =>
            {
                return new EmployeesRepository(connectionString); 
            });
            
            return services;
        }
    }
}