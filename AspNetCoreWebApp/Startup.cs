using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWebApp.DbModels.CalculatorDbModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            Configuration =  new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            
            .AddJsonFile("appsettings.json").Build() ;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddEntityFrameworkInMemoryDatabase();

            //services.AddAuthentication().AddGoogle
            var dbFilePath = Path.Combine(Environment.CurrentDirectory, "DBFile");
            if (!Directory.Exists(dbFilePath))
                Directory.CreateDirectory(dbFilePath);

            services
            .AddDbContext<CalculatorContext>(config=> {
                //config.UseInMemoryDatabase("AutoPostAdDealSplashInMemory");
                config.UseSqlite($"Filename={dbFilePath}\\Calculator.db");
                //config.Options.
            });

            //services.AddAuthentication((option) => option.DefaultAuthenticateScheme = jwt);
            services.AddDefaultIdentity<AspNetUsers>()
                .AddEntityFrameworkStores<CalculatorContext>()
                .AddDefaultTokenProviders();

            services.AddLogging((builder)=>builder.AddConsole());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddScoped<>
           
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
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

           

            //app.ApplicationServices.getse
            


            var configObjs = new MySettings();
            Configuration.GetSection("MySettings").Bind(configObjs);

            //app.Use(next=>context=> { } );

            //app.Run((ctx => {
            //    foreach (var idname in configObjs.ConfigObjs)
            //    {
            //        //ctx.Response.WriteAsync(Configuration["Logging:LogLevel:Default"]);
            //        ctx.Response.WriteAsync($"ID: {idname.ID} Name:{idname.Name}");
            //        ctx.Response.WriteAsync(Environment.NewLine);
            //    }
            //    return Task.CompletedTask;
            //}));

            app.UseAuthentication();

            app.Use(async  (context, next) =>
            {
                //await context.Response.WriteAsync("sss");
                //return next();
                await next.Invoke();
            });

           

            //app.UseWebSockets(new WebSocketOptions() { KeepAliveInterval = TimeSpan.FromSeconds(60) });

            //app.Map("/foo", config=>config.use)

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                //template: "{controller=Home}/{action=Index}");
                //template: "{controller=Home}/{action=Calculator}");
                template: "{controller=Home}/{action=VotoboSearch}");
            });


        }
    }

    public class MySettings
    {
        public List<ConfigObj> ConfigObjs { get; set; }

        public class ConfigObj
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }
    }

    //public class IDName
    //{
    //    public string ID { get; set; }
    //    public string Name { get; set; }
    //}
}
