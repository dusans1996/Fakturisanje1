using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fakturisanje.Data;
using Fakturisanje.Models;
using Fakturisanje.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace Fakturisanje
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
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<FakturisanjeContext>(opcije =>
               opcije.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(opcije=> {
                opcije.Password.RequireDigit = false;
                opcije.Password.RequiredLength = 3;
                opcije.Password.RequiredUniqueChars = 1;
                opcije.Password.RequireLowercase = false;
                opcije.Password.RequireUppercase = false;
                opcije.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddAuthorization(opcije => {
                opcije.AddPolicy("SamoAdmin", policy => policy.RequireUserName("admin@gmail.com"));
            });



            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            CultureInfo ci = new CultureInfo("sr-Latn-RS");
            List<CultureInfo> podrzane = new List<CultureInfo> { ci };
            ci.DateTimeFormat.ShortDatePattern = "dd.MM.yyyy";
            ci.NumberFormat.NumberDecimalSeparator = ".";

            RequestLocalizationOptions opcije = new RequestLocalizationOptions
            {
                SupportedCultures = podrzane,
                DefaultRequestCulture = new RequestCulture(ci)
            };
            app.UseRequestLocalization(opcije);
            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
