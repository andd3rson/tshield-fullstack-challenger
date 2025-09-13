namespace ToDo.Api.Dtos.Responses;

public record TaskResponses(int Id, int Title, string? Description, bool IsDone, DateTime LastUpdateAt);

