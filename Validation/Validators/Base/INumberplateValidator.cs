namespace Validation.Validators.Base;

public interface INumberplateValidator
{
    ValidationResult IsValid(string numberplate);
}