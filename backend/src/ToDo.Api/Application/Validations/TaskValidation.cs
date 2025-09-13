using FluentValidation;

namespace ToDo.Api.Application.Validations;

public class TaskCreateValidation : AbstractValidator<TaskCreateRequest>
{
    public TaskCreateValidation()
    {
        RuleFor(x => x.Title)
             .MinimumLength(5)
             .NotNull()
             .NotEmpty();

        RuleFor(x => x.IsDone)
            .NotNull();
    }
}

public class TaskUpdateValidation : AbstractValidator<TaskUpdateRequest>
{
    public TaskUpdateValidation()
    {
        RuleFor(x=>x.Id)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Title)
           .MinimumLength(5)
           .NotNull()
           .NotEmpty();

        RuleFor(x => x.IsDone)
            .NotNull();
    }
}