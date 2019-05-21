using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pbshop_web.Connection;
using pbshop_web.Respositories;

namespace pbshop_web
{
    public class Startup
    {
        public IConfigurationRoot Configuration {  
            get;  
            set;  
        }  
        public static string ConnectionString {  
            get;  
            private set;  
        }  
        public Startup(IHostingEnvironment env) {  
            Configuration = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appSettings.json").Build();  
        }
        // public Startup(IConfiguration configuration)
        // {
        //     Configuration = configuration;
        // }

        // public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // var connectionStr = Configuration.GetValue<string>("DefaultConnection");
            services.AddTransient<IClientsRepository, ClientsRepository>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            // services.AddTransient<DBConnection>(_ => new DBConnection(Configuration["ConnectionStrings:DefaultConnection"]));
            ConnectionString = Configuration["ConnectionStrings:DefaultConnectionProduction"];
            //ConnectionString = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                // routes.MapRoute(
                //     name: "default_route",
                //     template: "{controller}/{action}/{id?}",
                //     defaults: new { controller = "Clients", action = "Index" }
                // );
            });
            //app.UseMvc();
        }
    }
}
