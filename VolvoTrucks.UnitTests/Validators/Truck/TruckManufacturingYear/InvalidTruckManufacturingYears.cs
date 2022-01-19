using System;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.Truck.TruckManufacturingYear;

public class InvalidTruckManufacturingYears : TheoryData
{
    public InvalidTruckManufacturingYears()
    {
        AddRow(new DateTime(2022, 1, 1), 2021);
        AddRow(new DateTime(2022, 1, 1), 2023);
        AddRow(new DateTime(1, 1, 1), 2);
        AddRow(new DateTime(1, 1, 1), int.MaxValue);
        AddRow(new DateTime(9999, 1, 1), 9998);
        AddRow(new DateTime(1234, 1, 1), 5432);
    }
}