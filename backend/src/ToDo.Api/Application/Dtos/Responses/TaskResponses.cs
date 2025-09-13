namespace ToDo.Api.Application.Dtos.Responses;

public record TaskResponses(int Id, string Title, string? Description, bool IsDone, DateTime LastUpdateAt);

