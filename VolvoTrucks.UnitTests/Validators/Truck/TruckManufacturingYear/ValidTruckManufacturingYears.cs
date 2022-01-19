using System;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.Truck.TruckManufacturingYear;

public class ValidTruckManufacturingYears : TheoryData
{
    public ValidTruckManufacturingYears()
    {
        AddRow(new DateTime(2022, 1, 1), 2022);
        AddRow(new DateTime(1, 1, 1), 1);
        AddRow(new DateTime(9999, 1, 1), 9999);
        AddRow(new DateTime(1234, 1, 1), 1234);
    }
}