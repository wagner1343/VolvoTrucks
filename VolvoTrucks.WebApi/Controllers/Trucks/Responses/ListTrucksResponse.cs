using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.SharedResponses;

namespace VolvoTrucks.WebApi.Controllers.Trucks.Responses;

public record ListTrucksResponse(List<TruckItemResponse> Data)
{
    public ListTrucksResponse(List<Truck> trucks) : this(trucks.Select(t => new TruckItemResponse(t)).ToList())
    {
    }
}