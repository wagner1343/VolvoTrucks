using VolvoTrucks.Core.Entities;

namespace VolvoTrucks.Core.Validators;

public class TruckModelValidator: IValidator<TruckModel>
{
    private const string TruckModelInvalidName = "truck_model_invalid_name";
    
    public ValidationResult Validate(TruckModel data)
    {
        var errors = new List<ValidationError>();
        
        if (data.Name != "FH" && data.Name != "FM")
        {
            errors.Add(new ValidationError (typeof(TruckModel), "Name", data.Name, TruckModelInvalidName));
        }

        return new ValidationResult(errors);
    }
}