using VolvoTrucks.Core.Validators;

namespace VolvoTrucks.Core.Exceptions;

public class ValidationErrorsException : Exception
{
    public List<ValidationError> Errors { get; set; }
    public ValidationErrorsException(List<ValidationError> errors) : base(
        $"Validation exception raised with the following errors: {errors.Aggregate("", (errorsString, error) => $"{errorsString}\n {error}")}")
    {
        Errors = errors;
    }
}