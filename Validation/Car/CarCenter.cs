using Validation.Validators.Base;
using static Validation.Validators.LicenseValidators;

namespace Validation.Car;

public class CarCenter
{
    private List<Car> Fleet { get; } = [];

    public void AddToFleet(Car car)
    {
        //check that the numberplate has the correct format using the predefined functions in LicenseValidators
        //Format: 001-AAA or AAA-001
        car.LicensePlate.Validate(IsBelgianLicensePlateOfType6);
        
        Fleet.Add(car);
    }
}