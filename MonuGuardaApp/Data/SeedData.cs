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
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Linhares da Beira",
                    Freguesia = "Linhares da Beira",
                    Concelho = "Celorico da Beira",
                    Morada = "6360-080",
                    Coordenadas = "40° 32.483' N 7° 27.669' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Trancoso",
                    Freguesia = "Santa Maria",
                    Concelho = "Trancoso",
                    Morada = "Trancoso",
                    Coordenadas = "40° 46.746' N 7° 20.855' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Praça-forte de Almeida",
                    Freguesia = "Almeida",
                    Concelho = "Almeida",
                    Morada = "Almeida, Guarda",
                    Coordenadas = "40° 43.551' N 6° 54.350' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Folgosinho",
                    Freguesia = "Folgosinho",
                    Concelho = "Gouveia",
                    Morada = "R. da Fonte dos Limos Verdes 13, 6290-081 Folgosinho",
                    Coordenadas = "40°30'39.77 N 7°30'43.40 W"
                },
                new PontosdeInteresse
                {
                    Nome = "Ponte do Escalhão",
                    Freguesia = "Escalhão",
                    Concelho = "Figueira de Castelo Rodrigo",
                    Morada = "W3F6+R4 Figueira de Castelo Rodrigo",
                    Coordenadas = "40°55'28.3″N 6°56'22.7″W"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Sortelha",
                    Freguesia = "Sortelha",
                    Concelho = "Sabugal",
                    Morada = "R. do Encontro 2, 6320-530 Sortelha",
                    Coordenadas = "40° 19.744' N 7° 13.014' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Numão",
                    Freguesia = "Vila Nova de Foz Côa",
                    Concelho = "Vila Nova de Foz Côa",
                    Morada = "R. Direita, 5155-619",
                    Coordenadas = "41° 06.033' N 7° 17.464' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Pinhel",
                    Freguesia = "Pinhel",
                    Concelho = "Pinhel",
                    Morada = "R. do Castelo 4, 6400-340 Pinhel",
                    Coordenadas = "40° 46′ 37″ N, 7° 03′ 43″ O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Castelo Rodrigo",
                    Freguesia = "Castelo Rodrigo",
                    Concelho = "Figueira de Castelo Rodrigo",
                    Morada = "Largo do Pelourinho 1, 6440-031",
                    Coordenadas = "40° 52′ 39″ N, 6° 57′ 51″ O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Longroiva",
                    Freguesia = "Longroiva",
                    Concelho = "Meda",
                    Morada = "Longroiva, 6430 197",
                    Coordenadas = "40° 57.829' N 7° 12.514' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Castelo de Marialva",
                    Freguesia = "Meda",
                    Concelho = "Meda",
                    Morada = "6430-081",
                    Coordenadas = "40° 54.815' N 7° 13.919' O"
                },
                new PontosdeInteresse
                {
                    Nome = "Convento de Santa Maria de Aguiar",
                    Freguesia = "Castelo Rodrigo",
                    Concelho = "Figueira de Castelo Rodrigo",
                    Morada = "Castelo Rodrigo, Portugal",
                    Coordenadas = "40° 52′ 52″ N, 6° 56′ 00″ O"
                }
            );

            dbContext.SaveChanges();
        }
    }
}
