using System.Reflection;
using FluentValidation.AspNetCore;
using HalfbitZadanie.IRepositories;
using HalfbitZadanie.Repositories;
using HalfbitZadanie.Validators;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// Request Validations
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddEmployeeValidator>());

// Database connection
builder.Services.AddSingleton(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return connectionString; // Przekazujemy connection string, a nie instancję NpgsqlConnection
});

// Repositories - Rejestracja repozytoriów z connection string
builder.Services.AddScoped<IEmployeeRepository>(sp =>
{
    var connectionString = sp.GetRequiredService<string>(); // Pobieramy connection string z DI
    return new EmployeesRepository(connectionString); // Przekazujemy connection string do repozytorium
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();