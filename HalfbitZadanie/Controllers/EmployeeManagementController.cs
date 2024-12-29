using HalfbitZadanie.Models;
using HalfbitZadanie.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HalfbitZadanie.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeeManagementController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeManagementController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // Pobranie listy pracowników
    [HttpGet(Name = "GetAllEmployees")]
    public async Task<ActionResult<List<Employee>>> GetAllEmployees()
    {
        var result = await _mediator.Send(new GetAllEmployeesQuery());
        return result;
    }

    // Pobranie szczegółów pracownika
    [HttpGet("{id}", Name = "GetEmployeeById")]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        return Ok(); // Placeholder logic
    }

    // Dodawanie nowego pracownika
    [HttpPost(Name = "AddEmployee")]
    public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee newEmployee)
    {
        return Ok(); // Placeholder logic
    }

    // Aktualizacja danych pracownika
    [HttpPut("{id}", Name = "UpdateEmployee")]
    public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
    {
        return Ok(); // Placeholder logic
    }

    // Usuwanie pracownika
    [HttpDelete("{id}", Name = "DeleteEmployee")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        return Ok(); // Placeholder logic
    }
}