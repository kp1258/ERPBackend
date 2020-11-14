using System;
using ERPBackend;
using ERPBackend.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq;

namespace ERPBackendTests
{
    public class ApiWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                                            .AddEntityFrameworkInMemoryDatabase()
                                            .BuildServiceProvider();

                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<ERPContext>));

                services.Remove(descriptor);
                services.AddDbContext<ERPContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryERPDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var erpDb = scopedServices.GetRequiredService<ERPContext>();

                    erpDb.Database.EnsureCreated();

                    try
                    {
                        SeedData.InsertTestData(erpDb);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
        }
    }
}