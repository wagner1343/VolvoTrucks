using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.Controllers.Trucks.Responses;

namespace VolvoTrucks.WebApi.SharedResponses;

public record TruckModelItemResponse(int Id, DateTime CreatedAt, string Name) : BaseEntityItemResponse(Id, CreatedAt)
{
    public TruckModelItemResponse(TruckModel truckModel) : this(
        truckModel.Id,
        truckModel.CreatedAt,
        truckModel.Name)
    {
    }
}