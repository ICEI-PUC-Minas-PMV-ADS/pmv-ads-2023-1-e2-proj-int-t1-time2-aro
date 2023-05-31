using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using permita_se.Data.Static;
using permita_se.Model;
using System;
using System.Threading.Tasks;

namespace permita_se.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PermitaSeDbContext>();

                context.Database.EnsureCreated();
            }
        }
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            //roles
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await roleManager.RoleExistsAsync(UserRoles.User))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            //users
            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Usuario>>();

            string adminUserEmail = "admin@permitase.com";
            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new Usuario()
                {
                    Nome = "Admin",
                    Sobrenome = "User",
                    DataNascimento = DateTime.Now,
                    Telefone = "999999999",
                    UserName = "admin-user",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "Permitase@123");
                await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
            }


            string appUserEmail = "user@permitase.com";
            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new Usuario()
                {
                    Nome = "Application",
                    Sobrenome = "User",
                    DataNascimento = DateTime.Now,
                    Telefone = "999999999",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAppUser, "Permitase@123");
                await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
            }
        }
    }
}
