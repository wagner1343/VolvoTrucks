namespace VolvoTrucks.Core.Entities;

public class Truck : BaseEntity
{
    public int ManufacturingYear { get; set; }
    public TruckModel Model { get; set; }
    public int ModelYear { get; set; }
}