using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

// https://docs.microsoft.com/ko-kr/aspnet/core/data/ef-mvc/migrations
// https://docs.microsoft.com/en-us/aspnet/core/publishing/linuxproduction?tabs=aspnetcore2x
// https://blog.elmah.io/appsettings-in-aspnetcore/

// Secure Web Api in asp.net core
// http://www.blinkingcaret.com/2017/09/06/secure-web-api-in-asp-net-core/

// to migration
/*
1. dotnet ef migrations add InitialCreate (ef migrations remov)
2. dotnet ef database update (dotnet ef database drop)
*/

namespace web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
       

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);

            // var connection = @"server=localhost;port=3306;database=TodoApi;user=TodoApiUsr;password=todoapiusr@pwd!";
            var connection = appSettings["ConnectionStrings:DefaultConnection"];
            // services.AddDbContext<TodoContext>(options => options.UseMySql(connection));

            services.AddMvc();
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
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
