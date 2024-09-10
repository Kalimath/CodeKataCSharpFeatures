namespace Validation.Validators.Base;

public static class EqualityValidator
{
    public static bool Validate<TInput>(this TInput @this, params Func<TInput, bool>[] predicates) => predicates.All(predicate => predicate(@this));
}