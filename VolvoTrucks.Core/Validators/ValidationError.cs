namespace VolvoTrucks.Core.Validators;

public record ValidationError(Type ValidationTargetType, string Field, dynamic FieldValue, string ErrorCode);