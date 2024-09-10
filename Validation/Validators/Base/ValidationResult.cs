namespace Validation.Validators.Base;

public record ValidationResult(bool IsValid, string? ErrorMessage = null);