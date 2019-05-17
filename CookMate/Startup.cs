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

            /**SQL Server*/
            var connectString = @"Server=localhost;User=SA;Database=CookMate;Trusted_Connection=False;Password=Password#1";//ConnectRetryCount=0";
            var fuck = "fuck this shit";
            Console.WriteLine("args1: {0} args2: {1}", fuck, fuck);

            services.AddDbContext<UtilizadorContext>(options => options.UseSqlServer(connectString));

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            }); 

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            Console.WriteLine("args1: {0} args2: {1}", fuck, fuck);
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
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
