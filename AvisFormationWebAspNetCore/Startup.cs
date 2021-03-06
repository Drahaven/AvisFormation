using AvisFormationWebAspNetCore.Data;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvisFormationWebAspNetCore
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()//(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddDbContext<MonDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient<IFormationRepository, FormationRepository>();
            services.AddTransient<IAvisRepository, AvisRepository>();
            services.AddTransient<IContactRepository, ContactRepository>();

            services.AddResponseCompression(option =>
            {
                option.EnableForHttps = true;
                option.Providers.Add<GzipCompressionProvider>();
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //l'enlever pour pas bug des versions
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseResponseCompression();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    name: "LaissserUnAvis",
                    pattern: "laissez-un-avis/{idFormation}", // lui veut avec monSeo ? la place de l'id
                    defaults: new { controller = "Avis", action = "LaisserUnAvis" }
                    );

                routes.MapControllerRoute(
                    name: "Contact",
                    pattern: "contactez-nous",
                    defaults: new { controller = "Contact", action = "Index" }
                    );

                routes.MapControllerRoute(
                    name: "DetailFormation",
                    pattern: "formations/{nomSeo}",
                    defaults: new { controller = "Formation", action = "DetailsFormation" }
                    );

                routes.MapControllerRoute(
                    name: "ToutesLesFormations",
                    pattern: "toutes-les-formations",
                    defaults:new {controller="Formation", action="ToutesLesFormations"}
                    );

                routes.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                routes.MapRazorPages();
            });
        }
    }
}

