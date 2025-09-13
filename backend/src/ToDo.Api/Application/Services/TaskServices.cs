
namespace ToDo.Api.Application.Services;

public class TaskServices : ITaskServices
{
    private readonly TaskDbContext _context;

    public TaskServices(TaskDbContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<TaskResponses>> GetAsync(string? search)
    {
        return await _context.Set<Tasks>()
                                    .Where(x =>
                                            EF.Functions.Like(x.Title, $"%{search}%") ||
                                            EF.Functions.Like(x.Description, $"%{search}%"))
                                    .Select(x =>
                                    new TaskResponses(x.Id,
                                           x.Title,
                                           x.Description,
                                           x.IsDone,
                                           x.LastUpdatedAt))
                                         .ToListAsync();
    }

    public async Task<TaskResponses?> GetByIdAsync(int id)
    {
        var response = await _context.Set<Tasks>()
                             .SingleOrDefaultAsync(x => x.Id == id);

        if (response != null)
        {
            return new TaskResponses(
                response.Id,
                response.Title,
                response.Description,
                response.IsDone,
                response.LastUpdatedAt);
        }

        return null;
    }



    public async Task<int> AddAsync(TaskCreateRequest request)
    {
        var model = new Tasks(
                               request.Title,
                               request.Description,
                               request.IsDone);

        _context.Set<Tasks>().Add(model);
        await _context.SaveChangesAsync();
        return model.Id;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var obj = await _context.Set<Tasks>()
                            .FirstOrDefaultAsync(x => x.Id == id);
        if (obj == null)
        {
            return false;
        }
        _context.Set<Tasks>().Remove(obj);
        return await _context.SaveChangesAsync() > 0; 
    }
    public async Task<bool> UpdateAsync(TaskUpdateRequest request)
    {
        var obj = await _context.Set<Tasks>()
                            .FirstOrDefaultAsync(x => x.Id == request.Id);
        if (obj == null)
        {
            return false;
        }
        obj.UpdateObject(request.Title, request.Description, request.IsDone);

        _context.Set<Tasks>().Update(obj);

        return await _context.SaveChangesAsync() > 0;
    }
}


