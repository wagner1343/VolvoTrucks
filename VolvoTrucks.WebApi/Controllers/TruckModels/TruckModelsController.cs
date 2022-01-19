using Microsoft.AspNetCore.Mvc;
using VolvoTrucks.Application.Services;
using VolvoTrucks.WebApi.Controllers.TruckModels.Responses;

namespace VolvoTrucks.WebApi.Controllers.TruckModels;

public class TruckModelsController : BaseController
{
    private readonly TruckModelService _truckModelService;

    public TruckModelsController(TruckModelService truckModelService)
    {
        _truckModelService = truckModelService;
    }

    [HttpGet]
    public IActionResult List()
    {
        var truckModels = _truckModelService.List();
        return Ok(new ListTruckModelsResponse(truckModels));
    }
}