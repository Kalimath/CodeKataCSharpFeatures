namespace Validation.Car;

public class Car(string licensePlate)
{
    public string LicensePlate { get; } = licensePlate;
}