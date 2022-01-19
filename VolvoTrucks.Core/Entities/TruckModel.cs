namespace VolvoTrucks.Core.Entities;

public class TruckModel : BaseEntity
{
    public string Name { get; set; }
    public List<Truck> Trucks { get; set; }
}