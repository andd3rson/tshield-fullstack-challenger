using Microsoft.AspNetCore.Mvc;
using ToDo.Api.Dtos.Requests;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    //GET /tasks/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskCreateRequest createRequest)
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TaskUpdateRequest updateRequest)
    {
        if(id != updateRequest.Id)
        {
            return BadRequest();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return NoContent();
    }

}
