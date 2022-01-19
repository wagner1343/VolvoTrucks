using System.Linq;
using Moq;
using VolvoTrucks.Application;
using VolvoTrucks.Core.Entities;
using Xunit;

namespace VolvoTrucks.UnitTests.Application.Services.TruckModelService;

public class TruckModelServiceTests: IClassFixture<ApplicationServicesFixtures>
{
    private readonly ApplicationServicesFixtures _fixture;
    public TruckModelServiceTests(ApplicationServicesFixtures fixture) => _fixture = fixture;
    
    [Fact]
    public void TruckModelService_List_Returns_All_Truck_Models()
    {
        var truckModels = _fixture.BuildSampleTruckModelList();
        
        var trucksContext = new Mock<ITrucksContext>();
        trucksContext.Setup(_ => _.Query<TruckModel>()).Returns(truckModels.AsQueryable());

        var truckService =
            new VolvoTrucks.Application.Services.TruckModelService(trucksContext.Object);
        
        var truckModelsResult = truckService.List();

        foreach (var t in truckModels)
        {
            Assert.Contains(t, truckModelsResult);
        }

        foreach (var t in truckModelsResult)
        {
            Assert.Contains(t, truckModels);
        }
    }
}