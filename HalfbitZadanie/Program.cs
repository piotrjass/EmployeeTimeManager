using System.Reflection;
using HalfbitZadanie.Extensions;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


builder.Services.AddRequestValidations(); 


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton(sp =>
{
    return connectionString;
});


builder.Services.AddRepositories(connectionString); 

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();