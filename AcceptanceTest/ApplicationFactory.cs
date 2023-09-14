using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AcceptanceTest;

internal sealed class ApplicationFactory : WebApplicationFactory<Program>
{
    internal static ApplicationFactory NewApp() => new();
    private ApplicationFactory() { }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices((WebHostBuilderContext builder, IServiceCollection services) =>
        {
            Remove<DbContextOptions<AppDbContext>>(services);

            services.AddDbContext<AppDbContext>(
                (serviceProvider, dbContextOptionsBuilder)
                    => dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "ClinicManagetment_Db_Memory"));
        });
    }

    private IServiceCollection Remove<TService>(IServiceCollection services)
    {
        var serviceDescriptor = services.FirstOrDefault(sd => sd.ServiceType == typeof(TService));

        if (serviceDescriptor != null)
            services.Remove(serviceDescriptor);

        return services;
    }
}
