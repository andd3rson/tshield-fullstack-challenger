namespace ToDo.Api.Domain;

public abstract class Audit
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
