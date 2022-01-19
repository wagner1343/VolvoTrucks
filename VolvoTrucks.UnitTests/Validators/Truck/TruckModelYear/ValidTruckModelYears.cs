using System;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.Truck.TruckModelYear;

public class ValidTruckModelYears : TheoryData
{
    public ValidTruckModelYears()
    {
        AddRow(new DateTime(2022, 1, 1), 2022);
        AddRow(new DateTime(1, 1, 1), 2);
        AddRow(new DateTime(9999, 1, 1), 10000);
        AddRow(new DateTime(1234, 1, 1), 1234);
    }
}