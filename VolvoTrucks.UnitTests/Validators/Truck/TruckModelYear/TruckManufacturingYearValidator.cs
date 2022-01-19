using System;
using System.Linq;
using VolvoTrucks.Core.Validators;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.Truck.TruckModelYear;

public class TruckModelYearValidator
{

    [Theory]
    [ClassData(typeof(InvalidTruckModelYears))]
    public void TruckValidator_Is_Not_Valid_When_Model_Year_Is_Invalid(DateTime createdAt, int modelYear)
    {
        var validationResult = new TruckValidator().Validate(new Core.Entities.Truck()
        {
            CreatedAt = createdAt,
            ManufacturingYear = createdAt.Year,
            ModelYear = modelYear,
        });
        
        Assert.False(validationResult.IsValid);
    }
    
    [Theory]
    [ClassData(typeof(ValidTruckModelYears))]
    public void TruckValidator_Is_Valid_When_Model_Year_Is_Invalid(DateTime createdAt, int modelYear)
    {
        var validationResult = new TruckValidator().Validate(new Core.Entities.Truck()
        {
            CreatedAt = createdAt,
            ManufacturingYear = createdAt.Year,
            ModelYear = modelYear,
        });
        
        Assert.True(validationResult.IsValid);
    }
}