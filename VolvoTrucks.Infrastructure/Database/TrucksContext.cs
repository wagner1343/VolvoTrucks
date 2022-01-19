using Microsoft.EntityFrameworkCore;
using VolvoTrucks.Application;
using VolvoTrucks.Application.Exceptions;
using VolvoTrucks.Core.Entities;
using VolvoTrucks.Infrastructure.Database.Seed;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace VolvoTrucks.Infrastructure.Database;

public class TrucksContext : DbContext, ITrucksContext 
{
    public System.Data.Entity.DbSet<Truck> Trucks { get; set; }
    public System.Data.Entity.DbSet<TruckModel> TruckModels { get; set; }
    
    
    public TrucksContext()
    {
    }

    public TrucksContext(DbContextOptions<TrucksContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.SeedTruckModels();
        modelBuilder.Entity<Truck>().Navigation(t => t.Model).AutoInclude();
    }

    public TEntity FindOrFail<TEntity>(params object?[] keyValues)
        where TEntity : class
    {
        return base.Find<TEntity>(keyValues) ?? throw new EntityNotFoundException(keyValues, typeof(TEntity));
    }
    
    public void Save()
    {
        base.SaveChanges();
    }

    public TEntity AddEntity<TEntity>(TEntity entity) where TEntity : BaseEntity
    {
        entity.CreatedAt = DateTime.Now;
        return base.Add(entity).Entity;
    }

    public void RemoveEntity(object entity)
    {
        base.Remove(entity);
    }

    public IQueryable<TEntity> Query<TEntity>() where TEntity : BaseEntity
    {
        return base.Set<TEntity>();
    }
}