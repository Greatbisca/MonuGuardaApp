using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Data
{
    public class SeedData
    {
        //Criação do Administrador e Roles
        private const string DEFAULT_ADMIN_USER = "admin@ipg.pt";
        private const string DEFAULT_ADMIN_PASSWORD = "Secret123$";
        private const string ROLE_ADMINISTRATOR = "Admin";
        private const string ROLE_GUIDE = "Guia";
        private const string ROLE_TURIST = "Turista";

        internal static async Task SeedDefaultAdminAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, DEFAULT_ADMIN_PASSWORD, DEFAULT_ADMIN_USER, ROLE_ADMINISTRATOR);
        }

        private static async Task EnsureUserIsCreated(UserManager<IdentityUser> userManager, string password, string username, string role)
        {
            IdentityUser user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        internal static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            await EnsureRoleIsCreated(roleManager, ROLE_ADMINISTRATOR);
            await EnsureRoleIsCreated(roleManager, ROLE_GUIDE);
            await EnsureRoleIsCreated(roleManager, ROLE_TURIST);
        }

        private static async Task EnsureRoleIsCreated(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))  //verificar se foi criado o role se nao exitir é criado
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        internal static async Task SeedDevUserAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, "guia@ipg.pt", "teste123$", ROLE_GUIDE);
            await EnsureUserIsCreated(userManager, "cliente@ipg.pt", "teste123$", ROLE_TURIST);
        }
    }
}
