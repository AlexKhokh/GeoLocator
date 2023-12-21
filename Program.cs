using Data.Entities;

namespace GeoLocator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddHostedService(sp =>
                        new DbContextBuilder(builder.Configuration.GetValue<string>("source")))
                .AddSingleton(sp =>
                        sp.GetServices<IHostedService>().OfType<DbContextBuilder>().First());

            //builder.Services.AddScoped<IGeoLocator, GeoLocator>();
            builder.Services.AddControllers();

            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}