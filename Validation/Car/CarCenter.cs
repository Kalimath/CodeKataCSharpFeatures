using Validation.Validators.Base;
using static Validation.Validators.LicenseValidators;

namespace Validation.Car;

public class CarCenter
{
    private List<Car> Fleet { get; } = [];

    public void Register(Car car)
    {
        VerifyLicense(car);
        
        Fleet.Add(car);
    }

    private static void VerifyLicense(Car car)
    {
        //check that the numberplate has the correct format using the predefined functions in LicenseValidators
        //Format: 001-AAA or AAA-001 (Belgian license of type 6)
        var isValid = car.LicensePlate.Validate(IsBelgianLicensePlateOfType6);
        
        if (!isValid) throw new ArgumentException("Invalid license plate format");
    }
}