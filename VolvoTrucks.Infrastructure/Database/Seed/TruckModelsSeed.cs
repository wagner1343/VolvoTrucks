using Microsoft.EntityFrameworkCore;
using VolvoTrucks.Core.Entities;

namespace VolvoTrucks.Infrastructure.Database.Seed;

public static class TruckModelsSeed
{

    public static void SeedTruckModels(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TruckModel>().HasData(new TruckModel()
        {
            Id = -1,
            CreatedAt = new DateTime(2022, 1, 18),
            Name = "FM"
        });
        modelBuilder.Entity<TruckModel>().HasData(new TruckModel()
        {
            Id = -2,
            CreatedAt = new DateTime(2022, 1, 18),
            Name = "FH"
        });
    }
}