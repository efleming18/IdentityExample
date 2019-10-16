using System;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.Infrastructure.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DemoApp.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = CreateWebHostBuilder(args);

            string env = "Development";
            if (args.Any())
            {
                env = args[0];
            }
            Console.WriteLine($"Starting using environment: {env}");
            builder.UseEnvironment(env);
            var host = builder.Build();

            if (env == "Development")
            {
                await SeedDatabase(host);
            }

            host.Run();
        }

        private static async Task SeedDatabase(IWebHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogInformation("Seeding database...");
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    if (userManager.Users.Any() || roleManager.Roles.Any())
                    {
                        logger.LogDebug("User/Role data already exists.");
                    }
                    else
                    {
                        await ApplicationDbContextSeed.SeedAsync(userManager, roleManager);
                        logger.LogDebug("Populated AppIdentityDbContext test data.");
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
