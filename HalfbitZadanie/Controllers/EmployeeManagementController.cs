using HalfbitZadanie.Commands.Employee;
using HalfbitZadanie.Commands.TimeEntries;
using HalfbitZadanie.Models;
using HalfbitZadanie.Queries.Employee;
using HalfbitZadanie.Queries.TimeEntries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HalfbitZadanie.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeeManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeManagementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var result = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee([FromBody] Employee newEmployee)
        {
            var result = await _mediator.Send(new AddEmployeeCommand(
                newEmployee.FirstName,
                newEmployee.LastName,
                newEmployee.Email
            ));

            return CreatedAtAction(nameof(GetEmployeeById), new { id = result.Id }, result);
        }


        [HttpPut("{id}")]
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
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost("{id}/time-entries")]
        public async Task<ActionResult> AddTimeEntry(int id, [FromBody] TimeEntry timeEntry)
        {
            var result = await _mediator.Send(new AddTimeEntryCommand(
                id,
                timeEntry.Date,
                timeEntry.HoursWorked
            ));
            return Ok(result);
        }

        [HttpGet("{id}/time-entries")]
        public async Task<ActionResult> GetTimeEntries(int id)
        {
            var result = await _mediator.Send(new GetTimeEntriesQuery(id));
            return Ok(result);
        }

        [HttpPut("{id}/time-entries/{entryId}")]
        public async Task<ActionResult> UpdateTimeEntry(int id, int entryId, [FromBody] TimeEntry updatedTimeEntry)
        {
            var result = await _mediator.Send(new UpdateTimeEntryCommand(
                id,
                entryId,
                updatedTimeEntry.Date,
                updatedTimeEntry.HoursWorked
            ));
            return Ok(result);
        }

        [HttpDelete("{id}/time-entries/{entryId}")]
        public async Task<ActionResult> DeleteTimeEntry(int id, int entryId)
        {
            var result = await _mediator.Send(new DeleteTimeEntryCommand(id, entryId));
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}