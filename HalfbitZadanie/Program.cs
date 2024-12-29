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
//Łączenie z bazą danych
builder.Services.AddSingleton<NpgsqlConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new NpgsqlConnection(connectionString);
});
//
builder.Services.AddScoped<IEmployeeRepository, EmployeesRepository>();

var app = builder.Build();

/*app.MapGet("/", async (NpgsqlConnection db) =>
{
    await db.OpenAsync();
    return Results.Ok("Połączenie z bazą danych nawiązane!");
});*/

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
