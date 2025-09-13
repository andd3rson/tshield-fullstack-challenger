
using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using ToDo.Api.Application.Validations;

var builder = WebApplication.CreateBuilder(args);
if (!builder.Environment.IsDevelopment())
{
    builder.Services.AddHttpsRedirection(options =>
    {
        options.HttpsPort = 443; 
    });
}

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TaskDbContext>(
        x => x.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")
            )
    );
builder.Services.AddScoped<ITaskServices, TaskServices>();


builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<TaskCreateValidation>();
builder.Services.AddValidatorsFromAssemblyContaining<TaskUpdateValidation>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins",
                      policy =>
                      {
                          policy.AllowAnyOrigin()                                             
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHttpsRedirection();
}

app.UseCors("MyAllowSpecificOrigins"); 

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TaskDbContext>();
    db.Database.Migrate(); 
}


app.Run();
