using HalfbitZadanie.Commands.Employee;
using HalfbitZadanie.Models;
using HalfbitZadanie.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HalfbitZadanie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet(Name = "GetAllEmployees")]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result); 
        }
        
        [HttpGet("{id}", Name = "GetEmployeeById")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (result == null)
            {
                return NotFound(); 
            }
            return Ok(result); 
        }
     
        [HttpPost(Name = "AddEmployee")]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee newEmployee)
        {
            var result = await _mediator.Send(new AddEmployeeCommand(
                newEmployee.FirstName, 
                newEmployee.LastName, 
                newEmployee.Email
            ));

            return Ok(result);
        }
        
        [HttpPut("{id}", Name = "UpdateEmployee")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(
                id,
                updatedEmployee.FirstName,
                updatedEmployee.LastName,
                updatedEmployee.Email
            ));

            if (result == null)
            {
                return NotFound(); // Jeśli pracownik nie został znaleziony, zwróć NotFound
            }

            return Ok(result); // Zwróć zaaktualizowanego pracownika
        }
     
        [HttpDelete("{id}", Name = "DeleteEmployee")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
              var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (!result)
            {
                return NotFound(); 
            }
            return NoContent(); 
        }
    }
}