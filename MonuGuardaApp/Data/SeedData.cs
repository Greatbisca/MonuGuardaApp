using Microsoft.AspNetCore.Identity;
using MonuGuardaApp.Models;
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


        internal static async Task SeedDevUsersAsync(UserManager<IdentityUser> userManager)
        {
            await EnsureUserIsCreated(userManager, "guia@ipg.pt", "teste123$", ROLE_GUIDE);
            await EnsureUserIsCreated(userManager, "cliente@ipg.pt", "teste123$", ROLE_TURIST);
            await EnsureUserIsCreated(userManager, "cliente@ipg.pt", "teste123$", ROLE_ADMINISTRATOR);
        }

        internal static void Populate(MonuGuardaAppContext dbContext)
        {
            PopulateProducts(dbContext);
        }
        private static void PopulateProducts(MonuGuardaAppContext dbContext)
        {
            if (dbContext.PontosdeInteresse.Any())
            {
                return;
            }

            dbContext.PontosdeInteresse.AddRange(
                new PontosdeInteresse
                {
                    Nome = "Castelo do Sabugal",
                    Freguesia = "Sabugal",
                    Concelho = "Sabugal",
                    Morada = "6320-409 Sabugal",
                    Coordenadas = "40° 21′ 05″ N, 7° 05′ 39″ O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo da Guarda",
                    Freguesia = "Guarda",
                    Concelho = "Guarda",
                    Morada = "6300-758 Guarda",
                    Coordenadas = "40° 32.246' N 7° 16.296' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Sé-Catedral da Guarda",
                    Freguesia = "Guarda",
                    Concelho = "Guarda",
                    Morada = "Praça Luís de Camões, 6300-714 Guarda",
                    Coordenadas = "40° 32′ 18″ N, 7° 16′ 09″ O"
                }
            );

            dbContext.SaveChanges();
        }
    }
}
