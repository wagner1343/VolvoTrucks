using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.Controllers.Trucks.Responses;

namespace VolvoTrucks.WebApi.SharedResponses;

public record TruckItemResponse(int Id, DateTime CreatedAt, int ManufacturingYear, TruckModelItemResponse Model,
    int ModelYear) : BaseEntityItemResponse(Id, CreatedAt)
{
    public TruckItemResponse(Truck truck) : this(
        truck.Id,
        truck.CreatedAt,
        truck.ManufacturingYear,
        new TruckModelItemResponse(truck.Model),
        truck.ModelYear
    )
    {
    }
};