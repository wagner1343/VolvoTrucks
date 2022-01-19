using Microsoft.AspNetCore.Mvc;
using VolvoTrucks.Application.Services;
using VolvoTrucks.Core.Entities;
using VolvoTrucks.WebApi.Controllers.Trucks.Requests;
using VolvoTrucks.WebApi.Controllers.Trucks.Responses;

namespace VolvoTrucks.WebApi.Controllers.Trucks;

public class TrucksController : BaseController
{
    private readonly TruckService _truckService;

    public TrucksController(TruckService truckService)
    {
        _truckService = truckService;
    }

    [HttpGet]
    public IActionResult List()
    {
        var trucks = _truckService.List();
        return Ok(new ListTrucksResponse(trucks));
    }

    private string BuildCreatedUrl(Truck truck)
    {
        return $"trucks/{truck.Id}";
    }

    [HttpPost]
    public IActionResult Create(CreateTruckRequest request)
    {
        var truck = _truckService.Add(request.ModelId, request.ModelYear, request.Name);
        return Created(BuildCreatedUrl(truck), new CreateTruckResponse(truck));
    }

    [Route("{id}")]
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _truckService.Delete(id);
        return NoContent();
    }


    [Route("{id}")]
    [HttpPut]
    public IActionResult Put(int id, UpdateTruckRequest request)
    {
        var truck = _truckService.Find(id);
        var truckExists = truck != null;
        if (truckExists)
        {
            truck = _truckService.Update(truck!.Id, request.ModelId, request.ModelYear, request.Name);
        }
        else
        {
            truck = _truckService.Add(request.ModelId, request.ModelYear, request.Name);
        }

        return truckExists ? NoContent() : Created(BuildCreatedUrl(truck), new CreateTruckResponse(truck));
    }
}