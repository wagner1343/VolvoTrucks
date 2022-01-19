namespace VolvoTrucks.WebApi.Controllers.Trucks.Requests;

public record UpdateTruckRequest(int ModelId, int ModelYear, string Name);