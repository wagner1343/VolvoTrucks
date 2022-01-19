using VolvoTrucks.Core.Entities;

namespace VolvoTrucks.Application.Services;

public class TruckModelService
{
    private readonly ITrucksContext _truckContext;

    public TruckModelService(ITrucksContext truckContext)
    {
        _truckContext = truckContext;
    }

    public List<TruckModel> List()
    {
        return _truckContext.Query<TruckModel>().ToList();
    }
}