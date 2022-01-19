namespace VolvoTrucks.Core.Validators;

public interface IValidator<T>
{
    public ValidationResult Validate(T data);
}