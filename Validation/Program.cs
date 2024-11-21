using Validation;
using Validation.Car;
using Validation.LicensePlates;

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
app.MapPost("car-center/fleet/registration/belgium", RegisterBelgianCar);
app.MapGet("car-center/fleet", GetFleet);
app.UseHttpsRedirection();
app.Run();
return;


object RegisterBelgianCar(string licensePlate, int licenseType)
{
    var statusCode = StatusCodes.Status200OK;
    var message = "Car registered successfully";
    Car car = null!;
    try
    {
        car = new Car(new BelgianLicensePlate(licensePlate, Enum.Parse<BasicBelgianLicenseType>("Type" + licenseType)));
        carCenter.Register(car);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        //Console.WriteLine(e.StackTrace);
        statusCode = StatusCodes.Status400BadRequest;
        message = e.Message;
    }
    return new GenericResponse(statusCode, message, car);
}


object GetFleet()
{
    var statusCode = StatusCodes.Status200OK;
    var message = "Fleet retrieved successfully";
    var cars = carCenter.GetFleet();
    return new GenericResponse(statusCode, message, cars);
}

namespace Validation
{
    public record GenericResponse(int Status, string Message, object? Data = null);
}