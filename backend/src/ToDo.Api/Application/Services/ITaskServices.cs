namespace ToDo.Api.Application.Services;

public interface ITaskServices
{
    Task<IEnumerable<TaskResponses>> GetAsync(string? search);
    Task<TaskResponses?> GetByIdAsync(int id);
    Task<int> AddAsync(TaskCreateRequest request);
    Task<bool> UpdateAsync(TaskUpdateRequest request);
    Task<bool> DeleteAsync(int id);
}