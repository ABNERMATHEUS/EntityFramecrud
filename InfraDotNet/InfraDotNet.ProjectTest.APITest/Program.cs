using InfraDotNet.ProjectTest.DomainTest.Entities;
using InfraDotNet.ProjectTest.DomainTest.Repositories;
using InfraDotNet.ProjectTest.InfraTest.DataContext;
using InfraDotNet.ProjectTest.InfraTest.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Context>(opt => opt.UseInMemoryDatabase("Database"));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapPost("/student", async (Student student, IStudentRepository studentRepository) =>
{
    var student_created = await studentRepository.CreateAsync(student);


    return Results.Created($"/student/{student_created.Id}", student_created);
});

app.MapGet("/student/{id}", async (string id, IStudentRepository studentRepository) =>
     await studentRepository.FindByIdAsync(id)
        is Student student
            ? Results.Ok(student)
            : Results.NotFound());


app.MapPut("/student", async (Student student, IStudentRepository studentRepository) =>
{
    var todo = await studentRepository.UpdateAsync(student);

    return Results.Ok(todo);
});

app.MapGet("/student", async (IStudentRepository studentRepository) =>
     {
         return Results.Ok(await studentRepository.FindAllAsync());
     });

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}