using Microsoft.EntityFrameworkCore;
using VolvoTrucks.Application;
using VolvoTrucks.Application.Services;
using VolvoTrucks.Core.Entities;
using VolvoTrucks.Core.Validators;
using VolvoTrucks.Infrastructure.Database;
using VolvoTrucks.WebApi.Extensions;

namespace VolvoTrucks.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ITrucksContext, TrucksContext>(options =>
            {
                options.UseSqlite(_configuration.GetConnectionString("DbConnection"),
                    sqliteOptions => sqliteOptions.MigrationsAssembly("VolvoTrucks.Infrastructure"));
            });
            services.AddScoped<IValidator<Truck>, TruckValidator>();
            services.AddScoped<TruckService>();
            services.AddScoped<TruckModelService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseUpdateDatabase<TrucksContext>();
        }
    }
}