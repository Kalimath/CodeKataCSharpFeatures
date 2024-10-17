namespace Validation.Validators.Base;

public class ValidationResult
{
    public bool IsValid { get; set; }
    public List<string> Errors { get; } = [];  // Default to empty array if no errors provided
    
    public ValidationResult(bool isValid) => IsValid = isValid;

    public ValidationResult(bool isValid, string[] errors) : this(isValid)
    {
        Errors = [..errors];
        if (errors.Length == 0)
            IsValid = isValid;  // If no errors provided, consider the validation as valid
    }

    public void AddError(string error)
    {
        Errors.Add(error);
        IsValid = false;
    }
}