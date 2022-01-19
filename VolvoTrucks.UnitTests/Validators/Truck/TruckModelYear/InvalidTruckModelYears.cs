using System;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.Truck.TruckModelYear;

public class InvalidTruckModelYears : TheoryData
{
    public InvalidTruckModelYears()
    {
        AddRow(new DateTime(2022, 1, 1), 2021);
        AddRow(new DateTime(2022, 1, 1), 2024);
        AddRow(new DateTime(1, 1, 1), 3);
        AddRow(new DateTime(1, 1, 1), 9999);
        AddRow(new DateTime(9999, 1, 1), 9998);
        AddRow(new DateTime(1234, 1, 1), 5432);
    }
}