using Microsoft.AspNetCore.Mvc;

namespace ToDo.Api.Controllers;

[ApiController]
[Route("tasks")]
public class TasksController : ControllerBase
{
    private readonly ITaskServices _taskServices;

    public TasksController(ITaskServices taskServices)
    {
        _taskServices = taskServices;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] string? search)
        => Ok(await _taskServices.GetAsync(search));


    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _taskServices.GetByIdAsync(id);
        if (response == null) {

            return NotFound();
        }
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TaskCreateRequest createRequest)
    {
        
        var response = await _taskServices.AddAsync(createRequest);
       
        return response > 0 ? Created($"/tasks/{response}", new {}) : BadRequest();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] TaskUpdateRequest updateRequest)
    {
        if(id != updateRequest.Id)
        {
            return BadRequest();
        }
        var response = await _taskServices.UpdateAsync(updateRequest);

        return response ? NoContent() : BadRequest();
     }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _taskServices.DeleteAsync(id);
        return response ? NoContent() : BadRequest();
    }

}
