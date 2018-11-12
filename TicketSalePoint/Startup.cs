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
using TicketSalePoint.Data;
using TicketSalePoint.Models;
using TicketSalePoint.Services;
using TicketSalePoint.Models.dbcontexts;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
namespace TicketSalePoint
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
            services.AddLocalization();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<TicketContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
            //services.AddTransient<InitEmitent>();//создает каждый раз новые обьекты класса,при запросе обьекта , не в самом запросе
            services.AddScoped<InitEmitent>();//Здесь при каждом новом запросе создается один обьект и остается прежним для этого же запроса.

            services.Configure<RequestLocalizationOptions>(
                 options =>
                 {
                     var supportedCultures = new List<CultureInfo>
                     {
                        new CultureInfo("en-US"),
                        new CultureInfo("ru-Ru")
                     };

                     options.DefaultRequestCulture = new RequestCulture("ru-Ru", "ru-Ru");
                     options.SupportedCultures = supportedCultures;
                     options.SupportedUICultures = supportedCultures;
                     options.RequestCultureProviders = new List<IRequestCultureProvider>
                     {
                        new QueryStringRequestCultureProvider()
                     };
                 });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseRequestLocalization(BuildLocalizationOpts());
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

            RequestLocalizationOptions BuildLocalizationOpts()
            {
                var cultures = new List<CultureInfo>
                 {
                    new CultureInfo("ru"),
                    new CultureInfo("en")
                 };
                return new RequestLocalizationOptions
                {
                    SupportedCultures = cultures,
                    SupportedUICultures = cultures,
                    RequestCultureProviders = new List<IRequestCultureProvider>
                    {
                       new CookieRequestCultureProvider { CookieName = "lang" },
                       new AcceptLanguageHeaderRequestCultureProvider(),
                    }
                };
            }

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
