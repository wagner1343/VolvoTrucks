using System;
using Xunit;

namespace VolvoTrucks.UnitTests.Validators.TruckModel;

public class InvalidTruckModelNames : TheoryData<string>
{
    public InvalidTruckModelNames()
    {
        Add("Teste");
        Add("fm");
        Add("fh");
        Add("___");
        Add("");
    }
}