namespace Validation.Car;

public class CarCenter
{
    private List<Car> Fleet { get; } = [];

    public void Register(Car car)
    {
        Fleet.Add(car);
    }

    public List<Car> GetFleet()
    {
        return Fleet;
    }
}