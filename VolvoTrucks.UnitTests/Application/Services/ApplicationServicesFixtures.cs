using System;
using System.Collections.Generic;
using VolvoTrucks.Core.Entities;

namespace VolvoTrucks.UnitTests.Application.Services;

public class ApplicationServicesFixtures
{
    
    public List<TruckModel> BuildSampleTruckModelList()
    {
        return new List<TruckModel>
        {
            new()
            {
                Id = 21,
                Name = "FM",
                CreatedAt = new DateTime(2022, 1, 19),
            },
            new()
            {
                Id = 22,
                Name = "FM",
                CreatedAt = new DateTime(2021, 1, 19),
            },
            new()
            {
                Id = 23,
                Name = "FH",
                CreatedAt = new DateTime(2021, 1, 19),
            },
        };
    }
    
    public List<Truck> BuildSampleTruckList()
    {
        return new List<Truck>
        {
            new()
            {
                Id = 1,
                Model = new TruckModel
                {
                    Id = 21,
                    Name = "FM",
                    CreatedAt = new DateTime(2022, 1, 19),
                },
                CreatedAt = new DateTime(2022, 1, 19),
                ManufacturingYear = 2022,
                ModelYear = 2023
            },
            new()
            {
                Id = 2,
                Model = new TruckModel
                {
                    Id = 22,
                    Name = "FM",
                    CreatedAt = new DateTime(2021, 1, 19),
                },
                CreatedAt = new DateTime(2021, 1, 19),
                ManufacturingYear = 2021,
                ModelYear = 2021
            },
            new()
            {
                Id = 3,
                Model = new TruckModel
                {
                    Id = 23,
                    Name = "FH",
                    CreatedAt = new DateTime(2021, 1, 19),
                },
                CreatedAt = new DateTime(2021, 1, 19),
                ManufacturingYear = 2021,
                ModelYear = 2021
            },
        };
    }

}