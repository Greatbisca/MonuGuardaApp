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
        }
        internal static void Populate(MonuGuardaAppContext dbContext)
        {
            PopulateProducts(dbContext);
        }
        private static void PopulateProducts(MonuGuardaAppContext dbContext)
        {
            if (dbContext.Concelho.Any())
            {
                return;
            }

            dbContext.Concelho.AddRange(
                new Concelho
                {
                    Nome = "Sabugal",
                },
                new Concelho
                {
                    Nome = "Guarda",
                },
                new Concelho
                {
                    Nome = "Celorico da Beira",
                },
                new Concelho
                {
                    Nome = "Trancoso",
                },
                new Concelho
                {
                    Nome = "Almeida",
                },
                new Concelho
                {
                    Nome = "Gouveia",
                },
                new Concelho
                {
                    Nome = "Figueira de Castelo Rodrigo",
                },
                new Concelho
                {
                    Nome = "Vila Nova de Foz Côa",
                },
                new Concelho
                {
                    Nome = "Pinhel",
                },
                new Concelho
                {
                    Nome = "Aguiar da Beira",
                },
                new Concelho
                {
                    Nome = "Fornos de Algodres",
                },
                new Concelho
                {
                    Nome = "Manteigas",
                },
                new Concelho
                {
                    Nome = "Seia",
                },
                new Concelho
                {
                    Nome = "Mêda",
                });

            if (dbContext.Freguesia.Any())
            {
                return;
            }

            dbContext.Freguesia.AddRange(
                new Freguesia
                {
                    Nome = "Sabugal",
                },
                new Freguesia
                {
                    Nome = "Guarda",
                },
                new Freguesia
                {
                    Nome = "Linhares da Beira",
                },
                new Freguesia
                {
                    Nome = "Santa Maria",
                },
                new Freguesia
                {
                    Nome = "Almeida",
                },
                new Freguesia
                {
                    Nome = "Folgosinho",
                },
                new Freguesia
                {
                    Nome = "Escalhão",
                },
                new Freguesia
                {
                    Nome = "Sortelha",
                },
                new Freguesia
                {
                    Nome = "Vila Nova de Foz Côa",
                },
                new Freguesia
                {
                    Nome = "Pinhel",
                },
                new Freguesia
                {
                    Nome = "Castelo Rodrigo",
                },
                new Freguesia
                {
                    Nome = "Longroiva",
                },
                new Freguesia
                {
                    Nome = "Mêda",
                }
            );

            if (dbContext.Guia.Any())
                {
                    return;
                }

                dbContext.Guia.AddRange(
                   new Guia
                   {
                       Nome = "Rodrigo Ribeiro",
                       Telemovel = 921456987,
                       Email = "rodrigo@sapo.pt"
                   },
                   new Guia
                   {
                       Nome = "Mateus Alves",
                       Telemovel = 914562587,
                       Email = "mateus@ipg.pt"
                   },
                   new Guia
                   {
                       Nome = "Sofia Silva",
                       Telemovel = 931456852,
                       Email = "sofisilva@hotmail.com"
                   },
                   new Guia
                   {
                       Nome = "Rita Neto",
                       Telemovel = 964785123,
                       Email = "rita@hotmail.com"
                   },
                   new Guia
                   {
                       Nome = "Pedro Henrique",
                       Telemovel = 914753695,
                       Email = "enrique@hotmail.com"
                   },
                   new Guia
                   {
                       Nome = "Marta Abrunhosa",
                       Telemovel = 925478951,
                       Email = "martaa@gmail.pt"
                   }
               );
            dbContext.SaveChanges();
        }

        internal static void SeedDevData(MonuGuardaAppContext db)
        {
            
        }
    }
}
