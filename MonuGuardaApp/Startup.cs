using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using MonuGuardaApp.Data;
using MonuGuardaApp.Models;
using Microsoft.AspNetCore.Identity;

namespace MonuGuardaApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<MonuGuardaAppContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("MonuGuardaAppContext")));
            services.AddIdentity<IdentityUser, IdentityRole>(
                options =>
                {
                    //Sign in
                    options.SignIn.RequireConfirmedAccount = false;

                    //Password
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequiredLength = 5;
                    options.Password.RequiredUniqueChars = 3;
                    options.Password.RequireUppercase = true;

                    // Lockout
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                    options.Lockout.MaxFailedAccessAttempts = 5;

                }).AddEntityFrameworkStores<MonuGuardaAppContext>()
                .AddDefaultUI();

            services.AddDbContext<MonuGuardaAppContext>(options =>
                   options.UseSqlServer(
                       Configuration.GetConnectionString("MonuGuardaConnection")));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            SeedData.SeedRolesAsync(roleManager).Wait();
            SeedData.SeedDefaultAdminAsync(userManager).Wait(); //Criar o admin

            if (env.IsDevelopment())
            {
                SeedData.SeedDevUserAsync(userManager).Wait();
            }
        }
    }
}
