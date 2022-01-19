using Microsoft.EntityFrameworkCore;

namespace VolvoTrucks.WebApi.Extensions
{
    public static class UseUpdateDatabaseExtension
    {
        public static void UseUpdateDatabase<TContext>(this IApplicationBuilder app) where TContext : DbContext
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetRequiredService<TContext>();
            context.Database.Migrate();
        }
    }
}