using DemoApp.Core;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.ADMINISTRATORS));
            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstants.Roles.CUSTOMERS));

            string defaultUserName = "demouser@microsoft.com";
            string defaultPassword = AuthorizationConstants.DEFAULT_PASSWORD;

            var defaultUser = new ApplicationUser { UserName = defaultUserName, Email = defaultUserName };
            await userManager.CreateAsync(defaultUser, AuthorizationConstants.DEFAULT_PASSWORD);
            defaultUser = await userManager.FindByNameAsync(defaultUserName);
            await userManager.AddToRoleAsync(defaultUser, AuthorizationConstants.Roles.CUSTOMERS);

            string adminUserName = "admin@test.com";
            var adminUser = new ApplicationUser { UserName = adminUserName, Email = adminUserName };
            await userManager.CreateAsync(adminUser, defaultPassword);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, AuthorizationConstants.Roles.ADMINISTRATORS);
        }
    }
}
