using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.SharedResponses;

namespace VolvoTrucks.WebApi.Controllers.Trucks.Responses;

public record GetTruckResponse(TruckItemResponse Data)
{
    public GetTruckResponse(Truck truck) : this(
        new TruckItemResponse(truck))
    {
    }
}