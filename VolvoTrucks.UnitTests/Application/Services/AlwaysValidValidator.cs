using System.Collections.Generic;
using VolvoTrucks.Core.Validators;

namespace VolvoTrucks.UnitTests.Application.Services;

public class AlwaysValidValidator<T> : IValidator<T>
{
    public ValidationResult Validate(T data)
    {
        return new ValidationResult(new List<ValidationError>());
    }
}