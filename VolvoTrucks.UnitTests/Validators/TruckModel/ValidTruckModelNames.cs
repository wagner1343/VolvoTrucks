using System;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.TruckModel;

public class ValidTruckModelNames : TheoryData<string>
{
    public ValidTruckModelNames()
    {
        Add("FM");
        Add("FH");
    }
}