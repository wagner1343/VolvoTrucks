using System;
using VolvoTrucks.Core.Exceptions;
using VolvoTrucks.Core.Validators;
using VolvoTrucks.UnitTests.Validators.Truck.TruckModelYear;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.TruckModel;

public class TruckModelNameValidator
{

    [Theory]
    [ClassData(typeof(InvalidTruckModelNames))]
    public void TruckModelValidator_Is_Not_Valid_When_Model_Name_Is_Invalid(string modelName)
    {
        var validationResult = new TruckModelValidator().Validate(new Core.Entities.TruckModel()
        {
            Name = modelName
        });
        
        Assert.False(validationResult.IsValid);
    }
    
    [Theory]
    [ClassData(typeof(InvalidTruckModelNames))]
    public void TruckModelValidator_Throws_When_Model_Name_Is_Invalid(string modelName)
    {
        var validationResult = new TruckModelValidator().Validate(new Core.Entities.TruckModel()
        {
            Name = modelName
        });
        
        Assert.Throws<ValidationErrorsException>(validationResult.EnsureIsValid);
    }
    
    [Theory]
    [ClassData(typeof(ValidTruckModelNames))]
    public void TruckModelValidator_Do_Not_Throws_When_Model_Name_Is_Valid(string modelName)
    {
        var validationResult = new TruckModelValidator().Validate(new Core.Entities.TruckModel()
        {
            Name = modelName
        });
        
        validationResult.EnsureIsValid();
    }
}