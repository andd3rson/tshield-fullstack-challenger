namespace ToDo.Api.Domain;

public class Tasks
{
    public int Id { get; set; }
    public int Title { get; set; }
    public string? Description { get; set; }
    public bool IsDone { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
