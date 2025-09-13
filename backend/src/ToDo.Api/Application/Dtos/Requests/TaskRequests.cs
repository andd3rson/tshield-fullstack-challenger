namespace ToDo.Api.Application.Dtos.Requests;

public record TaskCreateRequest(string Title, string? Description, bool IsDone);
public record TaskUpdateRequest(int Id, string Title, string? Description, bool IsDone);

