using Validation.Car;

var builder = WebApplication.CreateSlimBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();


var carCenter = new CarCenter();
app.MapPost("carcenter/fleet/register", Register);
app.UseHttpsRedirection();
app.Run();
return;


object Register(Car car)
{
    var statusCode = StatusCodes.Status200OK;
    var message = "Car registered successfully";
    try
    {
        carCenter.Register(car);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
        statusCode = StatusCodes.Status400BadRequest;
        message = e.Message;
    }
    return new GenericResponse(statusCode, message);
}

public record GenericResponse(int Status, string Message);