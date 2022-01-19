using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.SharedResponses;

namespace VolvoTrucks.WebApi.Controllers.TruckModels.Responses;

public record ListTruckModelsResponse(List<TruckModelItemResponse> Data)
{
    public ListTruckModelsResponse(List<TruckModel> truckModels) : this(truckModels
        .Select(tm => new TruckModelItemResponse(tm)).ToList())
    {
    }
}