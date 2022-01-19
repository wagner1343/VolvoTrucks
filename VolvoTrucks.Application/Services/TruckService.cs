using VolvoTrucks.Core.Entities;
using VolvoTrucks.Core.Validators;

namespace VolvoTrucks.Application.Services;

public class TruckService
{
    private readonly ITrucksContext _truckContext;
    private readonly IValidator<Truck> _truckValidator;
    
    public TruckService(ITrucksContext truckContext, IValidator<Truck> truckValidator)
    {
        _truckContext = truckContext;
        _truckValidator = truckValidator;
    }

    public Truck? Find(int truckId)
    {
        return _truckContext.Find<Truck>(truckId);
    }

    public Truck Add(int modelId, int modelYear)
    {
        var model = _truckContext.FindOrFail<TruckModel>(modelId);
        var truck = _truckContext.AddEntity(new Truck()
        {
            Model = model,
            ManufacturingYear = DateTime.Now.Year,
            ModelYear = modelYear
        });
        _truckValidator.Validate(truck).EnsureIsValid();
        _truckContext.Save();
        return truck;
    }
    
    public Truck Update(int truckId, int modelId, int modelYear)
    {
        var model = _truckContext.FindOrFail<TruckModel>(modelId);
        var truck = _truckContext.FindOrFail<Truck>(truckId);
        
        truck.Model = model;
        truck.ModelYear = modelYear;
        
        _truckValidator.Validate(truck).EnsureIsValid();
        _truckContext.Save();
        return truck;
    }

    public void Delete(int truckId)
    {
        var truck = _truckContext.FindOrFail<Truck>(truckId);
        _truckContext.RemoveEntity(truck);
        _truckContext.Save();
    }

    public List<Truck> List()
    {
        return _truckContext.Query<Truck>().ToList();
    }
    
}