using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HalfbitZadanie.Controllers;

[ApiController]
[Route("api/employees/{id}/time-entries")]
public class TimeEntriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TimeEntriesController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<ActionResult> AddTimeEntry()
    {
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult> GetTimeEntries()
    {
        return Ok();
    }

    [HttpPut("{entryId}")]
    public async Task<ActionResult> UpdateTimeEntry()
    {
        return Ok();
    }

    [HttpDelete("{entryId}")]
    public async Task<ActionResult> DeleteTimeEntry()
    {
        return Ok();
    }
}