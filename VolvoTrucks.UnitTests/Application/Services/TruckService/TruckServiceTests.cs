using System.Collections.Generic;
using System.Linq;
using Moq;
using VolvoTrucks.Application;
using VolvoTrucks.Core.Entities;
using Xunit;

namespace VolvoTrucks.UnitTests.Application.Services.TruckService;

public class TruckServiceTests : IClassFixture<ApplicationServicesFixtures>
{
    private readonly ApplicationServicesFixtures _fixture;
    public TruckServiceTests(ApplicationServicesFixtures fixture) => _fixture = fixture;

    [Fact]
    public void TruckService_List_Returns_All_Trucks()
    {
        var trucks = _fixture.BuildSampleTruckList();

        var trucksContext = new Mock<ITrucksContext>();
        trucksContext.Setup(_ => _.Query<Truck>()).Returns(trucks.AsQueryable());

        var truckService =
            new VolvoTrucks.Application.Services.TruckService(trucksContext.Object, new AlwaysValidValidator<Truck>());
        var trucksResult = truckService.List();

        foreach (var t in trucks)
        {
            Assert.Contains(t, trucksResult);
        }

        foreach (var t in trucksResult)
        {
            Assert.Contains(t, trucks);
        }
    }

    [Fact]
    public void TruckService_Find_Return_Expected_Truck()
    {
        var truckToFind = new Truck()
        {
            Id = 2,
        };
        var trucksContext = new Mock<ITrucksContext>();
        trucksContext.Setup(_ => _.Find<Truck>(2)).Returns(truckToFind);

        var truckService =
            new VolvoTrucks.Application.Services.TruckService(trucksContext.Object, new AlwaysValidValidator<Truck>());
        var truckFound = truckService.Find(2);

        Assert.Same(truckToFind, truckFound);
    }

    [Fact]
    public void TruckService_Add_Behaves_As_Expected()
    {
        var trucksContext = new Mock<ITrucksContext>();
        var truckModelId = 1;
        var truckModelYear = 2022;

        var truckModelToReturn = new TruckModel()
        {
            Id = 1,
            Name = "FM"
        };

        var truckToReturn = new Truck()
        {
            Id = 1,
            Model = truckModelToReturn,
            ModelYear = 2022
        };

        trucksContext.Setup(_ => _.FindOrFail<TruckModel>(
            It.IsAny<TruckModel>()
        )).Returns(truckModelToReturn);
        trucksContext.Setup(_ => _.AddEntity(
            It.IsAny<Truck>()
        )).Returns(truckToReturn);

        var truckService =
            new VolvoTrucks.Application.Services.TruckService(trucksContext.Object, new AlwaysValidValidator<Truck>());
        var returnedTruck = truckService.Add(truckModelId, truckModelYear);
        Assert.Same(truckToReturn, returnedTruck);
    }


    [Fact]
    public void TruckService_Delete_Behaves_As_Expected()
    {
        var truckToDelete = new Truck();
        var trucksContext = new Mock<ITrucksContext>();
        trucksContext.Setup(_ => _.FindOrFail<Truck>(
            1
        )).Returns(truckToDelete);
        trucksContext.Setup(_ => _.RemoveEntity(
            It.IsAny<Truck>()
        ));

        var truckService =
            new VolvoTrucks.Application.Services.TruckService(trucksContext.Object, new AlwaysValidValidator<Truck>());
        truckService.Delete(1);
        trucksContext.Verify(context => context.RemoveEntity(truckToDelete), Times.Once);
    }

    [Fact]
    public void TruckService_Update_Behaves_As_Expected()
    {
        var trucksContext = new Mock<ITrucksContext>();
        var truckToReturn = new Truck()
        {
            
        };
        var modelToReturn = new TruckModel()
        {
            
        };
        var expectedModelYear = 2022;
        trucksContext.Setup(_ => _.FindOrFail<Truck>(1)).Returns(truckToReturn);
        trucksContext.Setup(_ => _.FindOrFail<TruckModel>(2
        )).Returns(modelToReturn);

        var truckService =
            new VolvoTrucks.Application.Services.TruckService(trucksContext.Object, new AlwaysValidValidator<Truck>());
        truckService.Update(1, 2, expectedModelYear);
        
        Assert.True(truckToReturn.Model == modelToReturn);
        Assert.True(truckToReturn.ModelYear == expectedModelYear);
    }
}