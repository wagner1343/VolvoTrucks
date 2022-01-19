using System.ComponentModel.DataAnnotations;
using VolvoTrucks.Core.Exceptions;

namespace VolvoTrucks.Core.Validators;

public class ValidationResult
{
    public bool IsValid => Errors.Count == 0;
    public List<ValidationError> Errors { get; }
    
    public ValidationResult(List<ValidationError> errors)
    {
        Errors = errors;
    }

    public void EnsureIsValid()
    {
        if (!IsValid)
        {
            throw new ValidationErrorsException(Errors);
        }
    }
}