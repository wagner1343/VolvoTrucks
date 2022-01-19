using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.SharedResponses;

namespace VolvoTrucks.WebApi.Controllers.Trucks.Responses;

public record CreateTruckResponse(TruckItemResponse Data)
{
    public CreateTruckResponse(Truck truck) : this(new TruckItemResponse(truck))
    {
    }
};