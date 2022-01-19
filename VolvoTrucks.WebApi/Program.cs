namespace VolvoTrucks.WebApi
{
    public static class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(builder => { builder.UseStartup<Startup>(); });

        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
    }
}