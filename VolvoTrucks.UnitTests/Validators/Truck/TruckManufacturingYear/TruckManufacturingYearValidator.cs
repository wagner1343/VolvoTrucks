using System;
using System.Linq;
using VolvoTrucks.Core.Exceptions;
using VolvoTrucks.Core.Validators;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.Truck.TruckManufacturingYear;

public class TruckValidators
{

    [Theory]
    [ClassData(typeof(InvalidTruckManufacturingYears))]
    public void TruckValidator_Is_Not_Valid_When_Created_At_Year_Is_Different_Than_Manufacturing_Year(DateTime createdAt, int manufacturingYear)
    {
        var validationResult = new TruckValidator().Validate(new Core.Entities.Truck()
        {
            CreatedAt = createdAt,
            ManufacturingYear = manufacturingYear,
            ModelYear = createdAt.Year
        });
        
        Assert.False(validationResult.IsValid);
    }
    
    [Theory]
    [ClassData(typeof(InvalidTruckManufacturingYears))]
    public void TruckValidator_Throws_When_Created_At_Year_Is_Different_Than_Manufacturing_Year(DateTime createdAt, int manufacturingYear)
    {
        var validationResult = new TruckValidator().Validate(new Core.Entities.Truck()
        {
            CreatedAt = createdAt,
            ManufacturingYear = manufacturingYear,
            ModelYear = createdAt.Year
        });
        
        Assert.Throws<ValidationErrorsException>(validationResult.EnsureIsValid);
    }
    
    [Theory]
    [ClassData(typeof(ValidTruckManufacturingYears))]
    public void TruckValidator_Is_Valid_When_Created_At_Year_Is_Equals_To_Manufacturing_Year(DateTime createdAt, int manufacturingYear)
    {
        var validationResult = new TruckValidator().Validate(new Core.Entities.Truck()
        {
            CreatedAt = createdAt,
            ManufacturingYear = manufacturingYear,
            ModelYear = createdAt.Year
        });
        
        Assert.True(validationResult.IsValid);
    }
    
    [Theory]
    [ClassData(typeof(ValidTruckManufacturingYears))]
    public void TruckValidator_Do_Not_Throws_When_Created_At_Year_Is_Equals_To_Manufacturing_Year(DateTime createdAt, int manufacturingYear)
    {
        var validationResult = new TruckValidator().Validate(new Core.Entities.Truck()
        {
            CreatedAt = createdAt,
            ManufacturingYear = manufacturingYear,
            ModelYear = createdAt.Year
        });

        validationResult.EnsureIsValid();
    }
}