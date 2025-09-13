
using FluentValidation;
using FluentValidation.AspNetCore;
using ToDo.Api.Application.Validations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDbContext>(
        x => x.UseSqlServer(
            builder.Configuration.GetConnectionString("taskConnection")
            )
    );
builder.Services.AddScoped<ITaskServices, TaskServices>();


builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<TaskCreateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TaskUpdateValidation>();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
