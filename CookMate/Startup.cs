using System;
using System.Linq;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CookMate.Models;
using CookMate.shared;
using CookMate.Controllers;

namespace CookMate {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration {
        	get;
        }

        public void ConfigureServices(IServiceCollection services) {

            //var connectString = @"Server=TIAGO;User=TIAGO\TIagoasfasf;Database=CookMate;Trusted_Connection=TRUE;";
            var connectString = @"Server=localhost;User=SA;Database=CookMate;Trusted_Connection=False;Password=Password#1;";
            //var connectString = @"Server=MIGUEL-WINDOWS1;User=MIGUEL-WINDOWS1\micka;Database=CookMate;Trusted_Connection=True;";
            //var connectString = @"Server=DESKTOP-9NAOK81\LI;User=sa;Database=CookMate;Trusted_Connection=False;Password=D@rkPow3r";
            services.AddDbContext<UtilizadorContext>(options => options.UseSqlServer(connectString));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
