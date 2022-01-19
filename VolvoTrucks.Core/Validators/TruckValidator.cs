using VolvoTrucks.Core.Entities;

namespace VolvoTrucks.Core.Validators;

public class TruckValidator : IValidator<Truck>
{
    private const string ManufacturingYearInvalid =
        "truck_manufacturing_year_invalid";

    private const string ModelYearInvalid =
        "truck_model_year_invalid";

    public ValidationResult Validate(Truck data)
    {
        var errors = new List<ValidationError>();

        if (data.ManufacturingYear != data.CreatedAt.Year)
        {
            errors.Add(new ValidationError(typeof(Truck), "ManufacturingYear", data.ManufacturingYear,
                ManufacturingYearInvalid));
        }

        var minModelYearAllowed = data.CreatedAt.Year;
        var maxModelYearAllowed = data.CreatedAt.Year + 1;
        if (data.ModelYear < minModelYearAllowed || data.ModelYear > maxModelYearAllowed)
        {
            errors.Add(new ValidationError(typeof(Truck), "ModelYear", data.ModelYear, ModelYearInvalid));
        }

        return new ValidationResult(errors);
    }
}