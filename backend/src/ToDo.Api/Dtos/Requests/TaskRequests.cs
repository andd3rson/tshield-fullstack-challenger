namespace ToDo.Api.Dtos.Requests;

public record TaskCreateRequest(int Title, string? Description, bool IsDone);
public record TaskUpdateRequest(int Id, int Title, string? Description, bool IsDone);

